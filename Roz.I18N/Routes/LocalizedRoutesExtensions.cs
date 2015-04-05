using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Roz.I18N.Routes
{
    public static class LocalizedRoutesExtensions
    {
        public static Route MapLocalizedRoute(this RouteCollection routes, string defaultCulture, string  name, string url, object defaults, object constraints = null, string[] namespaces = null)
        {
            var route = CreateRoute(routes, defaultCulture, url, defaults, constraints, namespaces);

            routes.Add(name, route);

            return route;
        }

        public static Route MapLocalizedRoute(this RouteCollection routes, string defaultCulture, string url, object defaults, object constraints = null, string[] namespaces = null)
        {
            var route = CreateRoute(routes, defaultCulture, url, defaults, constraints, namespaces);

            routes.Add(route);

            return route;
        }

        public static Route MapLocalizedRoute(this AreaRegistrationContext context, string defaultCulture, string url, object defaults, object constraints = null, string[] namespaces = null)
        {
            return CreateAreaRoute(context, defaultCulture, url, defaults, constraints, namespaces);
        }

        public static Route MapLocalizedRoute(this AreaRegistrationContext context, string defaultCulture, string name, string url, object defaults, object constraints = null, string[] namespaces = null)
        {
            return CreateAreaRoute(context, defaultCulture, url, defaults, constraints, namespaces, name);
        }


        private static Route CreateRoute(RouteCollection routes, string defaultCulture, string url, object defaults,
                                         object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            Route route = new LocalizedRoute(url, defaultCulture)
                        {
                            Defaults = (defaults != null) ? new RouteValueDictionary(defaults) : new RouteValueDictionary(),
                            Constraints = (constraints != null) ? new RouteValueDictionary(constraints) : new RouteValueDictionary(),
                            DataTokens = new RouteValueDictionary()
                        };

            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            return route;
        }


        private static Route CreateAreaRoute(AreaRegistrationContext context, string defaultCulture, string url, object defaults,
                                             object constraints, string[] namespaces, string name = null)
        {
            if (namespaces == null && context.Namespaces != null)
                namespaces = context.Namespaces.ToArray();

            Route route = name == null 
                ? context.Routes.MapLocalizedRoute(defaultCulture, url, defaults, constraints, namespaces)
                : context.Routes.MapLocalizedRoute(defaultCulture, url, name,  defaults, constraints, namespaces);

            route.DataTokens["area"] = context.AreaName;
            route.DataTokens["UseNamespaceFallback"] = namespaces == null || namespaces.Length == 0;
            return route;
        }

        
    }
}
