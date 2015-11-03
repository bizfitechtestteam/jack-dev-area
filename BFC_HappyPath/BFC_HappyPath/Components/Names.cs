using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class Names : IComponent
    {
        public Names(IWebDriver driver)
        {
            IWebDriver Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "individual-first-name")]
        private IWebElement _firstName;
        [FindsBy(How = How.Id, Using = "individual-last-name")]
        private IWebElement _lastName;

        public void EnterNames(string firstName, string lastName)
        {
            _firstName.SendText(firstName);
            _lastName.SendKeys(lastName);
        }

        public IWebDriver Driver { get; set; }
    }
}
