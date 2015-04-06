using System;
using System.Globalization;

namespace Roz.I18N.Providers
{
    public interface ILocalizedTextProvider
    {
        string GetText(string resourceKey, CultureInfo culture);

        string GetText(Type type, string propertyName, string metadataName, CultureInfo culture);
    }
}