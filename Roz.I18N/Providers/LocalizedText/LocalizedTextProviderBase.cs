using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Compilation;

namespace Roz.I18N.Providers.LocalizedText
{
    public abstract class LocalizedTextProviderBase : ILocalizedTextProvider, IResourceProvider
    {
        private string GenerateResKey(IEnumerable<string> parts)
        {
            var nonNulls = parts.Where(x => !string.IsNullOrWhiteSpace(x));
            return string.Join("_", nonNulls);
        }

        protected virtual string GetTextInternal(string resourceKey, CultureInfo culture)
        {
            var resourceValue = (string) GetObject(resourceKey.ToLower(), culture);
            // if nothing retrieved, go for the parent culture. 
            // E.g.: nothing for {en-US} then search for {en}
            if (resourceValue == null && culture != CultureInfo.InvariantCulture)
                return (string)GetObject(resourceKey.ToLower(), culture.Parent);

            return resourceValue;
        }

        protected virtual CultureInfo EnsureCulture(CultureInfo culture)
        {
            return culture ?? CultureInfo.CurrentUICulture;
        }

        #region Implementation of IResourceProvider

        public abstract object GetObject(string resourceKey, CultureInfo culture);

        // TODO: Do something about it
        public virtual IResourceReader ResourceReader
        {
            get
            {
                return (IResourceReader)null;
            }
        }

        #endregion

        #region Implementation of ILocalizedTextProvider

        public string GetText(string resourceKey, CultureInfo culture)
        {
            var text = GetTextInternal(resourceKey, culture);

            return text != null
                       ? (String.IsNullOrEmpty(text) ? "{" + resourceKey + "}" : text)
                       : "[" + resourceKey + "]";
        }

        public string GetText(Type type, string propertyName, string metadataName, CultureInfo culture)
        {
            var className = (type != null) ? type.Name : string.Empty;
            string value;
            if (string.IsNullOrWhiteSpace(metadataName))
            {
                // This is usually the Field names' metadata case
                // if metadataName does not exists then
                // to search first for the combination: type_property_metadata, if null
                // to search for property_metadata, if null again then return [ property_metadata ]

                value = GetTextInternal(GenerateResKey(new[] { className, propertyName, metadataName }), culture) ??
                        GetTextInternal(GenerateResKey(new[] { propertyName, metadataName }), culture);
                if (String.IsNullOrEmpty(value))
                {
                    return GetText(GenerateResKey(new[] { propertyName, metadataName }), culture);
                }
            }
            else
            {
                // This is usually the Field validators' messages case
                // if metadataName exists then 
                // to search first for the combination: type_property_metadata, if null
                // then to search for property_metadata if null
                // then to search for just metadata and if null again then return [ metadata ]

                value = (GetTextInternal(GenerateResKey(new[] { className, propertyName, metadataName }), culture) ??
                         GetTextInternal(GenerateResKey(new[] { propertyName, metadataName }), culture)) ??
                        GetTextInternal(metadataName, culture);
                if (String.IsNullOrEmpty(value))
                    return GetText(GenerateResKey(new[] { propertyName, metadataName }), culture);
            }
            return value;
        }

        #endregion
    }
}