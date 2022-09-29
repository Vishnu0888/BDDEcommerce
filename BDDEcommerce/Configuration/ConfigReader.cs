using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BDDEcommerce.Configuration
{
    public class ConfigReader
    {

        public static string Browser => ConfigurationManager.AppSettings.Get("Browser");
        public static string Url => ConfigurationManager.AppSettings.Get("URL");


    }
}
