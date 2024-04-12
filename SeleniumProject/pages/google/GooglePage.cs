
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SeleniumProject
{
    public class GooglePage : PageManageActions
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchBar{ get; set;}

        [FindsBy(How = How.XPath, Using = "(//h3[text() = 'Apex Systems'])[1]")]
        private IWebElement ApexLink { get; set;} 
        public GooglePage(ExtentTest test) : base(test){
            PageFactory.InitElements(WebDriverManager.driver, this);
        }

        public void TypeOnSearchBar(string text){
            //TODO: add page manage actions
            TypeIntoElement(SearchBar, "Search Bar" ,text + Keys.Enter);
        }

        public string GetLinkText()
        {
            return GetElementText(ApexLink, "Apex Link");
        }
    }
}
