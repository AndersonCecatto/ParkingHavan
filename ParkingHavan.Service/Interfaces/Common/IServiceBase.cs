using ParkingHavan.Domain.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Interfaces.Common
{
    public interface IServiceBase<T>
    {
        Task<ResponseBase<IEnumerable<T>>> GetAll();
        Task<ResponseBase<T>> GetById(long id);
        Task<ResponseBase<string>> Insert(T entity);
        Task<ResponseBase<string>> Delete(long id);
        Task<ResponseBase<string>> Update(T entity);
    }
}
