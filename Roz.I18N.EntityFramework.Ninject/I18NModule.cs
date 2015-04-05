using Ninject.Modules;
using Roz.I18N.Providers;

namespace Roz.I18N.EntityFramework.Ninject
{
    public class I18NModule : NinjectModule
    {
        public override void Load()
        {
            // I18N
            Bind<ILocalizedTextProvider>().To<EFLocalizedTextProvider>();
        }
    }
}
