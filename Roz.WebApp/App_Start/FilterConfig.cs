using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Roz.Infrastructure.Web.Filters;
using Elmah;
using Roz.Logging.Elmah.Async;

namespace Roz.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(DependencyResolver.Current.GetService(typeof(DataContextWebFilter)));
            filters.Add(new LoggingActionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
