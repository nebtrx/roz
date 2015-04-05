using System.Linq;
using Roz.Data;

namespace Roz.Infrastructure.Web.Services
{
    public class Service<TId, TEntity>
        where TEntity : class,IEntityWithKey<TId>
    {
        protected IRepository<TId, TEntity> _repository;

        public Service(IRepository<TId, TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Get(TId id)
        {
            return _repository.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.All();
        }

        public virtual ServiceResult Insert(TEntity entity)
        {
            var result = ValidateForInsert(entity);
            if (result.Success)
            {
                _repository.Add(entity);
            }
            return result;
        }

        public virtual ServiceResult Update(TEntity entity)
        {
            var result = ValidateForUpdate(entity);
            if (result.Success)
            {
                _repository.Update(entity);
            }
            return result;
        }

        public virtual ServiceResult Delete(TId id)
        {
            var result = new ServiceResult { Success = false };
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

        protected virtual ServiceResult ValidateForInsert(TEntity entity)
        {
            return new ServiceResult();
        }

        protected virtual ServiceResult ValidateForUpdate(TEntity entity)
        {
            return new ServiceResult();
        }

        protected ServiceResult ValidateForDelete(TEntity entity)
        {
            return new ServiceResult();
        }

        #endregion
    }
}
