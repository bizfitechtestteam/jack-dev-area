using BFC_HappyPath.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class AboutYouPage : IPage
    {
        public AboutYouPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }
        private Names Names => new Names(Driver);
        private PhoneNumber PhoneNumber => new PhoneNumber(Driver);
        private EmailAddress EmailAddress => new EmailAddress(Driver);

        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a.c-questions__btn.js-tracking-see-my-matches")]
        private IWebElement _seeMatchesButton;

        public void FillOutAboutYouPage(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Names.EnterNames(firstName, lastName);
            EmailAddress.EnterEmailAddress(emailAddress);
            PhoneNumber.EnterPhoneNumber(phoneNumber);
            _seeMatchesButton.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
