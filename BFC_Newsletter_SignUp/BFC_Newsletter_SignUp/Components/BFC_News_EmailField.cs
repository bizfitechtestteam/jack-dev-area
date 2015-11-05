using BFC_Newsletter_SignUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_Newsletter_SignUp
{
    public class BFC_News_EmailField : IComponent
    {
        public BFC_News_EmailField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailField;

        public IWebDriver Driver { get; set; }

        public void EnterEmailField(string _emailAddress)
        {
            Driver.WaitForElement(By.Id("email"));
            _emailField.SendText(_emailAddress);
        }

    }
}
