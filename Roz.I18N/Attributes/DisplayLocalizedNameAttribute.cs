using System.ComponentModel;
using Roz.I18N.Utilities;

namespace Roz.I18N.Attributes
{
    public class DisplayLocalizedNameAttribute : DisplayNameAttribute
    {
        private readonly string _resourceKey;

        public DisplayLocalizedNameAttribute(string resourceKey)
        {
            _resourceKey = resourceKey;
        }

        public override string DisplayName
        {
            get
            {
                return LocalizedExtensions.GetText(_resourceKey);
            }
        }
    }
}