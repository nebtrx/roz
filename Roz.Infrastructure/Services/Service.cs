using System.Linq;
using Roz.Data;
using Roz.Utilities;

namespace Roz.Infrastructure.Services
{
    public class Service<TKey, TEntity>
        where TEntity : class,IEntityWithKey<TKey>
    {
        protected IRepository<TKey, TEntity> _repository;

        public Service(IRepository<TKey, TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Get(TKey id)
        {
            return _repository.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.All();
        }

        public IQueryable<TEntity> GetAll(int page, int count)
        {
            return GetAll().ToPage(page, count);
        }

        public PageResult<TEntity> List(int page, int count)
        {
            return GetAll().ToPagedResult(page, count);
        }

        public virtual NewItemResult<TKey> Create(TEntity entity)
        {
            var result = ValidateForCreate(entity);
            if (result.Success)
            {
                result.NewItemId = _repository.Add(entity);
            }
            return result;
        }

        public virtual Result Update(TEntity entity)
        {
            var result = ValidateForUpdate(entity);
            if (result.Success)
            {
                _repository.Update(entity);
            }
            return result;
        }

        public virtual Result Delete(TKey id)
        {
            var result = new Result();
            var entity = _repository.Find(id);
            if (entity != null)
            {
                result = ValidateForDelete(entity);
                if (result.Success)
                {
                    ExecuteDelete(entity);
                }
            }
            return result;
        }

        protected virtual void ExecuteDelete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        #region Validation Methods

        protected virtual NewItemResult<TKey> ValidateForCreate(TEntity entity)
        {
            return new NewItemResult<TKey>();
        }

        protected virtual Result ValidateForUpdate(TEntity entity)
        {
            return new Result();
        }

        protected Result ValidateForDelete(TEntity entity)
        {
            return new Result();
        }

        #endregion
    }
}
