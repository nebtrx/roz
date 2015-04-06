using System.Net;

namespace Roz.Infrastructure.Web.WebApi
{
    public class ApiResult
    {
        public ApiResult(HttpStatusCode statusCode, object value)
        {
            StatusCode = statusCode;
            Value = value;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public object Value { get; private set; }
    }
}