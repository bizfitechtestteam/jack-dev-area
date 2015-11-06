using System;
using BFC_OurPartners.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BFC_OurPartners
{
    [TestClass]
    public class TestBase
    {
        public string _generalErrorMessage = "There was a problem with your submission. Errors have been highlighted below.";
        public string _fieldReqErrorMessage = "This field is required.";
        public string _validEmailErrorMessage = "Please enter a valid email address.";
        public string _successfullMessage = "Thanks for contacting us! We will get in touch with you shortly.";
        public IWebDriver WebDriver { get; set; }
        private RemoteDriverManager DriverManager => new RemoteDriverManager();
        public BFC_OurPartners_Page BFC_OurPartners_Page => new BFC_OurPartners_Page(WebDriver);

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
                WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/our-partners");
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


