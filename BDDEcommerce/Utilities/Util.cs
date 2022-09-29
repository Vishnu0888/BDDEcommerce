using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;


namespace BDDEcommerce.Utilities
{
    public class Util
    {

        public static void MoveToControl(IWebElement element, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }


        public static void MoveToElement(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


        public static void WaitForElement(IWebDriver driver,IWebElement elememt)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(elememt));
        }



        public static void WaitForElementVisible(IWebDriver driver, string path)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
        }


        public static void WaitFluent(IWebDriver driver,IWebElement element)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(1);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not Found";
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(element));

        }



        public static void MoveToCoordinate(IWebDriver driver, int x, int y)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(" + x + ", " + y + "); ");
        }



    }
}
