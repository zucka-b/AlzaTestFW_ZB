using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlzaTestFW_ZB.Utils
{
    internal class WebDriverFactory
    {

        /** 
         * Using switch - case this method may be extended for use of other browsers.
         */
        public IWebDriver createWebDriverInstance()
        {
            return new ChromeDriver("C:\\Users\\Zucka\\source\\repos\\AlzaTestFW_ZB\\WebDriver\\");
        }


    }
}
