using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumProject
{
    public class QualityAssurancePage : PageManageActions
    {
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'view-leadership')]//a[@href = '/contact-us'])[2]")]
        private IWebElement ConnectWithUsLink { get; set; }
        public QualityAssurancePage(ExtentTest test) : base(test)
        {
            PageFactory.InitElements(WebDriverManager.driver, this);
        }

        public void ScrollToConnectWithUsLink()
        {
            ScrollToElement(ConnectWithUsLink, "Connect with us");
        }

        public void ClickOnConnectWithUsLink()
        {
            WaitUntilElementIsClickableAndClick(ConnectWithUsLink, "Connect with us");
        }
    }
}