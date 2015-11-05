using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BFC_Newsletter_SignUp
{
        [TestClass]
        public class TestBase
        {
            public string _validEmailErrorMessage = "Please enter a valid email address.";
            public string _fieldRequiredMessage = "This field is required.";
            public string _thankyouMessage = "Thank you for your subscription";
            public string _notCompleteMessage = "Your subscription could not be completed";

            public IWebDriver WebDriver { get; set; }
            private RemoteDriverManager DriverManager => new RemoteDriverManager();
            public BFC_NewsPage BFC_NewsPage => new BFC_NewsPage(WebDriver);
      
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
                    WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/news/");
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


