using System;
using System.Globalization;

namespace Roz.Utilities
{
    public class SystemSettings
    {
        private static Lazy<SystemSettings> _current = new Lazy<SystemSettings>(() => new SystemSettings());

        private string _tempDirectory = "~/uploaded/temp/";

        private string _userImagesDirectory = "~/uploaded/images/";

        private CultureInfo _defaultCulture = CultureInfo.CreateSpecificCulture("en-GB");

        public void Configure(Action<SystemSettings> configurationAction)
        {
            configurationAction(Current);
        }

        public static SystemSettings Current { get { return _current.Value; } }


        public string TempDirectory
        {
            get { return _tempDirectory; }
            set { _tempDirectory = value; }
        }

        public string UserImagesDirectory
        {
            get { return _userImagesDirectory; }
            set { _userImagesDirectory = value; }
        }

        public CultureInfo DefaultCulture
        {
            get { return _defaultCulture; }
            set { _defaultCulture = value; }
        }

        public ConfigurationSettings Configuration
        {
            get { return ConfigurationSettings.Current; }
        }
    }
}