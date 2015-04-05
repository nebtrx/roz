using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Roz.I18N.Routes
{
    public class LocalizedRoute : Route
    {
        public const string CultureParam = "culture";
        private readonly string _defaultCulture;
        private readonly string _url;

        public LocalizedRoute(string url, string defaultCulture)
            : base(url, new MvcRouteHandler())
        {
            _url = url;
            _defaultCulture = defaultCulture;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestedURL = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            var segments = requestedURL.Split('/').Where(x => x != "~").ToArray();

            // if request is not localized then call base
            if (segments.Length > 0 && !Regex.IsMatch(segments[0], @"^[a-z]{2}(-[A-Z]{2})?$"))
            {
                var result = base.GetRouteData(httpContext);
                if (result != null)
                    result.Values[CultureParam] = _defaultCulture;
                return result;
            }

            // if request is localized then prepend the culture segment to the url
            var currentUrl = Url;
            Url = string.Format("{{" + CultureParam + "}}/{0}", _url);
            var baseRoute = base.GetRouteData(httpContext);
            Url = currentUrl;
            // save and restore the current URL
            return baseRoute;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            string culture = "", lnRequest = "", lnValues = "";
            // look for the language param in current request context
            if (requestContext.RouteData.Values.ContainsKey(CultureParam))
            {
                // if found then save it in lang variable
                lnRequest = culture = (string)requestContext.RouteData.Values[CultureParam];
                // and remove it
                requestContext.RouteData.Values.Remove(CultureParam);
            }

            // look for the language param in explicit values 
            if (values.ContainsKey(CultureParam))
            {
                lnValues = culture = (string)values[CultureParam];
                values.Remove(CultureParam);
            }

            // call base method...
            var virtualPath = base.GetVirtualPath(requestContext, values);

            // restore from current request context if necessary
            if (!string.IsNullOrWhiteSpace(lnRequest))
                requestContext.RouteData.Values.Add(CultureParam, lnRequest);
            // restore from explicit values if necessary
            if (!string.IsNullOrWhiteSpace(lnValues))
                values.Add(CultureParam, lnRequest);

            if (virtualPath == null) return null;

            // prepend language segment if necessary and only if different from the default language
            if (!string.IsNullOrWhiteSpace(culture) && !string.Equals(culture, _defaultCulture, StringComparison.OrdinalIgnoreCase))
            {
                virtualPath.VirtualPath = culture + "/" + virtualPath.VirtualPath;
            }
            return virtualPath;
        }
    }
}