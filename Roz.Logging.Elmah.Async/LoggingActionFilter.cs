using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace Roz.Logging.Elmah.Async
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
        private Error _prototype;
        private static object _syncRoot = new object();
        private static bool _initiated;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!_initiated)
            {
                TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            }
            _prototype = new Error(new Exception(), HttpContext.Current);
            _initiated = true;
        }

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

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}