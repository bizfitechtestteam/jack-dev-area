using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverPractice
{
    internal class ExceptionPath
    {
        /*
            Names <=50
            Emails <=100
            Message ???
        */

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\nTest Started");
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
            Console.WriteLine("Test Ended\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
        }

        [Test]
        public void GocontactPage()
        {
            _driver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/contact");
        }

        public void FillFirstName(string firstName)
        {
            var _firstName = _driver.FindElement(By.Id("firstName"));
            _firstName.SendKeys(firstName);
        }

        public void FillSecondName(string secondName)
        {
            var _secondName = _driver.FindElement(By.Id("lastName"));
            _secondName.SendKeys(secondName);
        }

        public void FillEmail(string emailAddress)
        {
            var _email = _driver.FindElement(By.Id("email"));
            _email.SendKeys(emailAddress);
        }

        public void FillMessage(string messageField)
        {
            var _message = _driver.FindElement(By.Id("message"));
            _message.SendKeys(messageField);
        }

        public void FillForm(string firstName, string secondName, string emailAddress, string messageField)
        {
            FillFirstName(firstName);
            FillSecondName(secondName);
            FillEmail(emailAddress);
            FillMessage(messageField);
            Submit();
        }

        public void CheckSent()
        {
            var sucessfulMessage = _driver.FindElement(By.Id("gform_confirmation_message_13"));
            Assert.That(sucessfulMessage.Text,
                Is.EqualTo("Thanks for contacting us! We will get in touch with you shortly."));
            Console.WriteLine("Form has been sent successfully!");
        }

        public void ErrorMessage()
        {
            var errorMessage = _driver.FindElement(By.Id("error-message"));
            Assert.That(errorMessage.Text,
                Is.EqualTo("There was a problem with your submission. Errors have been highlighted below."));
            Console.WriteLine("General Error Message Alert Fired");
        }

        public void ErrorMessageNoFirstName()
        {
            var errorMessageNoFirst = _driver.FindElement(By.Id("firstName-error"));
            Assert.That(errorMessageNoFirst.Text, Is.EqualTo("This field is required."));
            Console.WriteLine("No First Name Error Message Alert Fired");
        }

        public void ErrorMessageNoSecondName()
        {
            var errorMessageNoSecond = _driver.FindElement(By.Id("lastName-error"));
            Assert.That(errorMessageNoSecond.Text, Is.EqualTo("This field is required."));
            Console.WriteLine("No Second Name Error Message Alert Fired");
        }

        public void ErrorMessageNoEmail()
        {
            var errorMessageNoEmail = _driver.FindElement(By.Id("email-error"));
            Assert.That(errorMessageNoEmail.Text, Is.EqualTo("This field is required."));
            Console.WriteLine("No Email Error Message Alert Fired");
        }

        public void ErrorMessageNoMessage()
        {
            var errorMessageNoMessage = _driver.FindElement(By.Id("message-error"));
            Assert.That(errorMessageNoMessage.Text, Is.EqualTo("This field is required."));
            Console.WriteLine("No Message Error Message Alert Fired");
        }

        public void ErrorInvalidEmail()
        {
            var errorMessageInvEmail = _driver.FindElement(By.Id("email-error"));
            Assert.That(errorMessageInvEmail.Text, Is.EqualTo("Please enter a valid email address."));
            Console.WriteLine("Invalid Email Error Message Alert Fired");
        }

        public void ErrorMessageCharacterFirstName()
        {
            var errorMessageCharacterFirst = _driver.FindElement(By.Id("firstName-error"));
            Assert.That(errorMessageCharacterFirst.Text, Is.EqualTo("Please enter no more than 50 characters."));
            Console.WriteLine("Over 50 Characters First Name Error Message Alert Fired");
        }

        public void ErrorMessageCharacterSecondName()
        {
            var errorMessageCharacterSecond = _driver.FindElement(By.Id("lastName-error"));
            Assert.That(errorMessageCharacterSecond.Text, Is.EqualTo("Please enter no more than 50 characters."));
            Console.WriteLine("Over 50 Characters Second Name Error Message Alert Fired");
        }

        public void ErrorInvalidCharacterEmail()
        {
            var errorMessageInvCharEmail = _driver.FindElement(By.Id("email-error"));
            Assert.That(errorMessageInvCharEmail.Text, Is.EqualTo("Please enter no more than 100 characters."));
            Console.WriteLine("Over 100 Characters Email Error Message Alert Fired");
        }

        public void ErrorMessageAlphaFirstName()
        {
            var errorMessageAlphaFirst = _driver.FindElement(By.Id("firstName-error"));
            Assert.That(errorMessageAlphaFirst.Text, Is.EqualTo("Only Alpha Characters Allowed."));
            Console.WriteLine("Non-Alpha Characters In First Name Error Message Alert Fired");
        }

        public void ErrorMessageAlphaSecondName()
        {
            var errorMessageAlphaSecond = _driver.FindElement(By.Id("lastName-error"));
            Assert.That(errorMessageAlphaSecond.Text, Is.EqualTo("Only Alpha Characters Allowed."));
            Console.WriteLine("Non-Alpha Characters In Second Name Error Message Alert Fired");
        }

        [Test]
        public void Submit()
        {
            var submitButton = _driver.FindElement(By.Id("gform_submit_button_13"));
            submitButton.Click();
            Console.WriteLine("Click Submit");
        }

        [Test]
        public void AllDone()
        {
            FillForm("Jack", "Broughton", "jack.broughton@bizfitech.com",
                "Hello, can you update my profile please? Thanks");
            CheckSent();
        }

        [Test]
        public void TestBlank()
        {
            Submit();
            ErrorMessage();
            ErrorMessageNoFirstName();
            ErrorMessageNoSecondName();
            ErrorMessageNoEmail();
            ErrorMessageNoMessage();
        }

        [Test]
        public void NoFirstName()
        {
            Console.WriteLine("No First Name Test");
            FillSecondName("Broughton");
            FillEmail("jack.broughton@bizfitech.com");
            FillMessage("No First Name");
            Submit();
            ErrorMessage();
            ErrorMessageNoFirstName();
        }

        [Test]
        public void NoSecondName()
        {
            Console.WriteLine("No Second Name Test");
            FillFirstName("Jack");
            FillEmail("jack.broughton@bizfitech.com");
            FillMessage("No Second Name");
            Submit();
            ErrorMessage();
            ErrorMessageNoSecondName();
        }

        [Test]
        public void NoEmail()
        {
            Console.WriteLine("No Email Test");
            FillFirstName("Jack");
            FillSecondName("Broughton");
            FillMessage("No Email");
            Submit();
            ErrorMessage();
            ErrorMessageNoEmail();
        }

        [Test]
        public void NoMessage()
        {
            Console.WriteLine("No Message Test");
            FillFirstName("Jack");
            FillSecondName("Broughton");
            FillEmail("jack.broughton@bizfitech.com");
            Submit();
            ErrorMessage();
            ErrorMessageNoMessage();
        }

        [Test]
        public void InvalidEmail()
        {
            Console.WriteLine("Invalid Email Test");
            FillEmail("jack.broughton.com");
            Submit();
            ErrorInvalidEmail();

            /* ErrorMessage(); 
              Only shows after two submit clicks Intended ?
            */
        }

        [Test]
        public void Char50First()
        {
            Console.WriteLine("50 Characters First Name Test");
            FillForm("JackJackJackJackJackJackJackJackJackJackJackJackJA", "Broughton", "jack.broughton@bizfitech.com",
                "Test Characters");
            CheckSent();
        }

        [Test]
        public void Char50Second()
        {
            Console.WriteLine("50 Characters Second Name Test");
            FillForm("Jack", "JackJackJackJackJackJackJackJackJackJackJackJackJA", "jack.broughton@bizfitech.com",
                "Test Characters");
            CheckSent();
        }

        [Test]
        public void Char100Email()
        {
            Console.WriteLine("100 Characters Email Test");
            FillForm("Jack", "Bro",
                "JjackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJAAjack.broughton@bizfitech.com",
                "Test Characters");
            CheckSent();
        }

        [Test]
        public void CharOver50First()
        {
            Console.WriteLine("Over 50 Characters First Name Test");
            FillForm("JJackJackJackJackJackJackJackJackJackJackJackJackJA", "Broughton", "jack.broughton@bizfitech.com",
                "Test Characters");
            ErrorMessageCharacterFirstName();
        }

        [Test]
        public void CharOver50Second()
        {
            Console.WriteLine("Over 50 Characters Second Name Test");
            FillForm("Jack", "JJackJackJackJackJackJackJackJackJackJackJackJackJA", "jack.broughton@bizfitech.com",
                "Test Characters");
            ErrorMessageCharacterSecondName();
        }

        [Test]
        public void CharOver100Email()
        {
            Console.WriteLine("Over 100 Characters Email Test");
            FillForm("Jack", "Bro",
                "JjJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJAAjack.broughton@bizfitech.com",
                "Test Characters");
            ErrorInvalidCharacterEmail();
        }

        [Test]
        public void ErrorAlphaFirst()
        {
            Console.WriteLine("First Name Contains Non-Alpha Characters Test");
            FillForm("Jack6", "Broughton", "jack.broughton@bizfitech.com", "Test Non Alpha Characters");
            ErrorMessageAlphaFirstName();
        }

        [Test]
        public void ErrorAlphaSecond()
        {
            Console.WriteLine("Second Name Contains Non-Alpha Characters Test");
            FillForm("Jack", "Brough2on", "jack.broughton@bizfitech.com", "Test Non Alpha Characters");
            ErrorMessageAlphaSecondName();
        }
    }
}