using BDDEcommerce.Configuration;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDDEcommerce.PageObjects
{
    public class LandingPage
    {

        public IWebDriver _driver;

       
        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public string _landingpagetitle = "";


        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        public IWebElement siguptxt { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='onetrust-close-btn-container']/button")]
        public IWebElement CookiesCrosslbtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[text()='Consent notice']")]
        public IWebElement footerlinkextra { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Up']")]
        public IWebElement signupbtn { set; get; }



        [FindsBy(How = How.XPath, Using = "//label[@for='onewayTrip']")]
        public IWebElement onewayradio { get; set; }


        [FindsBy(How = How.Id, Using = "from0")]
        public IWebElement originCity { get; set; }


        [FindsBy(How = How.Id, Using = "to0")]
        public IWebElement destinationCity { get; set; }


        [FindsBy(How =How.XPath,Using = "//span[@id='from0autoSuggestLabel']/parent::section/child::div/ul/li/span")]
        public IList<IWebElement> Originlist { get; set; } 


        [FindsBy(How =How.XPath,Using = "//span[@id='to0autoSuggestLabel']/parent::section/child::div/ul/li/span")]
        public IList<IWebElement> Destinationlist { get; set; }

        [FindsBy(How =How.XPath,Using = "//div[@class='widget__input is-active']/a")]
        public IWebElement crosssign { get; set; }


        public string oripath="//span[@id='from0autoSuggestLabel']/parent::section/div/ul";
        public string destinationpath = "//span[@id='to0autoSuggestLabel']/parent::section/div/ul";

        [FindsBy(How =How.XPath,Using = "(//div[@class='calendar__single-month active']/div[@class='calendar__month'])[1]")]
        public IWebElement calendaractive { get; set; }

        


        [FindsBy(How =How.XPath,Using = "//a[@aria-label='Select next month']")]
        public IWebElement arrowicon { get; set; }


        [FindsBy(How =How.CssSelector,Using = "#searchNow")]
        public IWebElement SearchBtn { get; set; }


        public void EnterEmailForSignup(string email)
        {
            siguptxt.SendKeys(email);
        }


        public string GetPageTitle()
        {
            _landingpagetitle = _driver.Title;
            return _landingpagetitle;
        }

       

        public void SelectOriginCity(string origin)
        {
            //if (originCity.GetAttribute("value") != null)
            //{
            //    crosssign.Click();
            //}
            originCity.SendKeys(origin);
            Utilities.Util.WaitForElementVisible(_driver, oripath);
 
            foreach(IWebElement e in Originlist)
            {
                if (e.Text.Trim().Contains(origin))
                {
                    e.Click();
                    break;
                }
            }

        }


        public void SelectDestinationCity(string destination)
        {
            destinationCity.SendKeys(destination);
            Utilities.Util.WaitForElementVisible(_driver, destinationpath);

            foreach (IWebElement e in Destinationlist)
            {
                if (e.Text.Trim().Contains(destination))
                {
                    e.Click();
                }
            }

        }



        public void GetDate(string date)
        {

            string[] datearray= date.Split('-');
            string day = datearray[0];
            string month = datearray[1];
            string year = datearray[2];

            Console.WriteLine(calendaractive.Text);

            while (calendaractive.Text!=(month+" "+year))
            {
                arrowicon.Click();
            }
           IList<IWebElement> datenum=calendaractive.FindElements(By.XPath("//following-sibling::div/div/a"));

            foreach(IWebElement d in datenum)
            {
                if (d.Text.Equals(day))
                {
                    d.Click();
                }
            }


        }

        public ListingPage Search()
        {
            SearchBtn.Click();
            return new ListingPage(_driver);
        }












    }
}
