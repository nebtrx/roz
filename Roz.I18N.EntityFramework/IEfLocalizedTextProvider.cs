using Roz.I18N.Providers;

namespace Roz.I18N.EntityFramework
{
    public interface IEFLocalizedTextProvider: ILocalizedTextProvider {
        void ReloadResourcesCache();
    }
}