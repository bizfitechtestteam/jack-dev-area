using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverPractice
{
    [TestClass]
    public class HappyPath
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleaup()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void GocontactPage()
        {
            _driver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
        }

        private void FillForm(string _firstName, string _lastName, string _email, string _message)
        {
            IWebElement firstName = _driver.FindElement(By.Id("firstName"));
            var lastName = _driver.FindElement(By.Id("lastName"));
            var email = _driver.FindElement(By.Id("email"));
            var message = _driver.FindElement(By.Id("message"));
            var submitButton = _driver.FindElement(By.Id("gform_submit_button_13"));
            firstName.SendKeys(_firstName);
            lastName.SendKeys(_lastName);
            email.SendKeys(_email);
            message.SendKeys(_message);
            submitButton.Click();
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\nForm Below \nName: " +
                              _firstName + " " + _lastName + "\nEmail: " + _email + "\nMessage: " + _message);
        }

        private void CheckSent()
        {
            var sucessfulMessage = _driver.FindElement(By.Id("gform_confirmation_message_13"));
            Assert.AreEqual(sucessfulMessage.Text,
                ("Thanks for contacting us! We will get in touch with you shortly."));
            Console.WriteLine("Form has been sent successfully!");
        }

        [TestMethod]
        public void ContactUsForm_CompletedWithValidData_Success()
        {
            FillForm
                ("Jack", "Bro", "jack.broughton@bizfitech.com",
                    "Hello, I am unable to gain access to my account could you reset my password please? Thank you!");
            CheckSent();
        }
    }
}