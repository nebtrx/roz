using System;
using System.Collections.Generic;

namespace Roz.Infrastructure.Services
{
    public class PageResult<T> : IPageResult<T>
    {
        public PageResult(IEnumerable<T> items, int pageIndex, int pageSize, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
            PageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            CurrentPage = pageIndex;
            PageSize = pageSize;
        }

        public PageResult() : this(null, 0, 0, 0)
        {

        }

        public IEnumerable<T> Items { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }

        public int PageCount { get; private set; }
    }
}
