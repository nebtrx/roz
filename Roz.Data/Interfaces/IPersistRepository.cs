using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roz.Data
{
    public interface IPersistRepository<TKey, TEntity> where TEntity : class, IEntityWithKey<TKey>
    {
        //IUnitOfWork UnitOfWork { get; }

        TKey Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(IEnumerable<TEntity> entities);
    }
}
