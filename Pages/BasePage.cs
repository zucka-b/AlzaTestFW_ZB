using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlzaTestFW_ZB.Pages
{
    public abstract class BasePage
    {
        IWebDriver driver;
        //WebDriverWait wait;

        protected BasePage(IWebDriver driver)
        {
            
            
            this.driver = driver;
            //this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        protected void click(IWebElement webElement)
        {
            webElement.Click();
        }

        protected void input(IWebElement webElement, String value)
        {
            webElement.SendKeys(value);
        }

    }
}
