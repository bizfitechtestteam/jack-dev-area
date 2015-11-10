using BFC_OurPartners.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners
{
    class BFC_OurPartners_MessageField : IComponent
    {
        public BFC_OurPartners_MessageField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement _messageField;

        public void EnterMessage(string message)
        {
            _messageField.SendText(message);
            _messageField.SendKeys(Keys.PageDown);
        }
        public void EnterMessageTab(string message)
        {
            _messageField.SendKeys(message);
            _messageField.SendKeys(Keys.Tab);
        }
    }
}
