using Ninject.Modules;
using Roz.Infrastructure.Web.WebApi.Filters;

namespace Roz.Infrastructure.Web.DI
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<HttpWebApiResponseFilter>().ToSelf();
            Bind<DataContextApiFilter>().ToSelf();
        }
    }
}