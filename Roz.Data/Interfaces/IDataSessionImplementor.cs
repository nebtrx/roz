using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roz.Data
{
    public interface IDataSessionImplementor
    {
        TKey Add<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        void Add<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>;
        void Update<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        void Delete<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        void Delete<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>;
        IQueryable<TEntity> All<TEntity, TKey>() where TEntity : class, IEntityWithKey<TKey>;
        Task AddAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        Task AddAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>;
        Task UpdateAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        Task DeleteAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>;
        Task DeleteAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>;
        Task<IQueryable<TEntity>> AllAsync<TEntity, TKey>() where TEntity : class, IEntityWithKey<TKey>;
        void SaveChangesAsync();
        void SaveChanges();
    }
}