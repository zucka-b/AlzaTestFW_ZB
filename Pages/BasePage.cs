using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace AlzaTestFW_ZB.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public Boolean checkIfElementExists(String elementText)
        {
            try
            {
                driver.FindElement(By.LinkText(elementText));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
