using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Services.Common
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        public virtual Task<ResponseBase<string>> Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<ResponseBase<IEnumerable<T>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<ResponseBase<T>> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<ResponseBase<string>> Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<ResponseBase<string>> Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
