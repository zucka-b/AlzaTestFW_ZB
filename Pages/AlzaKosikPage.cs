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


        public AlzaKosikPage clickOnPokracovatButton()
        {

            click(pokracovat_button);
            if (checkIfElementExists(".//div[@class='alzaDialogBody']//span[text()='Nepřidávat nic']"))
            {
                 click(nepridavatNic_button);
            }
            return this;
        }

        public AlzaKosikPage clickOnAlzaShowRoomCheckBox()
        {
            //pseudo
            click(By.XPath(".//label[@for=\"deliveryCheckbox-595\"]"));
            return this;
        }

        public AlzaKosikPage clickOnStandardniVydejRadioButton()
        {

            click(standardniVydej_radioButton);
            click(potvrditVolbu_button);
            return this;
        }

        public AlzaKosikPage clickOnHotoveKartouPriVyzvednutiCheckBox()
        {
            //pseudo
            click(By.XPath(".//div[@id='paymentContainer-101']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return this;
        }

        public AlzaKosikPage inputEmail(String email)
        {
            input(email_textField,email);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            return this;
        }

        public AlzaKosikPage inputTelefon(String telefon)
        {
            waitForElementToBePseudo(By.XPath("//*[@class='inputLabel required'][@for='inpTelNumber']"));
            click(telefon_textField);
            input(telefon_textField,telefon);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return this;
        }

        public AlzaKosikPage clickOnChciDoplnitFakturacniUdajeCheckBox()
        {
            click(doplnitFakturacniUdaje_checkBox);
            return this;
        }

        public AlzaKosikPage inputFakturacniUdaje(String name, String street, String city, String postCode)
        {
            input(jmenoAPrijmeni_textField,name);
            input(uliceACisloPopisne_textField,street);
            input(mesto_textField,city);
            input(psc_textField,postCode);
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
