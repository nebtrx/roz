using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Roz.Data
{
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class, IEntityWithKey<TKey>
    {
        IQueryable<TEntity> All();

        TEntity Find(TKey id);

        TEntity Find(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> AllAsync();

        Task<TEntity> FindAsync(TKey id);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression);
    }

}
