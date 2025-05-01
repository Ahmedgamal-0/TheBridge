using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheBridge.Context;

namespace TheBridge.Repositories.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TheBridgeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TheBridgeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking=true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            else
            {
                return await _dbSet.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<T>> GetPagedAsync(int pageIndex, int pageSize)
        {
            return await _dbSet
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
