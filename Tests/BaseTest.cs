using System;
using NUnit.Framework;
using AlzaTestFW_ZB.Utils;
using OpenQA.Selenium;

namespace AlzaTestFW_ZB.Tests
{
    public abstract class BaseTest
    {
        internal WebDriverManager manager;
        private String URL;

        protected BaseTest()
        {
        }

        public IWebDriver setDriver()
        {
            WebDriverManager manager = new WebDriverManager();
            this.URL = "https://www.alza.cz/";
            var driver = manager.runWebDriver();
            driver.Navigate().GoToUrl(URL);
            return driver;
        }

        public void removeDriver(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
    }
}
