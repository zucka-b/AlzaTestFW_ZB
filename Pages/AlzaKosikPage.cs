using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AlzaTestFW_ZB.Pages
{
    class AlzaKosikPage
    {

        IWebDriver driver;

        public AlzaKosikPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        By pokracovat_button = By.LinkText("Pokračovat");
        By nepridavatNic_button = By.LinkText("Nepřidávat nic");
        By showRoom_checkBox = By.XPath(".//div[contains(text(),'Showroom')]/parent::div/preceding-sibling::div[@class='deliveryCheckboxContainer']/input");
        By standardniVydej_radioButton = By.XPath(".//div[contains(text(),'Standardní výdej')]/parent::div/preceding-sibling::div[@class='inputContainer']/input");
        By potvrditVolbu_button = By.LinkText("Potvrdit volbu");
        By hotoveKartou_checkBox = By.XPath(".//div[contains(text(),'Hotově / kartou(při vyzvednutí)')]/parent::div/preceding-sibling::div[@class='paymentCheckboxContainer']/input");
        By email_textField = By.Id("userEmail");
        By telefon_textField = By.Id("inpTelNumber");
        By doplnitFakturacniUdaje_checkBox = By.XPath(".//span[text()='Chci doplnit fakturační údaje']/preceding-sibling::label");
        By jmenoAPrijmeni_textField = By.Id("name");
        By uliceACisloPopisne_textField = By.Id("street");
        By mesto_textField = By.Id("city");
        By psc_textField = By.Id("zip");


        public AlzaKosikPage clickOnPokracovatButton()
        {
            driver.FindElement(pokracovat_button).Click();
            if (driver.FindElements(nepridavatNic_button).Count > 0)
            {
                driver.FindElement(nepridavatNic_button).Click();
            }
            return this;
        }

        public AlzaKosikPage clickOnAlzaShowRoomCheckBox()
        {
            driver.FindElement(showRoom_checkBox).Click();
            return this;
        }

        public AlzaKosikPage clickOnStandardniVydejRadioButton()
        {
            driver.FindElement(standardniVydej_radioButton).Click();
            if (driver.FindElements(potvrditVolbu_button).Count > 0)
            {
                driver.FindElement(potvrditVolbu_button).Click();
            }
            return this;
        }

        public AlzaKosikPage clickOnHotoveKartouPriVyzvednutiCheckBox()
        {
            driver.FindElement(hotoveKartou_checkBox).Click();
            return this;
        }

        public AlzaKosikPage inputEmail(String email)
        {
            driver.FindElement(email_textField).SendKeys(email);
            return this;
        }

        public AlzaKosikPage inputTelefon(String telefon)
        {
            driver.FindElement(telefon_textField).SendKeys(telefon);
            return this;
        }

        public AlzaKosikPage clickOnChciDoplnitFakturacniUdajeCheckBox()
        {
            driver.FindElement(doplnitFakturacniUdaje_checkBox).Click();
            return this;
        }

        public AlzaKosikPage inputFakturacniUdaje(String name, String street, String city, String postCode)
        {
            driver.FindElement(jmenoAPrijmeni_textField).SendKeys(name);
            driver.FindElement(uliceACisloPopisne_textField).SendKeys(street);
            driver.FindElement(mesto_textField).SendKeys(city);
            driver.FindElement(psc_textField).SendKeys(postCode);
            return this;
        }

        public Boolean checkInputDataAreValid()
        {
            IWebElement element1 = driver.FindElement(email_textField);
            IWebElement element2 = driver.FindElement(telefon_textField);
            IWebElement element3 = driver.FindElement(psc_textField);

            if (element1.GetAttribute("class").Contains("valid") && element2.GetAttribute("class").Contains("valid") && element3.GetAttribute("class").Contains("valid"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
