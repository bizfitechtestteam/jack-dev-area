using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    class PhoneNumber : IComponent
    {
        public PhoneNumber(IWebDriver driver)
        {
            IWebDriver Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "individual-contact-number")]
        private IWebElement _phoneNumber;

        public void EnterPhoneNumber(string phoneNumber)
        {
            _phoneNumber.SendText(phoneNumber);
        }

        public IWebDriver Driver { get; set; }
    }
}
