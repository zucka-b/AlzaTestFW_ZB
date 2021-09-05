using System;
using NUnit.Framework;
using AlzaTestFW_ZB.Utils;
using OpenQA.Selenium;

namespace AlzaTestFW_ZB.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        protected BaseTest()
        {
        }

        [SetUp]
        public void setDriver()
        {           
            driver = new WebDriverManager().runWebDriver();
        }

        [TearDown]
        public void removeDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
