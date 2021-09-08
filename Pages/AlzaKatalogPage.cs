using AlzaTestFW_ZB.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace AlzaTestFW_ZB
{
    class AlzaKatalogPage : AlzaBasePage
    {

        public AlzaKatalogPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.LinkText, Using = "Od nejlevnějšího")]
        private IWebElement odNejlevnejsiho_tabButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'first firstRow')]//a[text()='Koupit']")]
        private IWebElement koupitFirstProduct_button { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[@class='alzaDialogButtons']/span[contains(text(),'Koupit')]")]
        private IWebElement koupitInPopup_button { get; set; }
        [FindsBy(How = How.LinkText, Using = "Notebooky a tablety")]
        private IWebElement notebookyATablety_button { get; set; }


        public AlzaKatalogPage ClickOnChosenCategory(String categoryName)
        {
            if (CheckIfElementExists(By.LinkText(categoryName)))
            {
                Click(By.LinkText(categoryName));
                return this;
            }
            else
            {
                throw new Exception("Chosen category is invalid!");
            }
        }

        public AlzaKatalogPage ClickOnOdNejlevnejsihoTabButton()
        {
            String originalUrl = driver.Url;
            Click(odNejlevnejsiho_tabButton);
            WaitForPageToUpdate(originalUrl);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return this;
        }

        public AlzaKatalogPage ClickOnKoupitFirstProductButton()
        { 
            Click(koupitFirstProduct_button);
            if (CheckIfElementExists(By.XPath(".//div[@class='alzaDialogButtons']/span[contains(text(),'Koupit')]")))
            {
                Click(koupitInPopup_button);
            }
            return this;
        }

    }
}
