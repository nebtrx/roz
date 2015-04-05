namespace Roz.Data
{
    public interface IRepository<TKey, TEntity> : IPersistRepository<TKey, TEntity>, IReadOnlyRepository<TKey, TEntity>, IRawRepository<TKey, TEntity> 
        where TEntity : class, IEntityWithKey<TKey>
    {

    }
}
