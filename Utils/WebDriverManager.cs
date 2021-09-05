using OpenQA.Selenium;
using System;

namespace AlzaTestFW_ZB.Utils
{
    internal class WebDriverManager
    {
        private WebDriverFactory webDriverFactory;

        public WebDriverManager() : this(new WebDriverFactory())
        {
        }

        internal WebDriverManager(WebDriverFactory factory)
        {
            this.webDriverFactory = factory;
        }
      
        public IWebDriver runWebDriver()
        {
            IWebDriver driver = webDriverFactory.createWebDriverInstance();
            driver.Manage().Window.Maximize();
            return driver;
        }
      
       
    }
}
