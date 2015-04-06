using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Roz.Infrastructure.Web.WebApi.Filters;

namespace Roz.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // responsible for returning the 406 when impossible to find a format for the Accept header
            DefaultContentNegotiator negotiator = new DefaultContentNegotiator(true);
            config.Services.Replace(typeof(IContentNegotiator), negotiator);

            //var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //xml.UseXmlSerializer = true;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
            config.Filters.Add((IFilter)DependencyResolver.Current.GetService(typeof(HttpWebApiResponseFilter)));

            // TODO: Fix dependency resolution
            //config.Filters.Add(new DataContextApiFilter());
            config.Filters.Add((IFilter)DependencyResolver.Current.GetService(typeof(DataContextApiFilter)));
        }
    }
}
