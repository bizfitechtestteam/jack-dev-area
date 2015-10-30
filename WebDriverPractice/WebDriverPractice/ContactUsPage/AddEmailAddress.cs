using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class AddEmailAddress : IComponent
    {
        public AddEmailAddress(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailAddressField;
        
        public void EnterEmailAddress(string emailAddress)
        {
            _emailAddressField.SendKey(emailAddress);
        }
        public void ClearEmailAddress()
        {
            _emailAddressField.Clear();
        }
        public IWebDriver Driver { get; set; }
    }
}
