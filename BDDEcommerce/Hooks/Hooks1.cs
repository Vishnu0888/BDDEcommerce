using BDDEcommerce.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDEcommerce.Hooks
{
    [Binding]
    public sealed class Hooks1
    {

        [BeforeFeature]
        public static void BeforeFeature()
        {
            BrowserConfig.GetBrowserType();
            DriverConfig.driver.Url = ConfigReader.Url;
            DriverConfig.driver.Manage().Window.Maximize();
            DriverConfig.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }


        [BeforeScenario]
        public static void BeforeScenario()
        {
           

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            
        }
    }
}
