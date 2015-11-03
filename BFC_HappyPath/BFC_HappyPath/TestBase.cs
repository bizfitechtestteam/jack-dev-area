using System;
using BFC_HappyPath.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BFC_HappyPath
{
    [TestClass]
    public class TestBase
    {

        public IWebDriver WebDriver { get; set; }
        private RemoteDriverManager DriverManager => new RemoteDriverManager();
        public StartPage StartPage => new StartPage(WebDriver);
        public YourBusinessPage YourBusinessPage => new YourBusinessPage(WebDriver);
        public AboutYouPage AboutYouPage => new AboutYouPage(WebDriver);
        public YourMatchesPage YourMatchesPage => new YourMatchesPage(WebDriver);
        public CertaintyApprovalPage CertaintyApprovalPage => new CertaintyApprovalPage(WebDriver);
        public TestContext TestContext { get; set; }
        [DataSource("XmlDataSource"), TestInitialize]
        public void SetUp()
        {
            WebDriver = (RemoteWebDriver)DriverManager.CreateDriver(Convert.ToString(TestContext.DataRow["browser"]), Convert.ToString(TestContext.DataRow["version"]), Convert.ToString(TestContext.DataRow["platform"]));
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMilliseconds(30000));
            WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromMilliseconds(15000));
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(15000));
            WebDriver.Manage().Window.Maximize();

            try
            {
                WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/start");
            }
            catch (WebDriverTimeoutException)
            {
                WebDriver.Dispose();
                Assert.Fail("The driver timed out attempting to load the page.");

            }
        }

        [TestCleanup]
        public void Teardown()
        {
            WebDriver.Dispose();
        }

    }
}
