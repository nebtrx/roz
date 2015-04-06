using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Roz.I18N.Providers.LocalizedText
{
    public class LocalizedTextProvider : LocalizedTextProviderBase
    {
        //var r = Assembly.GetExecutingAssembly().GetManifestResourceNames();

        private readonly Lazy<ResourceManager> _resourceManager;

        private readonly Assembly _assembly;

        public LocalizedTextProvider(Assembly assembly)
        {
            _resourceManager = new Lazy<ResourceManager>(CreateResourceManager);
            _assembly = assembly;
        }

        public ResourceManager ResourceManager
        {
            get { return _resourceManager.Value; }
        }

        public override object GetObject(string resourceKey, CultureInfo culture)
        {
            if (this.ResourceManager == null)
                return (object)null;
            
            culture = EnsureCulture(culture);

            try
            {
                return this.ResourceManager.GetObject(resourceKey, culture);
            }
            catch (MissingManifestResourceException)
            {
                return null;
            }
        }

        protected virtual ResourceManager CreateResourceManager()
        {
            return new ResourceManager(String.Concat("Resources.", _assembly.GetName().Name), _assembly)
            {
                IgnoreCase = true,
            };
        }
    }
}
