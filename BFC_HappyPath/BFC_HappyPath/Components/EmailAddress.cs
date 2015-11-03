using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    class EmailAddress : IComponent
    {
        public EmailAddress(IWebDriver driver)
        {
            IWebDriver Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "individual-email-address")]
        private IWebElement _emailAddress;

        public void EnterEmailAddress(string emailAddress)
        {
            _emailAddress.SendText(emailAddress);
        }

        public IWebDriver Driver { get; set; }
    }
}

