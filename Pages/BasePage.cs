using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

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

        protected void WaitForPageToUpdate(String originalUrl)
        {
            int counter = 0;
            while (counter < 5)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                String newUrl = driver.Url;
                if (!(newUrl.Equals(originalUrl)))
                {
                    Console.WriteLine("Page updated from "+originalUrl+" to "+newUrl);
                    break;
                }
                else
                {
                    WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    counter++;
                    Console.WriteLine("Waiting for page to update");
                }
            };
            if(counter >= 5)
            {
                throw new NoSuchWindowException("Page not reloaded after wait");
            }
        }

        protected Boolean CheckIfElementExists(By by)
        {
            try
            {
                WaitForElementToBeClickable(driver.FindElement(by));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:  " + e);
                return false;
            }
        }

        protected void WaitForElementToBePresent(IWebElement webElement)
        {
            int counter = 0;
            while (counter < 3)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    if (webElement != null && webElement.Displayed)
                    {
                        Console.WriteLine("Found element " + webElement);
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is NoSuchElementException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not see element ");
                        Console.WriteLine("Exception:  " + e);
                    }
                    else throw new NoSuchElementException("Element " + webElement + " does not exist");
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Element " + webElement + " does not exist after wait");
            }
        }

        protected void WaitForElementToBeClickable(IWebElement webElement)
        {
            int counter = 0;
            while(counter<3)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    if (webElement != null && webElement.Displayed && webElement.Enabled)
                    {
                        Console.WriteLine("Found element "+webElement);
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not see element ");
                        Console.WriteLine("Exception:  " + e);
                    }
                    else throw new NoSuchElementException("Element " + webElement + " does not exist");
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Element " + webElement + " does not exist after wait");
            }
        }

        
        protected void Click(IWebElement webElement)
        {
            int counter = 0;
            while (counter < 3)
            {
                try
                {
                    WaitForElementToBeClickable(webElement);
                    webElement.Click();
                    Console.WriteLine("Clicked on element " + webElement);
                    break;
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not click on element " + webElement);
                        Console.WriteLine("Exception:  " + e);
                    }
                    else if (e is NoSuchElementException || e is TimeoutException)
                    {
                        throw new NoSuchElementException("Element " + webElement + " does not exist");
                    }
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Could not click on " + webElement + " after wait");
            }
        }


        protected void Click(By by)
        {
            int counter = 0;
            while (counter < 3)
            {
                try
                {
                    WaitForElementToBeClickable(driver.FindElement(by));
                    driver.FindElement(by).Click();
                    Console.WriteLine("Clicked on element " + by);
                    break;
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not click on element " + by);
                        Console.WriteLine("Exception:  " + e);
                    }
                    else if (e is NoSuchElementException || e is TimeoutException)
                    {
                        throw new NoSuchElementException("Element " + by + " does not exist");
                    }
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Could not click on element " + by + " after wait");
            }
        }


        protected void ClickPseudoelement(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", driver.FindElement(by));
                Console.WriteLine("Clicked on element " + by);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not click on element " + by);
                Console.WriteLine("Exception:  " + e);
            }
        }


        protected void WaitForPseudoElement(By by)
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
            throw new Exception("Element not found");
        }


        protected void Input(IWebElement webElement, String value)
        {
            int counter = 0;
            do
            {
                try
                {
                    WaitForElementToBeClickable(webElement);
                    webElement.Clear();
                    webElement.SendKeys(value);
                    Console.WriteLine("Input value "+value+" to element " + webElement);
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not input to element " + webElement);
                        Console.WriteLine("Exception:  " + e);
                    }
                    else if (e is NoSuchElementException || e is TimeoutException)
                    {
                        throw new NoSuchElementException("Element " + webElement + " does not exist");
                    }
                }
            } while (counter < 3);
            if (counter >= 3)
            {
                throw new NoSuchElementException("Could not input to " + webElement + " after wait");
            }
        }
    }
}
