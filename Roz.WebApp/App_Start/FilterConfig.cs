using System.Web;
using System.Web.Mvc;
using Roz.Infrastructure.Web.Filters;

namespace Roz.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(DependencyResolver.Current.GetService(typeof(DataContextWebFilter)));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
