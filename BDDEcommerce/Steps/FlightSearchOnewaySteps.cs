using BDDEcommerce.Configuration;
using BDDEcommerce.PageObjects;
using BDDEcommerce.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BDDEcommerce.Steps
{
    [Binding]
    public class FlightSearchOnewaySteps
    {
        LandingPage lp = new LandingPage(DriverConfig.driver);

        ListingPage listp;

        [Given(@"i select round trip")]
        public void GivenISelectRoundTrip()
        {
            Util.WaitForElement(DriverConfig.driver, lp.CookiesCrosslbtn);
            System.Threading.Thread.Sleep(2000);
            lp.CookiesCrosslbtn.Click();
            lp.onewayradio.Click();
        }

        [Given(@"user select origin as ""(.*)""")]
        public void GivenUserSelectOriginAs(string origin)
        {
            
            lp.SelectOriginCity(origin);
        }

        [Given(@"user select destination ""(.*)""")]
        public void GivenUserSelectDestination(string destination)
        {
            lp.SelectDestinationCity(destination);
        }

        [Given(@"user select date as ""(.*)""")]
        public void GivenUserSelectDateAs(string date)
        {

            lp.GetDate(date);

        }


        [Given(@"user click on serach button")]
        public void GivenUserClickOnSerachButton()
        {
           listp =lp.Search();
            Util.WaitForElementVisible(DriverConfig.driver, listp.result);
        }

        [Then(@"user is redirected to listing page")]
        public void ThenUserIsRedirectedToListingPage()
        {
            Assert.IsTrue(listp.ResultsTxt.Text.Contains("results"));
        }




    }
}
