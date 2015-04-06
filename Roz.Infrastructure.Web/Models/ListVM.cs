using System.Collections.Generic;

namespace Roz.Infrastructure.Web.Models
{
    public class ListVM
    {
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public FilterVM Filter { get; set; }
    }

    public class ListVM<T> : ListVM
    {
        public IList<T> Items { get; set; }
    }
}