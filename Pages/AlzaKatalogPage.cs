using AlzaTestFW_ZB.Pages;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AlzaTestFW_ZB
{
    class AlzaKatalogPage
    {

        IWebDriver driver;

        public AlzaKatalogPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        By odNejlevnejsiho_tabButton = By.LinkText("Od nejlevnějšího");
        By koupitFirstProduct_button = By.XPath(".//div[contains(@class,'first firstRow')]//a[text()='Koupit']");
        By koupitRozbalene_button = By.LinkText("Koupit rozbalené");
        By kosik_button = By.Id("basketLink");
        

        public AlzaKatalogPage clickOnChosenCategory(String categoryName)
        {
            driver.FindElement(By.LinkText(categoryName)).Click();
            return this;
        }

        public AlzaKatalogPage clickOnOdNejlevnejsihoTabButton()
        {
            driver.FindElement(odNejlevnejsiho_tabButton).Click();
            return this;
        }

        public AlzaKatalogPage clickOnKoupitFirstProductButton()
        {
            driver.FindElement(koupitFirstProduct_button).Click();
            if (driver.FindElements(koupitRozbalene_button).Count > 0)
            {
                driver.FindElement(koupitRozbalene_button);
            }
            return this;
        }

        public AlzaKosikPage clickOnKosikButton()
        {
            driver.FindElement(kosik_button).Click();
            return new AlzaKosikPage(driver);
        }

    }
}
