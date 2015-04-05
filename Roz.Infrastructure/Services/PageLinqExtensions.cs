using System.Collections.Generic;
using System.Linq;

namespace Roz.Infrastructure.Services
{
    public static class PageLinqExtensions
    {
        public static PageResult<T> ToPagedResult<T>(this IEnumerable<T> allItems, int page, int count)
        {
            if (page < 1)
                page = 1;

            var itemIndex = (page - 1) * count;
            var pageOfItems = (count > 0) ? allItems.Skip(itemIndex).Take(count) : allItems;
            var totalItemCount = allItems.Count();

            return new PageResult<T>(pageOfItems.ToList(), page, count, totalItemCount);
        }
    }
}
