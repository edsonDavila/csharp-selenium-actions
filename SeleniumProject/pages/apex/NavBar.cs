using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumProject
{
    public class NavBar : PageManageActions
    {
        [FindsBy(How = How.XPath, Using = "(//a[text() = 'What We Do'])[1]")]
        private IWebElement whatWeDoExpandButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Quality and Test Engineering']")]
        private IWebElement QualityAssuranceAndTestingLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Careers']/preceding-sibling::div")]
        private IWebElement CareersExpandButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//nav[@id = 'block-apex-bootstrap-main-navigation']//a[text() = 'Search Jobs']")]
        private IWebElement SearchJobsLink { get; set; }
        public NavBar(ExtentTest test) : base(test)
        {
            PageFactory.InitElements(WebDriverManager.driver, this);
        }

        public void HoverOnWhatWeDoExpandButton()
        {
            HoverElement(whatWeDoExpandButton, "What We Do");
        }

        public void ClickOnQualityAssuranceAndTestingLink()
        {
            WaitUntilElementIsClickableAndClick(QualityAssuranceAndTestingLink, "Quality");
        }

        public void ClickOnCareersExpandButton()
        {
            WaitUntilElementIsClickableAndClick(CareersExpandButton, "Careers");
        }

        public void ClickOnSearchJobsLink()
        {
            WaitUntilElementIsClickableAndClick(SearchJobsLink, "Search Jobs");
        }
    }
}