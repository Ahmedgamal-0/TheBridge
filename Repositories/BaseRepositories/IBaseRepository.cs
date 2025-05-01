using System.Linq.Expressions;

namespace TheBridge.Repositories.BaseRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking=true);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<T>> GetPagedAsync(int pageIndex, int pageSize);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
