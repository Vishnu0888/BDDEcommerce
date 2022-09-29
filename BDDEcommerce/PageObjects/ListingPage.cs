using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDDEcommerce.PageObjects
{
    public class ListingPage
    {

        public IWebDriver _driver;

        public ListingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string result = "//article[@id='filter']/section/div";

        [FindsBy(How =How.XPath,Using = "//article[@id='filter']/section/div")]
        public IWebElement ResultsTxt { get; set; }


    }
}
