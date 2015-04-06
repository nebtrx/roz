using System;
using System.Web;
using System.Web.Routing;
using Roz.Data.EntityFramework.Helpers;
using Roz.Utilities;

namespace Roz.Data.EntityFramework
{
    public class EFModule : IHttpModule
    {
        #region Implementation of IHttpModule

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            if (IsPotentialDataConsumerRequest())
                DataSessionHelper.BindSession();
        }

        private void Application_EndRequest(object sender, EventArgs eventArgs)
        {
            if (IsPotentialDataConsumerRequest())
                DataSessionHelper.UnbindSession();
        }

        private bool IsPotentialDataConsumerRequest()
        {
            var routeData = RouteTable.Routes.GetRouteData(HttpContext.Current.Request.RequestContext.HttpContext);
            if (routeData == null) 
                return false;

            return !String.IsNullOrWhiteSpace((string)routeData.Values["controller"]);
        }

        private static void EnsureControllerBefore(Action action)
        {
            var routeData = RouteTable.Routes.GetRouteData(HttpContext.Current.Request.RequestContext.HttpContext);
            routeData.IfNotNull(data =>
            {
                if (String.IsNullOrWhiteSpace((string)routeData.Values["controller"])) 
                    return;
                action();
            });
            
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }
}
