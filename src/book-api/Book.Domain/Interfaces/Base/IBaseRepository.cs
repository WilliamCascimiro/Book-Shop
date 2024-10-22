using Book.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Book.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseDomain
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
