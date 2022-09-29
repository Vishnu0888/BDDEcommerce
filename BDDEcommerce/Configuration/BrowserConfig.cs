using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace BDDEcommerce.Configuration
{
    public class BrowserConfig
    {

        public static IWebDriver GetBrowserType()
        {
            if (ConfigReader.Browser ==BrowserType.Chrome.ToString())
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--disable-notifications");
               new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                return DriverConfig.driver = new ChromeDriver(options);
            }
            else if (ConfigReader.Browser == BrowserType.Firefox.ToString())
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                return DriverConfig.driver = new FirefoxDriver();
            }
            else 
            {
                new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                return DriverConfig.driver = new InternetExplorerDriver();
            }
        }

        

    }
}
