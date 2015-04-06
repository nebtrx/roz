using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using System.Web.Mvc.Filters;
using Roz.Data;

namespace Roz.Infrastructure.Web.Mvc
{
    public class AsyncDataAwareActionInvoker : AsyncControllerActionInvoker
    {
        //private readonly ITransactionManager _transactionManager;
        //private readonly IDataSessionManager _dataSessionManager;

        //public AsyncDataAwareActionInvoker(ITransactionManager transactionManager, IDataSessionManager dataSessionManager)
        //{
        //    _transactionManager = transactionManager;
        //    _dataSessionManager = dataSessionManager;
        //}

        //public override IAsyncResult BeginInvokeAction(ControllerContext controllerContext, string actionName, AsyncCallback callback,
        //    object state)
        //{
        //    OnBeforeInvokeAction();
        //    return base.BeginInvokeAction(controllerContext, actionName, callback, state);
        //}

        //public override bool EndInvokeAction(IAsyncResult asyncResult)
        //{
        //    var result = base.EndInvokeAction(asyncResult);
        //    OnPostActionInvoked();
        //    return result;
        //}

        //public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        //{
        //    OnBeforeInvokeAction();
        //    var result = base.InvokeAction(controllerContext, actionName);
        //    OnPostActionInvoked();
        //    return result;
        //}

        //protected override ExceptionContext InvokeExceptionFilters(ControllerContext controllerContext, IList<IExceptionFilter> filters, Exception exception)
        //{
        //    _transactionManager.Rollback();
        //    _dataSessionManager.HandleError(exception);

        //    return base.InvokeExceptionFilters(controllerContext, filters, exception);
        //}

        //protected void OnBeforeInvokeAction()
        //{
        //    _dataSessionManager.BindSession();
        //    _transactionManager.BeginTransaction();
        //}

        //protected void OnPostActionInvoked()
        //{
        //    _transactionManager.Commit();
        //    _dataSessionManager.UnbindSession();
        //}
    }
}