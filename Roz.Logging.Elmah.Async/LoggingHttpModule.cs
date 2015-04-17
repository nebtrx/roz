using System;
using System.Threading.Tasks;
using System.Web;
using Elmah;

namespace Roz.Logging.Elmah.Async
{
    public class LoggingHttpModule : IHttpModule
    {
        private Error _prototype;
        private static object _syncRoot = new object();


        #region Implementation of IHttpModule

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (Application_BeginRequest);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            lock (_syncRoot)
            {
                _prototype = new Error(new Exception(), HttpContext.Current); 
            }

            
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (!e.Observed)
            {
                e.SetObserved();

                Error error;
                lock (_syncRoot)
                {
                    error = new Error(e.Exception)
                    {
                        HostName = _prototype.HostName,
                        User = _prototype.User,
                    };
                    error.ServerVariables.Add(_prototype.ServerVariables);
                    error.QueryString.Add(_prototype.QueryString);
                    error.Cookies.Add(_prototype.Cookies);
                    error.Form.Add(_prototype.Form);
                }
                ErrorLog.GetDefault(null).Log(error);
            }
        }
    }
}
