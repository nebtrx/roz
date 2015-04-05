using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Roz.I18N.Providers.ModelMetadata
{
    public class LocalizedModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly ILocalizedTextProvider _provider;

        public LocalizedModelMetadataProvider(ILocalizedTextProvider provider)
        {
            _provider = provider;
        }

        protected override System.Web.Mvc.ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var attrs = attributes.ToList();
            var metadata = base.CreateMetadata(attrs, containerType, modelAccessor, modelType, propertyName);
            // Avoid extract metadata for the whole object or null object
            if (containerType == null || propertyName == null)
                return metadata;

            if (metadata.DisplayName == null)
            {
                var displayName = attrs.OfType<DisplayNameAttribute>().FirstOrDefault();

                metadata.DisplayName = (displayName != null)
                    ? displayName.DisplayName
                    : _provider.GetText(containerType, propertyName, null, CultureInfo.CurrentCulture);
            }

            if (metadata.Watermark == null)
                metadata.Watermark = _provider.GetText(containerType, propertyName, "Watermark", CultureInfo.CurrentCulture);

            if (metadata.Description == null)
                metadata.Description = _provider.GetText(containerType, propertyName, "Description", CultureInfo.CurrentCulture);

            if (metadata.NullDisplayText == null)
                metadata.NullDisplayText = _provider.GetText(containerType, propertyName, "NullDisplayText", CultureInfo.CurrentCulture);

            if (metadata.ShortDisplayName == null)
                metadata.ShortDisplayName = _provider.GetText(containerType, propertyName, "ShortDisplayName", CultureInfo.CurrentCulture);

            return metadata;
        }
    }
}
