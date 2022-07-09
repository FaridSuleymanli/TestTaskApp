using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApp.Data;

namespace TestTaskApp.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _activeTransaction;
        private TaskDbContext _activeDbContext;
        private bool _disposed;

        public UnitOfWork WithContext(TaskDbContext activeDbContext)
        {
            _activeDbContext = activeDbContext;
            return this;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _activeTransaction = await _activeDbContext.Database.BeginTransactionAsync();

            if (_activeTransaction.GetDbTransaction().Connection == _activeDbContext.Database.GetDbConnection())
            {
                await _activeDbContext.Database.UseTransactionAsync(_activeTransaction.GetDbTransaction());
            }

            return _activeTransaction;
        }

        public async Task CommitChangesAsync()
        {
            await _activeTransaction?.CommitAsync()!;
        }

        public async Task RollBackAsync()
        {
            await _activeTransaction?.RollbackAsync()!;
        }

        public async Task SaveChangesAsync()
        {
            if (!_activeDbContext.ChangeTracker.HasChanges())
            {
                return;
            }

            await _activeDbContext.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _activeDbContext.Dispose();
                    _activeTransaction?.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
