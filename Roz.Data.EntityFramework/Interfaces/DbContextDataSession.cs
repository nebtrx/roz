using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Roz.Data.EntityFramework
{
    public class DbContextDataSession<TDbContext> : IDataSessionImplementor where TDbContext : DbContext, new()
    {
        public TDbContext DbContext { get; private set; }

        DbContextDataSession()
        {
            DbContext = new TDbContext();
        }

        public TKey Add<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public void Add<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task AddAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().AddRange(entities);

        }

        public async Task UpdateAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Entry(entity).State = EntityState.Modified;

        }

        public async Task DeleteAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().Remove(entity);

        }

        public async Task DeleteAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntityWithKey<TKey>
        {
            DbContext.Set<TEntity>().RemoveRange(entities);

        }

        public IQueryable<TEntity> All<TEntity, TKey>() where TEntity : class, IEntityWithKey<TKey>
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<IQueryable<TEntity>> AllAsync<TEntity, TKey>() where TEntity : class, IEntityWithKey<TKey>
        {
            return await Task.FromResult(All<TEntity, TKey>());
        }

        public async void SaveChangesAsync()
        {
            await  DbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

    }
}