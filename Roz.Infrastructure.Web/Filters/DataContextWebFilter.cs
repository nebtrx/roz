using System.Web.Mvc;
using Roz.Data;
using Roz.Data.Scope;

namespace Roz.Infrastructure.Web.Filters
{
    public class DataContextWebFilter : ActionFilterAttribute
    {
        private IDataContextScope _dataContextScope;

        public DataContextWebFilter()
        {

        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                _dataContextScope.SaveChanges();
                _dataContextScope.Dispose();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            _dataContextScope = DataEngine.Main.DataContextScopeFactory.Create();
        }
    }
}