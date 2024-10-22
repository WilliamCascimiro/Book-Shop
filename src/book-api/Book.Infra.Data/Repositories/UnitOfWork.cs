using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Book.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception) { }
            finally
            {
                _transaction.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAndCommitAsync()
        {
            var result = await SaveChangesAsync();
            await CommitAsync();
            return result;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
