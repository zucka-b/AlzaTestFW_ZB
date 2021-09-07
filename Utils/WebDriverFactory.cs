using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace AlzaTestFW_ZB.Utils
{
    internal class WebDriverFactory
    {

        /** 
         * Using switch - case this method may be extended for use of other browsers.
         */
        public IWebDriver createWebDriverInstance()
        {
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }


    }
}
