using AutoMapper;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;
using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces;
using ParkingHavan.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Services
{
    public class TabelaPrecoPeriodoVigenciaService : ServiceBase<TabelaPrecoPeriodoVigenciaModel>, ITabelaPrecoPeriodoVigenciaService<TabelaPrecoPeriodoVigenciaModel>
    {
        private readonly ITabelaPrecoPeriodoVigenciaRepository _tabelaPrecoPeriodoVigenciaRepository;
        private readonly ITabelaPrecoTipoPeriodoRepository _tabelaPrecoTipoPeriodoRepository;
        private readonly ITabelaPrecoValoresRepository _tabelaPrecoValoresRepository;
        private readonly IMapper _mapper;

        public TabelaPrecoPeriodoVigenciaService(
            IMapper mapper, 
            ITabelaPrecoPeriodoVigenciaRepository tabelaPrecoPeriodoVigenciaRepository,
            ITabelaPrecoTipoPeriodoRepository tabelaPrecoTipoPeriodoRepository,
            ITabelaPrecoValoresRepository tabelaPrecoValoresRepository)
        {
            _mapper = mapper;
            _tabelaPrecoPeriodoVigenciaRepository = tabelaPrecoPeriodoVigenciaRepository;
            _tabelaPrecoTipoPeriodoRepository = tabelaPrecoTipoPeriodoRepository;
            _tabelaPrecoValoresRepository = tabelaPrecoValoresRepository;
        }

        public override async Task<ResponseBase<string>> Insert(TabelaPrecoPeriodoVigenciaModel entity)
        {
            try
            {
                await _tabelaPrecoPeriodoVigenciaRepository.AddAndSaveAsync(_mapper.Map<TabelaPrecoPeriodoVigencia>(entity));

                return new ResponseBase<string> { Dados = "Salvo com Sucesso!", Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<string> { Sucesso = false, Dados = "Erro ao Salvar!", Mensagens = new List<string> { ex.Message } };
            }
        }

        public async Task<ResponseBase<string>> InsertTipoPeriodo(TabelaPrecoTipoPeriodoModel entity)
        {
            try
            {
                await _tabelaPrecoTipoPeriodoRepository.AddAndSaveAsync(_mapper.Map<TabelaPrecoTipoPeriodo>(entity));

                return new ResponseBase<string> { Dados = "Salvo com Sucesso!", Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<string> { Sucesso = false, Dados = "Erro ao Salvar!", Mensagens = new List<string> { ex.Message } };
            }
        }

        public async Task<ResponseBase<string>> InsertValores(TabelaPrecoValoresModel entity)
        {
            try
            {
                entity.Minuto = entity.Hora * 60 + entity.Minuto;

                await _tabelaPrecoValoresRepository.AddAndSaveAsync(_mapper.Map<TabelaPrecoValores>(entity));

                return new ResponseBase<string> { Dados = "Salvo com Sucesso!", Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<string> { Sucesso = false, Dados = "Erro ao Salvar!", Mensagens = new List<string> { ex.Message } };
            }
        }
    }
}
