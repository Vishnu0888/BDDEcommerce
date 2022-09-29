using BDDEcommerce.Configuration;
using BDDEcommerce.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using BDDEcommerce.Utilities;

namespace BDDEcommerce.Steps
{
    [Binding]
    public class SignUpSteps
    {
      
       
        LandingPage lp = new LandingPage(DriverConfig.driver);
        
        [Given(@"User is on landing page")]
        public void GivenUserIsOnLandingPage()
        {
            Assert.IsTrue(lp.GetPageTitle().Contains("Book Cheap Flight"));
        }
        [Given(@"user navigate to Email control")]
        public void GivenUserNavigateToEmailControl()
        {
           
           Util.WaitForElement(DriverConfig.driver, lp.CookiesCrosslbtn);
            System.Threading.Thread.Sleep(2000);
            lp.CookiesCrosslbtn.Click();
            Util.MoveToElement(lp.siguptxt, DriverConfig.driver);
            Util.WaitForElement(DriverConfig.driver, lp.siguptxt);
   
        }
        [Given(@"user enter valid email (.*)")]
        public void GivenUserEnterValidEmail(string email)
        {
            lp.siguptxt.SendKeys(email);
            lp.siguptxt.SendKeys(Keys.Enter);
        }
        [Given(@"user click on Signup button")]
        public void GivenUserClickOnSignupButton()
        {
            Util.MoveToElement(lp.signupbtn, DriverConfig.driver);
           // Util.MoveToCoordinate(DriverConfig.driver, 0, 500);
            Util.WaitForElement(DriverConfig.driver, lp.signupbtn);
            System.Threading.Thread.Sleep(5000);
            lp.signupbtn.Click();
        }





    }
}
