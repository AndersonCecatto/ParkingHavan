using Microsoft.EntityFrameworkCore;
using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Common;
using ParkingHavan.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParkingHavan.Data.Repositories.Common
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected ParkingContext _context;

        public RepositoryBase(ParkingContext context)
        {
            _context = context;
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => _context.Set<T>().FirstOrDefaultAsync(predicate);

        public IQueryable<T> Query() => _context.Set<T>().AsQueryable();

        public async Task<IQueryable<T>> QueryAsync() => await Task.Run(() => _context.Set<T>().AsQueryable());

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public IQueryable<T> GetAll() => _context.Set<T>();

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddAndSaveAsync(T entity)
        {
            await AddAsync(entity);
            await SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            Update(entity);
            await SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync(T entity)
        {
            if (!(entity is EntityBase))
                return;

            if (entity.Id == 0)
                await AddAsync(entity);
            else
                Update(entity);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task Delete(long id)
        {
            Remove(await FirstOrDefaultAsync(e => e.Id == id));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(long id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<T> GetById(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
