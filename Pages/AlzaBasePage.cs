using OpenQA.Selenium;
using System;

namespace AlzaTestFW_ZB.Pages
{
    class AlzaBasePage : BasePage
    {

        private String URL = "https://www.alza.cz/";

        public AlzaBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }


        public AlzaKatalogPage OpenUrl()
        {
            driver.Navigate().GoToUrl(URL);
            return new AlzaKatalogPage(driver);
        }

        public AlzaKosikPage ClickOnKosikButton()
        {
            ClickPseudoelement(By.Id("basketLink"));
            return new AlzaKosikPage(driver);
        }
    }
}
