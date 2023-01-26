using ParkingHavan.Domain.Models;
using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces.Common;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Interfaces
{
    public interface ITabelaPrecoPeriodoVigenciaService<T> : IServiceBase<T>
    {
        Task<ResponseBase<string>> InsertTipoPeriodo(TabelaPrecoTipoPeriodoModel entity);
        Task<ResponseBase<string>> InsertValores(TabelaPrecoValoresModel entity);
    }
}
