using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject;

public class ApexTest : BaseTest
{

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void ApexTest1()
    {
        test = ExtentSetup.extentReports.CreateTest("Apex Contact Us");
        WebDriverManager.driver.Manage().Window.Maximize();
        WebDriverManager.driver.Navigate().GoToUrl(Data.url);
        ApexPage apexPage = new ApexPage(test);
        apexPage.ClickOnAcceptCookiesButton();

        NavBar navBar = new NavBar(test);
        navBar.HoverOnWhatWeDoExpandButton();
        navBar.ClickOnQualityAssuranceAndTestingLink();

        QualityAssurancePage qualityAssurancePage = new QualityAssurancePage(test);
        qualityAssurancePage.ScrollToConnectWithUsLink();
        qualityAssurancePage.ClickOnConnectWithUsLink();

        ContactUsPage contactUsPage = new ContactUsPage(test);
        string letsConnectText = "Let's Connect"; 
        string contactPageName = contactUsPage.GetPageName();
        contactUsPage.AssertEquals(letsConnectText,contactPageName,"Let's Connect text are equals","Let's Connect text are not equals");

        contactUsPage.TypeFullName(Data.fullname);
        contactUsPage.SelectContactReasonByText(Data.contactReason);
        contactUsPage.TypeEmail(Data.email);
        contactUsPage.SelectLocationByText(Data.location);
        contactUsPage.TypeSubject(Data.messagesubject);
        contactUsPage.TypeMessage(Data.message);
    }


}