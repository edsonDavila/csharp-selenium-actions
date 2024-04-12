using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject
{
    public class BaseTest
    {

        public ExtentTest test;

        [SetUp]

        public void initialize()

        {
            WebDriverManager.driver = new ChromeDriver();
        }

        [TearDown]

        public void AfterTest()

        {

            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    DateTime tempTade = DateTime.Now;
                    string timeFormated = tempTade.ToString("MM-dd-yyyy HH-mm-ss-fff");
                    string fileName = timeFormated + ".png";
                    string path = Path.Combine(ExtentSetup.directoryPath, ExtentSetup.screenshotsPath, fileName);
                    Screenshot screenshot = ((ITakesScreenshot)WebDriverManager.driver).GetScreenshot();
                    screenshot.SaveAsFile(path);
                    test.Fail(TestContext.CurrentContext.Result.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("./screenshots/" + fileName).Build());
                    break;
                case TestStatus.Skipped:
                    test.Skip(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test Case Skipped", ExtentColor.Yellow));
                    test.Skip(TestContext.CurrentContext.Result.Message);
                    break;
            }
            WebDriverManager.driver.Quit();


        }

    }

}