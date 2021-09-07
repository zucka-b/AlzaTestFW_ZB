using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AlzaTestFW_ZB.Pages
{
    class AlzaBasePage : BasePage
    {

        private String URL = "https://www.alza.cz/";

        public AlzaBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }


        public AlzaKatalogPage openUrl()
        {
            driver.Navigate().GoToUrl(URL);
            return new AlzaKatalogPage(driver);
        }

        public AlzaKosikPage clickOnKosikButton()
        {
            click(By.ClassName("alzaico-f-basket"));
            return new AlzaKosikPage(driver);
        }
    }
}
