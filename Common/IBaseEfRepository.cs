using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskApp.Common
{
    public interface IBaseEfRepository<TModel> where TModel : class
    {
        Task<IQueryable<TModel>> GetListAsQueryable(CancellationToken cancellationToken = default);

        Task<TModel> Get(Expression<Func<TModel, bool>> predicate = default, CancellationToken cancellationToken = default);

        Task<IQueryable<TModel>> GetListWithIncludingAsQueryable(CancellationToken cancellationToken = default, params Expression<Func<TModel, object>>[] includeProperties);

        Task<TModel> GetWithIncludingAsQueryable(IQueryable<TModel> model,
        CancellationToken cancellationToken = default, params Expression<Func<TModel, object>>[] includeProperties);

        Task Add(TModel entity, CancellationToken cancellationToken = default);
    }
}
