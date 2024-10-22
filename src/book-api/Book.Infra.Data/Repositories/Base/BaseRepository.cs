using Book.Domain.Entities.Base;
using Book.Domain.Interfaces.Base;
using Book.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Book.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseDomain, new()
    {
        protected readonly BookDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(BookDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(Guid id)
        {
            return await _dbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = new TEntity { Id = id };
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
