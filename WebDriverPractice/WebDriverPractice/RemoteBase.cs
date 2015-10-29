using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    [TestClass]
    public class RemoteBase
    {
        public RemoteWebDriver WebDriver { get; set; }
        public string sentSuccessfullyMessage = "Thanks for contacting us! We will get in touch with you shortly.";
        public string generalErrorMessage = "There was a problem with your submission. Errors have been highlighted below.";
        public string fieldRequiredMessage = "This field is required.";
        public string emailValidMessage = "Please enter a valid email address.";
        public string nonAlphaErrorMessage = "Only Alpha Characters Allowed.";
        public string over50CharsErrorMessage = "Please enter no more than 50 characters.";
        public string over100CharErrorMessage = "Please enter no more than 100 characters.";
        [FindsBy(How = How.Id, Using = "gform_confirmation_message_13")]public IWebElement successfullForm;
        
        public RemoteBase()
        //{
        //    PageFactory.InitElements(WebDriver, this);
        //    IWebElement successfullForm = WebDriver.FindElement(By.Id("gform_confirmation_message_13"));
        //    IWebElement generalError = WebDriver.FindElement(By.Id("error-message"));
        //    IWebElement emailFieldRequiredErrors = WebDriver.FindElement(By.Id("email-error"));
        //    IWebElement firstNameFieldRequiredError = WebDriver.FindElement(By.Id("firstName-error"));
        //    IWebElement lastNameFieldRequiredError = WebDriver.FindElement(By.Id("lastName-error"));
        //    IWebElement messageFieldRequiredError = WebDriver.FindElement(By.Id("message-error"));        

        //}

        private RemoteDriverManager DriverManager => new RemoteDriverManager();
        public ContactUsPage ContactUsPage => new ContactUsPage(WebDriver);
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


       
}
}