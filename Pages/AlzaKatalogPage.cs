using AlzaTestFW_ZB.Pages;
using OpenQA.Selenium;
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
        [FindsBy(How = How.LinkText, Using = "Koupit rozbalené")]
        private IWebElement koupitRozbalene_button { get; set; }
        [FindsBy(How = How.LinkText, Using = "Notebooky a tablety")]
        private IWebElement notebookyATablety_button { get; set; }

        public AlzaKatalogPage clickOnChosenCategory(String categoryName)
        {
            notebookyATablety_button.Click();
            return this;
        }

        public AlzaKatalogPage clickOnOdNejlevnejsihoTabButton()
        {
            odNejlevnejsiho_tabButton.Click();
            return this;
        }

        public AlzaKatalogPage clickOnKoupitFirstProductButton()
        {
            koupitFirstProduct_button.Click();
            if (checkIfElementExists("Koupit rozbalené"))
            {
                koupitRozbalene_button.Click();
            }
            return this;
        }

    }
}
