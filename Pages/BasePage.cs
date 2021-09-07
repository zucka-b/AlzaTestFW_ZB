using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Reflection;

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

        public Boolean checkIfElementExists(String xpath)
        {
            int counter = 0;
            do
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    driver.FindElement(By.XPath(xpath));
                    return true;
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is NoSuchElementException || e is TargetInvocationException) { 

                    Console.WriteLine("Could not see element ");
                    Console.WriteLine("Exception:  " + e);
                    }
                
               }
                counter++;
            } while (counter < 3);
            return false;
        }

        public static Boolean ElementIsClickable(IWebElement element)
        {
           
                return (element != null && element.Displayed && element.Enabled);
         
        }

        protected void click(IWebElement webElement)
        {
            int counter = 0;
            do
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        webElement.Click();
                        Console.WriteLine("Clicked on element " + webElement);
                   
                    
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is NoSuchElementException || e is TargetInvocationException)
                    {
                        Console.WriteLine("Could not click on element " + webElement);
                        Console.WriteLine("Exception:  " + e);
                    }
                    else throw e;
                }
                counter++;

            } while (counter < 3);
        }

        protected void input(IWebElement webElement, String value)
        {
            int counter = 0;
            do
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
                    if (ElementIsClickable(webElement))
                    {
                        webElement.Clear();
                        webElement.SendKeys(value);
                        Console.WriteLine("Input value: " + value + " to element " + webElement);
                    }
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is NoSuchElementException) { 

                    Console.WriteLine("Could not click on element " + webElement);
                    Console.WriteLine("Exception:  " + e);
                    }
                }
                counter++;

            } while (counter < 3);
        }

        protected void waitForElementToBePseudo(By by)
        {
            int counter = 0;
            do
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    IWebElement element = driver.FindElement(by);
                    if (element.GetAttribute("innerHTML").Contains("::after") || element.GetAttribute("innerHTML").Contains("::before"))
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is NoSuchElementException)
                    {
                        Console.WriteLine("Could not click on element " + by);
                        Console.WriteLine("Exception:  " + e);
                    }
                }
                counter++;

            } while (counter < 3);
        
        }

        protected void click(By by)
        {
            int counter = 0;
            do
            {
                try
                {
                    waitForElementToBePseudo(by);
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    Actions build = new Actions(driver);
                    build.MoveToElement(driver.FindElement(by)).Click().Build().Perform();
                    Console.WriteLine("Clicked on element " + by);
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is NoSuchElementException)
                    {
                        Console.WriteLine("Could not click on element " + by);
                        Console.WriteLine("Exception:  " + e);
                    }
                }
                counter++;

            } while (counter < 3);
        }

    }
}
