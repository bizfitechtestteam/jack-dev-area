using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class ContactUsPage : IPage
    {
        [FindsBy(How = How.Id, Using = "gform_submit_button_13")] private IWebElement _contactSubmit;

        [FindsBy(How = How.Id, Using = "email-error")] private IWebElement _emailFieldRequiredError;

        [FindsBy(How = How.Id, Using = "firstName-error")] private IWebElement _firstNameFieldRequiredError;

        [FindsBy(How = How.Id, Using = "lastName-error")] private IWebElement _lastNameFieldRequiredError;

        [FindsBy(How = How.Id, Using = "message-error")] private IWebElement _messageFieldRequiredError;

        public ContactUsPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);

        }

        private AddNames AddNames => new AddNames(Driver); // Create new Name OBJ
        private AddEmailAddress AddEmailAddress => new AddEmailAddress(Driver);
        private AddMessage AddMessage => new AddMessage(Driver);
        public IWebDriver Driver { get; set; }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
        public void Submit()
        {
            _contactSubmit.Click();
        }


        public void FillContactUsForm(string firstName, string lastName, string emailAddress, string aMessage)
        {
            AddNames.EnterFirstName(firstName);
            AddNames.EnterLastName(lastName);
            AddEmailAddress.EnterEmailAddress(emailAddress);
            AddMessage.EnterAMessage(aMessage);
        }

        public void ClearContactUsForm()
        {
            AddNames.ClearFirstName();
            AddNames.ClearLastName();
            AddEmailAddress.ClearEmailAddress();
            AddMessage.ClearAMessage();
        }

        public void ContactUsForm_SentSuccessfully()
        {
            var errorMessage = Driver.FindElement(By.Id("gform_confirmation_message_13"));
            Assert.AreEqual(errorMessage.Text, ("Thanks for contacting us! We will get in touch with you shortly."));
        }

        public void ContactUsForm_GeneralError()
        {
            var generalErrorMessage = Driver.FindElement(By.Id("error-message"));
            Assert.AreEqual(generalErrorMessage.Text,
                ("There was a problem with your submission. Errors have been highlighted below."));
        }

        public void ContactUsForm_FirstName_FieldRequiredError()
        {
            Assert.AreEqual(_firstNameFieldRequiredError.Text, ("This field is required."));
        }

        public void ContactUsForm_LastName_FieldRequiredError()
        {
            Assert.AreEqual(_lastNameFieldRequiredError.Text, ("This field is required."));
        }

        public void ContactUsForm_Email_FieldRequiredError()
        {
            Assert.AreEqual(_emailFieldRequiredError.Text, ("This field is required."));
        }

        public void ContactUsForm_Message_FieldRequiredError()
        {
            Assert.AreEqual(_messageFieldRequiredError.Text, ("This field is required."));
        }

        public void ContactUsForm_Email_ValidRequiredError()
        {
            Assert.AreEqual(_emailFieldRequiredError.Text, ("Please enter a valid email address."));
        }

        public void ContactusForm_FirstName_NonAlphaError()
        {
            Assert.AreEqual(_firstNameFieldRequiredError.Text, ("Only Alpha Characters Allowed."));
        }

        public void ContactusForm_LastName_NonAlphaError()
        {
            Assert.AreEqual(_lastNameFieldRequiredError.Text, ("Only Alpha Characters Allowed."));
        }

        public void ContactusForm_FirstName_OverMaxCharsError()
        {
            Assert.AreEqual(_firstNameFieldRequiredError.Text, ("Please enter no more than 50 characters."));
        }

        public void ContactusForm_LastName_OverMaxCharsError()
        {
            Assert.AreEqual(_lastNameFieldRequiredError.Text, ("Please enter no more than 50 characters."));
        }

        public void ContactusForm_Email_OverMaxCharsError()
        {
            Assert.AreEqual(_emailFieldRequiredError.Text, ("Please enter no more than 100 characters."));
        }
    }
}