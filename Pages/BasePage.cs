using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AlzaTestFW_ZB.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }


    }
}
