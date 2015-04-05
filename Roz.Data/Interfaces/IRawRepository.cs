using System.Threading.Tasks;

namespace Roz.Data
{
    public interface IRawRepository<TKey, TEntity> where TEntity : class, IEntityWithKey<TKey>
    {
        void ExecuteRawQuery(string queryString, params object[] queryParams);

        Task ExecuteRawQueryAsync(string queryString, params object[] queryParams);
    }
}
