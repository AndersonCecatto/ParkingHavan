using ParkingHavan.Domain.Models;
using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Interfaces
{
    public interface IEstacionamentoService<T> : IServiceBase<T>
    {
        Task<ResponseBase<IEnumerable<EstacionamentoModel>>> GetByPlaca(string placa);
        Task<ResponseBase<EstacionamentoModel>> Pagamento(string placa);
        Task<ResponseBase<IEnumerable<EstacionamentoModel>>> FinalizadosOrEmAberto(DateTime dataInicial, DateTime dataFinal, bool ehFinalizado);

        Task<ResponseBase<IEnumerable<EstacionamentoModel>>> HistoricoCondutor(string nome);
        Task<ResponseBase<IEnumerable<EstacionamentoModel>>> HistoricoVeiculo(string placa);
    }
}
