using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumProject
{
    public class ContactUsPage : PageManageActions
    {
        [FindsBy(How = How.XPath, Using = "//h1[text() = \"Let's Connect\"]")]
        private IWebElement LetsConnectTitle { get; set; }
        [FindsBy(How = How.Id, Using = "edit-full-name")]
        private IWebElement FullNameInput { get; set; }
        [FindsBy(How = How.Id, Using = "edit-contact-reason")]
        private IWebElement ContactReasonSelect { get; set; }
        [FindsBy(How = How.Id, Using = "edit-email")]
        private IWebElement EmailInput { get; set; }
        [FindsBy(How = How.Id, Using = "edit-area")]
        private IWebElement LocationAreaSelect { get; set; }
        [FindsBy(How = How.Id, Using = "edit-subject")]
        private IWebElement SubjectInput { get; set; }
        [FindsBy(How = How.Id, Using = "edit-message")]
        private IWebElement MessageTextArea { get; set; }

        public ContactUsPage(ExtentTest test) : base(test)
        {
            PageFactory.InitElements(WebDriverManager.driver, this);
        }

        public void TypeFullName(string fullName)
        {
            TypeIntoElement(FullNameInput, "Full Name", fullName);
        }

        public void SelectContactReasonByText(string reasonText)
        {
            SelectOptionByText(ContactReasonSelect, "Contact Reason", reasonText);
        }

        public void SelectContactReasonByValue(string reasonValue)
        {
            SelectOptionByValue(ContactReasonSelect, "Contact Reason", reasonValue);
        }

        public void TypeEmail(string email)
        {
            TypeIntoElement(EmailInput, "Email", email);
        }

        public void SelectLocationByText(string locationText)
        {
            SelectOptionByText(LocationAreaSelect, "Location Area", locationText);
        }

        public void SelectLocationByValue(string locationValue)
        {
            SelectOptionByValue(LocationAreaSelect, "Location Area", locationValue);
        }

        public void TypeSubject(string subject)
        {
            TypeIntoElement(SubjectInput, "Subject", subject);
        }

        public void TypeMessage(string message)
        {
            TypeIntoElement(MessageTextArea, "Message", message);
        }

        public string GetPageName()
        {
            return GetElementText(LetsConnectTitle, "let's connect");
        }
    }
}