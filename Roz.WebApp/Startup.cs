using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Roz.WebApp.Startup))]
namespace Roz.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
