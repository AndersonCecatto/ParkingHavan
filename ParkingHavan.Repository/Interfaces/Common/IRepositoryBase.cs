using ParkingHavan.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParkingHavan.Repository.Interfaces.Common
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IQueryable<T> Query();

        Task<IQueryable<T>> QueryAsync();

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddAndSaveAsync(T entity);

        Task SaveAsync(T entity);

        Task SaveChangesAsync();

        void Update(T entity);

        Task UpdateAndSaveAsync(T entity);

        void Remove(T entity);

        Task Delete(long id);

        Task<bool> Exists(long id);

        Task<T> GetById(long id);
    }
}
