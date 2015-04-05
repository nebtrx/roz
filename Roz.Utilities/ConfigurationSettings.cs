using System;
using System.Configuration;

namespace Roz.Web.Settings
{
    public class ConfigurationSettings
    {
        private static readonly ConfigurationSettings _current;

        static ConfigurationSettings()
        {
            _current = new ConfigurationSettings();
        }

        public static ConfigurationSettings Current
        {
            get { return _current; }
        }

        public int PropertyImageWidth
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PropertyImageWidth"] ?? "0");
            }
        }

        public int PropertyImageHeight
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PropertyImageHeight"] ?? "0");
            }
        }

    }
}