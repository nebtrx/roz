using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Roz.I18N.Providers;
using Roz.Utilities;
using Roz.Web.Settings;

namespace Roz.I18N.Utilities
{
    public static class LocalizedExtensions
    {
        public static string GetText(string resxKey)
        {
            return GetText(resxKey, Thread.CurrentThread.CurrentUICulture);
        }

        public static string GetText(string resxKey, CultureInfo culture)
        {
            return DependencyResolver.Current.GetService<ILocalizedTextProvider>().GetText(resxKey, culture);
        }

        public static string GetText(this HtmlHelper html, string resxKey)
        {
            return GetText(resxKey);
        }

        public static string GetText(this HtmlHelper html, string resxKey, CultureInfo culture)
        {
            return GetText(resxKey, culture);
        }

        public static void EnsureCurrentUICulture()
        {
            var culture = SystemSettings.Current.DefaultCulture;

            var routeData = RouteTable.Routes.GetRouteData(HttpContext.Current.Request.RequestContext.HttpContext);
            if (routeData != null)
            {
                try
                {
                    var routeCulture = routeData.Values["culture"];
                    var routedCultureName = (routeCulture != null) ? routeCulture.ToString() : "";
                    culture = CultureInfo.CreateSpecificCulture(routedCultureName);
                }
                catch {}
            }

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}