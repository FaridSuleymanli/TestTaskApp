using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.Data;

namespace TestTaskApp.Common
{
    public class BaseEfRepository<TModel> : IBaseEfRepository<TModel>
        where TModel : class
    {
        private readonly TaskDbContext _context;
        private DbSet<TModel> Table => _context.Set<TModel>();

        public IUnitOfWork UnitOfWork;

        public BaseEfRepository(TaskDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            UnitOfWork = unitOfWork;
        }

        public Task<TModel> Get(Expression<Func<TModel, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TModel>> GetListAsQueryable(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table);
        }

        public Task<IQueryable<TModel>> GetListWithIncludingAsQueryable(CancellationToken cancellationToken = default, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> inquery = Table;
            inquery = includeProperties.Aggregate(inquery, (current, includeProperty) => current.Include(includeProperty));
            return Task.FromResult(inquery);
        }

        public async Task Add(TModel entity, CancellationToken cancellationToken = default)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
