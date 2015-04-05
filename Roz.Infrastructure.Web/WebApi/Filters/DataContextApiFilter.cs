using System.Web.Http.Filters;
using Roz.Data;
using Roz.Data.Scope;

namespace Roz.Infrastructure.Web.WebApi.Filters
{
    public class DataContextApiFilter : ActionFilterAttribute
    {
        private IDataContextScope _dataContextScope;

        public DataContextApiFilter()
        {
            
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                _dataContextScope.SaveChanges();
                _dataContextScope.Dispose();
            }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            _dataContextScope = DataEngine.Main.DataContextScopeFactory.Create();
        }
    }
}