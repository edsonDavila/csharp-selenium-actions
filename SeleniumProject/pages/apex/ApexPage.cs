using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumProject
{
    public class ApexPage : PageManageActions
    {
        [FindsBy(How = How.XPath, Using = "//button[@data-target = '#navbarSupportedContent']")]
        private IWebElement navBarButton { get; set; }
        [FindsBy(How = How.XPath, Using = "(//a[text() = 'Search'])[1]")]
        private IWebElement searchButton { get; set; }
        [FindsBy(How = How.Id, Using = "edit-sq")]
        private IWebElement searchInput { get; set; }
        [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")]
        private IWebElement cookiesAlert { get; set; }

        public ApexPage(ExtentTest test) : base(test)
        {
            PageFactory.InitElements(WebDriverManager.driver, this);
        }

        public void ClickOnNavBarMenuButton()
        {
            WaitUntilElementIsClickableAndClick(navBarButton, "NavBar button");
        }

        public void ClickOnAcceptCookiesButton()
        {
            WaitUntilElementIsClickableAndClick(cookiesAlert, "Accept Cookies");
        }
    }
}