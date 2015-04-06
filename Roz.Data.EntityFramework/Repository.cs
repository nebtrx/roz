using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Roz.Data.EntityFramework.Utilities;

namespace Roz.Data.EntityFramework
{
    public class Repository<TEntity> : Repository<long, TEntity>
        where TEntity : class, IEntityWithKey<long>
    {
        public Repository(IEFDataEngine dataEngine)
            : base(dataEngine)
        {
        }
    }

    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IEntityWithKey<TKey>
    {
        private DbContext _context;

        public Repository(IEFDataEngine dataEngine)
        {
            DataEngine = dataEngine;
            DbContextType = DataEngine.GetEntityContextType(typeof(TEntity));
        }

        public Type DbContextType { get; private set; }


        public IQueryable<TEntity> All()
        {
            return DbContext.Set<TEntity>().AsQueryable();

        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public TEntity Find(TKey id)
        {
            return DbContext.Set<TEntity>().Find(id);

        }

        public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        public async Task<IQueryable<TEntity>> AllAsync()
        {
            return await Task.FromResult(All());
        }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return await Task.FromResult(Find(id));
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(Find(expression));
        }

        public async Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(FilterBy(expression));
        }

        public TKey Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return entity.Id;

        }

        public void Add(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();

        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            DbContext.SaveChanges();

        }

        public async Task AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();

        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            await DbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();

        }

        public void ExecuteRawQuery(string queryString, params object[] queryParams)
        {
            //var query = Context.Set<TEntity>().SqlQuery(queryString, queryParams);
            //query.ExecuteUpdate();
            throw new NotImplementedException();
        }

        public async Task ExecuteRawQueryAsync(string queryString, params object[] queryParams)
        {
            throw new NotImplementedException();
        }

        public DbContext DbContext
        {
            get
            {
                return _context ?? (_context = (DbContext)DataEngine.AmbientContextLocator.Get(DbContextType));
            }

        }

        protected IEFDataEngine DataEngine { get; set; }

    }
}
