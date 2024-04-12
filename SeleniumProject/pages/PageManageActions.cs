using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumProject
{
    public class PageManageActions
    {
        private ExtentTest test;
        private WebDriverWait webDriverWait;
        private IJavaScriptExecutor js;
        private Actions actions;
        public PageManageActions(ExtentTest test)
        {
            this.test = test;
            webDriverWait = new WebDriverWait(WebDriverManager.driver, TimeSpan.FromSeconds(30.0));
            js = (IJavaScriptExecutor)WebDriverManager.driver;
            actions = new Actions(WebDriverManager.driver);
        }

        protected void WaitUntilElementIsClickableAndClick(IWebElement element, string elementDescription)
        {
            try
            {
                //test.info("waiting until " + elementDescription + "is visible");
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.Click();
                test.Pass("CLICKED -- " + elementDescription);
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. " + elementDescription + " Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
            catch (ElementClickInterceptedException)
            {
                test.Fail(elementDescription + " Element was intercepted by another element in the page");
                throw;
            }
        }

        protected void ScrollToElement( IWebElement element, string elementDescription)
        {
            try
            {
                WebDriverWait wdw2;
                Boolean exit = true;
                while (exit)
                {
                    try
                    {
                        wdw2 = new WebDriverWait(WebDriverManager.driver, TimeSpan.FromSeconds(0.5));
                        wdw2.Until(ExpectedConditions.ElementToBeClickable(element));
                        exit = false;
                    }
                    catch (Exception)
                    {
                        js.ExecuteScript("window.scrollBy(0,300)");
                    }
                }
                test.Pass("SCROLL to " + elementDescription + " element");
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }
        protected void TypeIntoElement(IWebElement element, string elementDescription, string text)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.SendKeys(text);
                test.Pass("TYPE -- " + elementDescription + " -- " + text);
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail(" Time to locate" + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }

        protected void SelectOptionByText( IWebElement element, string elementDescription, string text)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                SelectElement select = new SelectElement(element);
                select.SelectByText(text);
                test.Pass("Selected " + text + " option into " + elementDescription + " element");
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + "Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }

        protected void SelectOptionByValue( IWebElement element, string elementDescription, string value)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                SelectElement select = new SelectElement(element);
                select.SelectByValue(value);
                test.Pass("Selected " + value + " option into " + elementDescription + " element");
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }

        protected string GetElementText( IWebElement element, string elementDescription)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                string elementText = element.Text;
                test.Pass("Obtained '" + elementText + "' text from " + elementDescription + " element");
                return elementText;
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }
        protected string GetElementTextJS( IWebElement element, string elementDescription)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5.0));
                string elementText = (string)js.ExecuteScript("return arguments[0].innerText;", element);
                test.Pass("Obtained '" + elementText + "' text from " + elementDescription + " element");
                return elementText;
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }

        protected void HoverElement( IWebElement element, string elementDescription)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
                actions.MoveToElement(element).Perform();
                test.Pass("HOVER -- " + elementDescription + " element");
            }
            catch (NoSuchElementException)
            {
                test.Fail(elementDescription + " Element not Located");
                throw;
            }
            catch (TimeoutException)
            {
                test.Fail("Time to locate " + elementDescription + " finished. Search bar Element not Located");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                test.Fail(elementDescription + " Element not found on DOM");
                throw;
            }
        }

        protected void Wait(double seconds)
        {
            WebDriverManager.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            test.Pass("waiting for " + seconds + " seconds");
        }

        protected void WaitThread(double seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            test.Pass("waiting for " + seconds + " seconds");
        }

        public void AssertEquals(object expected, object actual,string passMessage,string failMessage){
            Assert.That(actual, Is.EqualTo(expected),failMessage);
            test.Pass(MarkupHelper.CreateCodeBlock(passMessage + 
            "\n Expected: '"+ expected +
            "'\n Actual: '"+ actual +"'"));
        }

    }
}