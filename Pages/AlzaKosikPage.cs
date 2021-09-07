using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AlzaTestFW_ZB.Pages
{
    class AlzaKosikPage : AlzaBasePage
    {

        public AlzaKosikPage(IWebDriver webDriver) : base(webDriver)
        {
            driver = webDriver;
        }

        [FindsBy(How = How.LinkText, Using = "Pokračovat")]
        private IWebElement pokracovat_button { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[@class='alzaDialogBody']//span[text()='Nepřidávat nic']")]
        private IWebElement nepridavatNic_button { get; set; }
        /*[FindsBy(How = How.CssSelector, Using = ".//div[contains(text(),'Showroom')]/parent::div/preceding-sibling::div[@class='deliveryCheckboxContainer']/label")]
        private IWebElement showRoom_checkBox { get; set; }*/
        [FindsBy(How = How.XPath, Using = ".//div[contains(text(),'Standardní výdej')]/parent::div/preceding-sibling::div[@class='inputContainer']/input")]
        private IWebElement standardniVydej_radioButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Potvrdit volbu")]
        private IWebElement potvrditVolbu_button { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[contains(text(),'Hotově / kartou(při vyzvednutí)')]/parent::div/preceding-sibling::div[@class='paymentCheckboxContainer']/input")]
        private IWebElement hotoveKartou_checkBox { get; set; }
        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement email_textField { get; set; }
        [FindsBy(How = How.Id, Using = "inpTelNumber")]
        private IWebElement telefon_textField { get; set; }
        [FindsBy(How = How.XPath, Using = ".//span[text()='Chci doplnit fakturační údaje']/preceding-sibling::label")]
        private IWebElement doplnitFakturacniUdaje_checkBox { get; set; }
        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement jmenoAPrijmeni_textField { get; set; }
        [FindsBy(How = How.Id, Using = "street")]
        private IWebElement uliceACisloPopisne_textField { get; set; }
        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement mesto_textField { get; set; }
        [FindsBy(How = How.Id, Using = "zip")]
        private IWebElement psc_textField { get; set; }


        public AlzaKosikPage clickOnPokracovatButton()
        {
            pokracovat_button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (checkIfElementExists(".//div[@class='alzaDialogBody']//span[text()='Nepřidávat nic']"))
            {
                nepridavatNic_button.Click();
            }
            return this;
        }

        public AlzaKosikPage clickOnAlzaShowRoomCheckBox()
        {
            Actions build = new Actions(driver);
            build.MoveToElement(driver.FindElement(By.XPath(".//div[contains(text(),'Showroom')]/parent::div/preceding-sibling::div[@class='deliveryCheckboxContainer']/label"))).Click().Build().Perform();
            return this;
        }

        public AlzaKosikPage clickOnStandardniVydejRadioButton()
        {
            standardniVydej_radioButton.Click();
            potvrditVolbu_button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return this;
        }

        public AlzaKosikPage clickOnHotoveKartouPriVyzvednutiCheckBox()
        {
            hotoveKartou_checkBox.Click();
            return this;
        }

        public AlzaKosikPage inputEmail(String email)
        {
           email_textField.SendKeys(email);
            return this;
        }

        public AlzaKosikPage inputTelefon(String telefon)
        {
            telefon_textField.SendKeys(telefon);
            return this;
        }

        public AlzaKosikPage clickOnChciDoplnitFakturacniUdajeCheckBox()
        {
            doplnitFakturacniUdaje_checkBox.Click();
            return this;
        }

        public AlzaKosikPage inputFakturacniUdaje(String name, String street, String city, String postCode)
        {
            jmenoAPrijmeni_textField.SendKeys(name);
            uliceACisloPopisne_textField.SendKeys(street);
            mesto_textField.SendKeys(city);
            psc_textField.SendKeys(postCode);
            return this;
        }

        public Boolean checkInputDataAreValid()
        {
            return (checkElementInputIsValid(email_textField) && checkElementInputIsValid(telefon_textField) && checkElementInputIsValid(psc_textField));
        }

        private Boolean checkElementInputIsValid(IWebElement element)
        {
            return element.GetAttribute("class").Contains("valid");
        }

    }
}
