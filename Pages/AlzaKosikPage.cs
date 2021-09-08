using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
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
        [FindsBy(How = How.XPath, Using = ".//div[contains(text(),'Standardní výdej')]/parent::div/preceding-sibling::div[@class='inputContainer']/input")]
        private IWebElement standardniVydej_radioButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Potvrdit volbu")]
        private IWebElement potvrditVolbu_button { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[contains(text(),'Hotově / kartou(při vyzvednutí)')]/parent::div/preceding-sibling::div[@class='paymentCheckboxContainer']/input")]
        private IWebElement hotoveKartou_checkBox { get; set; }
        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement email_textField { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[@class='blPhoneCountryPrefix']/input[@id='inpTelNumber']")]
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
        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Zvolte dopravu')]")]
        private IWebElement zvolteDopravu_label { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Zvolte platbu')]")]
        private IWebElement zvoltePlatbu_label { get; set; }


        public AlzaKosikPage ClickOnPokracovatButton()
        {
            Click(pokracovat_button);
            if (CheckIfElementExists(By.XPath(".//div[@class='alzaDialogBody']//span[text()='Nepřidávat nic']")))
            {
                 Click(nepridavatNic_button);
            }
            return this;
        }

        public AlzaKosikPage ClickOnAlzaShowRoomCheckBox()
        {
            WaitForElementToBePresent(zvolteDopravu_label);
            ClickPseudoelement(By.XPath(".//div[contains(@id,'deliveryContainer-595')]"));
            return this;
        }

        public AlzaKosikPage ClickOnStandardniVydejRadioButton()
        {
            Click(standardniVydej_radioButton);
            Click(potvrditVolbu_button);
            return this;
        }

        public AlzaKosikPage ClickOnHotoveKartouPriVyzvednutiCheckBox()
        {
            WaitForElementToBePresent(zvoltePlatbu_label);
            ClickPseudoelement(By.XPath(".//div[@id='paymentContainer-101']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return this;
        }

        public AlzaKosikPage InputEmail(String email)
        {
            Input(email_textField,email);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return this;
        }

        public AlzaKosikPage InputTelefon(String telefon)
        {
            WaitForPseudoElement(By.XPath("//*[@class='inputLabel required'][@for='inpTelNumber']"));
            Click(telefon_textField);
            Input(telefon_textField,telefon);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return this;
        }

        public AlzaKosikPage ClickOnChciDoplnitFakturacniUdajeCheckBox()
        {
            Click(doplnitFakturacniUdaje_checkBox);
            return this;
        }

        public AlzaKosikPage InputFakturacniUdaje(String name, String street, String city, String postCode)
        {
            Input(jmenoAPrijmeni_textField,name);
            Input(uliceACisloPopisne_textField,street);
            Input(mesto_textField,city);
            Input(psc_textField,postCode);
            return this;
        }

        public Boolean CheckInputDataAreValid()
        {
            return (CheckElementInputIsValid(email_textField) && CheckElementInputIsValid(telefon_textField) && CheckElementInputIsValid(psc_textField));
        }

        private Boolean CheckElementInputIsValid(IWebElement element)
        {
            return element.GetAttribute("class").Contains("valid");
        }

    }
}
