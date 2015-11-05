using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    class EnterCompanyName : IComponent
    {
        public EnterCompanyName(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        [FindsBy(How = How.Id, Using = "business-name")]
        private IWebElement _EnterCompanyfield;

        private string companyFinder = "#ui-id-1";

        public void EnterCompanyField(string companyName)
        {
            if (companyName.Length > 5)
            {
                _EnterCompanyfield.SendText(companyName);
            }
            else
            {
                _EnterCompanyfield.SendText(companyName);
                Driver.WaitForElement(By.CssSelector(companyFinder));
                _EnterCompanyfield.SendText(Keys.ArrowDown);
                _EnterCompanyfield.SendText(Keys.Tab);
            }
        }
        public IWebDriver Driver { get; set; }
    }
}
