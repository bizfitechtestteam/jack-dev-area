using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class AddMessage : IComponent
    {
        public AddMessage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement _messageField;

        public void EnterAMessage(string aMessage)
        {
            _messageField.SendKey(aMessage);
        }
        public void ClearAMessage()
        {
            _messageField.Clear();
        }

        public IWebDriver Driver { get; set; }
    }
}
