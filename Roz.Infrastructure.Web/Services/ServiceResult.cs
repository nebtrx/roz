using System.Collections.Generic;

namespace Roz.Infrastructure.Web.Services
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Messages = new List<Message>();
            Success = true;
        }

        public bool Success { get; set; }

        public IList<Message> Messages { get; set; }
    }
}
