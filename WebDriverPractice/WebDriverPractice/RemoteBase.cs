using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace WebDriverPractice
{
    [TestClass]
    public class RemoteBase
    {
        public TestContext TestContext { get; set; }
        
        [DataSource("XmlDataSource"), TestInitialize]
        public void SetUp()
        {
            WebDriver = (RemoteWebDriver)DriverManager.CreateDriver(Convert.ToString(TestContext.DataRow["browser"]),Convert.ToString(TestContext.DataRow["version"]),Convert.ToString(TestContext.DataRow["platform"]));
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMilliseconds(30000));
            WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromMilliseconds(15000));
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(15000));
            WebDriver.Manage().Window.Maximize();

            try
            {
                WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
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
        public RemoteWebDriver WebDriver { get; set; }
        private RemoteDriverManager DriverManager => new RemoteDriverManager();
        public ContactUsPage ContactUsPage => new ContactUsPage(WebDriver);

        //[DataSource("XmlDataSource"), TestMethod]
        //public void ContactUsForm_AllBlank()
        //{
        //    WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
        //}
}
}