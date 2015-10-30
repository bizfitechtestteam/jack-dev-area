using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class AddNames : IComponent
    {
        public AddNames(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement _lastNameField;


        public void EnterFirstName(string firstName)
        {
            _firstNameField.SendKey(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _lastNameField.SendKey(lastName);
        }
        public void ClearFirstName()
        {
            _firstNameField.Clear();
        }
        public void ClearLastName()
        {
            _lastNameField.Clear();
        }
        public IWebDriver Driver { get; set; }
    }
}
