using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace AlzaTestFW_ZB.Pages
{
    class AlzaBasePage : BasePage
    {

        private String URL = "https://www.alza.cz/";

        public AlzaBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.Id, Using = "basketLink")]
        private IWebElement kosik_button { get; set; }


        public AlzaKatalogPage openUrl()
        {
            driver.Navigate().GoToUrl(URL);
            return new AlzaKatalogPage(driver);
        }
        public AlzaKosikPage clickOnKosikButton()
        {
            kosik_button.Click();
            return new AlzaKosikPage(driver);
        }
    }
}
