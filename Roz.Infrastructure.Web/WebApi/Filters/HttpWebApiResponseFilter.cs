using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Roz.Infrastructure.Web.WebApi.Filters
{
    public class HttpWebApiResponseFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;
            if (response.Content != null && !response.Content.IsHttpResponseMessageContent() && response.Content is ObjectContent)
            {
                var objContent = response.Content as ObjectContent;
                var value = objContent.Value;

                var code = HttpStatusCode.OK;
                if (value is ApiResult)
                {
                    var apiresult = value as ApiResult;
                    code = apiresult.StatusCode;
                    value = apiresult.Value;
                }

                var result = request.CreateResponse(code);
                if (value != null)
                {
                    var config = request.GetConfiguration();
                    var negociator = config.Services.GetContentNegotiator();
                    var nresult = negociator.Negotiate(value.GetType(), request, config.Formatters);
                    result.Content = new ObjectContent(value.GetType(), value, nresult.Formatter);
                }
                actionExecutedContext.Response = result;
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
        }
    }
}