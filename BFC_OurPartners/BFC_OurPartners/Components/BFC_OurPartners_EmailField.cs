using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners.Components
{
    public class BFC_OurPartners_EmailField : IComponent
    {
        public BFC_OurPartners_EmailField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailField;

        public void EnterEmail(string email)
        {
            _emailField.SendText(email);
        }

        public void EnterEmailTab(string email)
        {
            _emailField.SendKeys(email);
            _emailField.SendKeys(Keys.Tab);
        }
    }
}
