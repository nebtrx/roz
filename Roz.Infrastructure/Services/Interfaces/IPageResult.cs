using System.Collections.Generic;

namespace Roz.Infrastructure.Services
{
    public interface IPageResult<T> : IPaged
    {
        IEnumerable<T> Items { get; set; }
    }
}
