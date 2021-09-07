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
            Actions build = new Actions(driver);
            build.MoveToElement(driver.FindElement(By.ClassName("alzaico-f-basket"))).Click().Build().Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return new AlzaKosikPage(driver);
        }
    }
}
