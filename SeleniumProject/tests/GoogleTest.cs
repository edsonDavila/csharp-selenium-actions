using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject;

public class GoogleTest : BaseTest
{

    private GooglePage googlePage;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        test = ExtentSetup.extentReports.CreateTest("Test 1");
        googlePage = new GooglePage(test);
        string textToSearch = "Apex Systems";
        WebDriverManager.driver.Navigate().GoToUrl("https://google.com");
        googlePage.TypeOnSearchBar(textToSearch);
        string actualText = googlePage.GetLinkText();
        googlePage.AssertEquals(textToSearch+"s",actualText,"Apex Link Text Are Equals","The Apex link text are not equal");
    }


}