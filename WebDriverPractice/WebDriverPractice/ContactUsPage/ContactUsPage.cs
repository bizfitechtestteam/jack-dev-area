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

        [FindsBy(How = How.Id, Using = "error-message")]private IWebElement _generalError;
         
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

        public string FirstNameError()
        {
            return _firstNameFieldRequiredError.Text;
        }
        public string LastNameError()
        {
            return _lastNameFieldRequiredError.Text;
        }
        public string EmailError()
        {
            return _emailFieldRequiredError.Text;
        }
        public string MessageError()
        {
            return _messageFieldRequiredError.Text;
        }
        public string GeneralError()
        {
            return _generalError.Text;
        }

        public string SuccessfullMessage()
        {
            return _generalError.Text;
        }

        public void Submit()
        {
            _contactSubmit.click();
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
        
    }


}