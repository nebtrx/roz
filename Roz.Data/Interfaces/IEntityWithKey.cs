namespace Roz.Data
{
    public interface IEntityWithKey<TKey>
    {
        TKey Id { get; }
    }
}
