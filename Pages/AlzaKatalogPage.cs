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

        public AlzaKatalogPage clickOnChosenCategory(String categoryName)
        {
            click(notebookyATablety_button);
            return this;
        }

        public AlzaKatalogPage clickOnOdNejlevnejsihoTabButton()
        {
            click(odNejlevnejsiho_tabButton);
            return this;
        }

        public AlzaKatalogPage clickOnKoupitFirstProductButton()
        { 
            click(koupitFirstProduct_button);
            if (checkIfElementExists(".//div[@class='alzaDialogButtons']/span[contains(text(),'Koupit')]"))
            {
                click(koupitInPopup_button);
            }
            return this;
        }

    }
}
