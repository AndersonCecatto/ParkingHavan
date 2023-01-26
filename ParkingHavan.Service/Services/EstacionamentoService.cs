using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;
using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces;
using ParkingHavan.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Services
{
    public class EstacionamentoService : ServiceBase<EstacionamentoModel>, IEstacionamentoService<EstacionamentoModel>
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITabelaPrecoValoresRepository _tabelaPrecoValoresRepository;
        private readonly ITabelaPrecoPeriodoVigenciaRepository _tabelaPrecoPeriodoVigenciaRepository;
        private readonly IPeriodoVigenciaTipoPeriodoRepository _periodoVigenciaTipoPeriodoRepository;
        private readonly IMapper _mapper;

        public EstacionamentoService(
            IMapper mapper, 
            IEstacionamentoRepository estacionamentoRepository,
            ITabelaPrecoValoresRepository tabelaPrecoValoresRepository,
            ITabelaPrecoPeriodoVigenciaRepository tabelaPrecoPeriodoVigenciaRepository,
            IPeriodoVigenciaTipoPeriodoRepository periodoVigenciaTipoPeriodoRepository,
            IClienteRepository clienteRepository)
        {
            _tabelaPrecoPeriodoVigenciaRepository = tabelaPrecoPeriodoVigenciaRepository;
            _tabelaPrecoValoresRepository = tabelaPrecoValoresRepository;
            _periodoVigenciaTipoPeriodoRepository = periodoVigenciaTipoPeriodoRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        private async Task<Estacionamento> VerificandoEstabelecimento(EstacionamentoModel entity)
        {
            var periodoVigencia = (await _tabelaPrecoPeriodoVigenciaRepository.GetAllAsync()).FirstOrDefault();
            var tiposPeriodo = _periodoVigenciaTipoPeriodoRepository.GetAll().Include(x => x.TabelaPrecoTipoPeriodo).Where(x => x.TabelaPrecoPeriodoVigenciaId == periodoVigencia.Id);

            if (periodoVigencia.DataInicial > entity.HorarioInicial || periodoVigencia.DataFinal < entity.HorarioInicial)
                throw new Exception("A Data Inicial esta fora do periodo de Vigencia");

            foreach (var periodo in tiposPeriodo)
            {
                TimeSpan horaPeriodoInicial = new(periodo.TabelaPrecoTipoPeriodo.HorarioInicial.Hour, periodo.TabelaPrecoTipoPeriodo.HorarioInicial.Minute, periodo.TabelaPrecoTipoPeriodo.HorarioInicial.Second);
                TimeSpan horaPeriodoFinal = new(periodo.TabelaPrecoTipoPeriodo.HorarioFinal.Hour, periodo.TabelaPrecoTipoPeriodo.HorarioFinal.Minute, periodo.TabelaPrecoTipoPeriodo.HorarioFinal.Second);
                TimeSpan horaEstacionamento = new(entity.HorarioInicial.Hour, entity.HorarioInicial.Minute, entity.HorarioInicial.Second);

                if (entity.HorarioInicial.DayOfWeek == periodo.TabelaPrecoTipoPeriodo.Dia &&
                    horaEstacionamento > horaPeriodoInicial &&
                    horaEstacionamento < horaPeriodoFinal)
                {
                    return _mapper.Map<Estacionamento>(entity);
                }
            }

            return null;
        }

        public override async Task<ResponseBase<string>> Insert(EstacionamentoModel entity)
        {
            try
            {
                if (entity.Placa is not null)
                {
                    var cliente = await _clienteRepository.GetWhereAsync(x => x.PlacaCarro.Contains(entity.Placa));

                    if (cliente.Any())
                        entity.ClienteId = cliente.FirstOrDefault().Id;
                }

                var estabelecimento = await VerificandoEstabelecimento(entity);

                if (estabelecimento is null)
                    throw new Exception("Horario Informado fora do intervalo de funcionamento livre do estacionamento");
                else
                    await _estacionamentoRepository.AddAndSaveAsync(estabelecimento);
                
                return new ResponseBase<string> { Dados = "Salvo com Sucesso!", Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<string> { Sucesso = false, Dados = "Erro ao Salvar!", Mensagens = new List<string> { ex.Message } };
            }
        }

        private async Task<Estacionamento> EstacionamentosValorPago(Estacionamento estacionamento)
        {
            var tabelaValores = await _tabelaPrecoValoresRepository.GetAllAsync();
            estacionamento.HorarioFinal ??= DateTime.Now;

            TimeSpan minutosCorrigos = estacionamento.HorarioFinal.Value - estacionamento.HorarioInicial;
            var minutos = minutosCorrigos.TotalMinutes;

            foreach (var minutosValores in tabelaValores.ToList().OrderBy(x => x.Minuto))
            {
                if (minutos > minutosValores.Minuto)
                {
                    if (minutos <= (minutosValores.Minuto + 10))
                    {
                        estacionamento.ValorPagamento = minutosValores.Valor;
                        break;
                    }
                }
                else if (minutos < 30)
                {
                    estacionamento.ValorPagamento = (minutosValores.Valor / 2);
                    break;
                }
                else
                {
                    estacionamento.ValorPagamento = minutosValores.Valor;
                    break;
                }
            }

            return estacionamento;
        }

        public async Task<ResponseBase<IEnumerable<EstacionamentoModel>>> GetByPlaca(string placa)
        {
            try
            {
                var retorno = new List<EstacionamentoModel>();
                var estacionamentos = await _estacionamentoRepository.GetWhereAsync(x => x.Placa.Contains(placa));

                if (!estacionamentos.Any())
                    estacionamentos = await _estacionamentoRepository.GetWhereAsync(x => x.Cliente.PlacaCarro.Contains(placa));

                if (!estacionamentos.Any())
                    throw new Exception("Nenhuma resultado encontrado.");

                foreach (var estacionamento in estacionamentos)
                    retorno.Add(_mapper.Map<EstacionamentoModel>(estacionamento));

                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Dados = retorno, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Mensagens = new List<string> { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseBase<EstacionamentoModel>> Pagamento(string placa)
        {
            try
            {
                var estacionamento = (await _estacionamentoRepository.GetWhereAsync(x => x.Cliente.PlacaCarro.Contains(placa))).OrderByDescending(x => x.Id).FirstOrDefault();

                if (estacionamento is null)
                    throw new Exception("Nenhuma resultado encontrado.");

                estacionamento = await EstacionamentosValorPago(estacionamento);

                await _estacionamentoRepository.UpdateAndSaveAsync(_mapper.Map<Estacionamento>(estacionamento));

                return new ResponseBase<EstacionamentoModel> { Dados = _mapper.Map<EstacionamentoModel>(estacionamento), Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<EstacionamentoModel> { Mensagens = new List<string> { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseBase<IEnumerable<EstacionamentoModel>>> FinalizadosOrEmAberto(DateTime dataInicial, DateTime dataFinal, bool ehFinalizado)
        {
            try
            {
                IEnumerable<Estacionamento> finalizadosOrEmAberto = null;

                if (ehFinalizado)
                    finalizadosOrEmAberto = await _estacionamentoRepository.GetWhereAsync(x => x.HorarioFinal >= dataInicial && x.HorarioFinal <= dataFinal);
                else
                    finalizadosOrEmAberto = await _estacionamentoRepository.GetWhereAsync(x => x.HorarioFinal == null);

                var retorno = new List<EstacionamentoModel>();

                foreach (var estacionado in finalizadosOrEmAberto)
                    retorno.Add(_mapper.Map<EstacionamentoModel>(estacionado));

                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Dados = retorno, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Mensagens = new List<string> { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseBase<IEnumerable<EstacionamentoModel>>> HistoricoCondutor(string nome)
        {
            try
            {
                var estacionamentos = _estacionamentoRepository.GetAll().Include(x => x.Cliente).Where(x => x.Cliente.Nome.ToUpper().Contains(nome.ToUpper()));

                var retorno = new List<EstacionamentoModel>();

                foreach (var estacionado in estacionamentos)
                    retorno.Add(_mapper.Map<EstacionamentoModel>(estacionado));

                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Dados = retorno, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Mensagens = new List<string> { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseBase<IEnumerable<EstacionamentoModel>>> HistoricoVeiculo(string placa)
        {
            try
            {
                var estacionamentos = _estacionamentoRepository.GetAll().Include(x => x.Cliente).Where(x => x.Cliente.PlacaCarro.ToUpper().Contains(placa.ToUpper()));

                var retorno = new List<EstacionamentoModel>();

                foreach (var estacionado in estacionamentos)
                    retorno.Add(_mapper.Map<EstacionamentoModel>(estacionado));

                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Dados = retorno, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<IEnumerable<EstacionamentoModel>> { Mensagens = new List<string> { ex.Message }, Sucesso = false };
            }
        }
    }
}
