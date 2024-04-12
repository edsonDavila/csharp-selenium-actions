using System.Runtime.Intrinsics.X86;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Page;

namespace SeleniumProject
{
    [SetUpFixture]
    public class ExtentSetup
    {
        public static ExtentReports extentReports;
        public static ExtentSparkReporter sparkReporter;
        public static string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static string screenshotsPath = Path.Combine("test-output", "screenshots");
        [OneTimeSetUp]
        public void SetUp()
        {
            if (!File.Exists(Path.Combine(directoryPath, "test-output")))
            {
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.CreateSubdirectory("test-output");

                if (!File.Exists(Path.Combine(directoryPath, screenshotsPath)))
                {
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.CreateSubdirectory(screenshotsPath);
                }
            }

            extentReports = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(Path.Combine(directoryPath, @"test-output\report.html"));
            sparkReporter.LoadJSONConfig(Path.Combine(directoryPath, @"tests\resources\spark-config.json"));
            extentReports.AttachReporter(sparkReporter);

        }


        [OneTimeTearDown]
        public void ExtentFlush()
        {
            extentReports.Flush();
        }

    }
}