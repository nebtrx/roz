using System.Reflection;
using System.Web.Mvc;
using Roz.I18N.Providers;
using Roz.I18N.Providers.LocalizedText;
using Roz.I18N.Providers.ModelMetadata;
using Roz.I18N.Providers.ModelValidator;

namespace Roz.I18N
{
    public static class I18NConfig
    {
        public static void RegisterLocalizedDataAnotationsProviders()
        {
            var localizedTextProvider = DependencyResolver.Current.GetService<ILocalizedTextProvider>() ??
                                        new LocalizedTextProvider(Assembly.GetCallingAssembly());

            // redefined the DataAnnotationsModelMetadataProvider
            ModelMetadataProviders.Current = new LocalizedModelMetadataProvider(localizedTextProvider);

            // redefined the DataAnnotationsModelValidatorProvider
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(new LocalizedModelValidatorProvider(localizedTextProvider));
        }
    }
}
