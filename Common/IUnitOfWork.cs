using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskApp.Common
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task SaveChangesAsync();

        Task CommitChangesAsync();

        Task RollBackAsync();

        void Dispose();
    }
}
