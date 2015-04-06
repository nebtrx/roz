using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Roz.I18N.Providers.ModelValidator
{
    public class LocalizedModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        private readonly Dictionary<string, string> _dicResources = new Dictionary<string, string>();

        private readonly ILocalizedTextProvider _localizedTextProvider;

        public LocalizedModelValidatorProvider(ILocalizedTextProvider localizedTextProvider)
        {
            _localizedTextProvider = localizedTextProvider;
        }

        protected override IEnumerable<System.Web.Mvc.ModelValidator> GetValidators(System.Web.Mvc.ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            IList<string> attrs = new List<string>();
            foreach (var item in attributes)
            {
                if (item is ValidationAttribute)
                {
                    ValidationAttribute validationAttribute = item as ValidationAttribute;

                    string resourceName = validationAttribute.ErrorMessageResourceName;
                    if (!String.IsNullOrEmpty(resourceName))
                    {
                        if (metadata.ContainerType != null)
                        {
                            string metadataName = metadata.ContainerType.Name;
                            string propertyName = metadata.PropertyName;
                            string validationAttributeName = validationAttribute.GetType().Name;
                            string key = String.Concat(metadataName, ".", propertyName, ".", validationAttributeName);
                            if (!_dicResources.ContainsKey(key))
                            {
                                _dicResources.Add(key, validationAttribute.ErrorMessageResourceName);
                            }
                        }
                        validationAttribute.ErrorMessage = _localizedTextProvider.GetText(resourceName, CultureInfo.CurrentCulture);
                        validationAttribute.ErrorMessageResourceName = String.Empty;
                    }
                    else
                    {
                        if (metadata.ContainerType != null)
                        {
                            string metadataName = metadata.ContainerType.Name;
                            string propertyName = metadata.PropertyName;
                            string validationAttributeName = validationAttribute.GetType().Name;
                            string key = String.Concat(metadataName, ".", propertyName, ".", validationAttributeName);
                            if (_dicResources.ContainsKey(key))
                            {
                                validationAttribute.ErrorMessage = _localizedTextProvider.GetText(_dicResources[key], CultureInfo.CurrentCulture);
                            }
                        }
                    }
                }
            }
            var result = base.GetValidators(metadata, context, attributes);
            return result;
        }
    }
}