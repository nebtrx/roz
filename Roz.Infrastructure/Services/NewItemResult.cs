namespace Roz.Infrastructure.Services
{
    public class NewItemResult<TKey> : Result
    {
        public NewItemResult()
        {
        }

        public NewItemResult(TKey newItemId, ErrorList errorList = null)
            : base(errorList) 
        {
            NewItemId = newItemId;
        }

        public TKey NewItemId { get; internal set; }
    }
}