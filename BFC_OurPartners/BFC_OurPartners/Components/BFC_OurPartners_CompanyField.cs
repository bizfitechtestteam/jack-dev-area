using BFC_OurPartners.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners
{
    public class BFC_OurPartners_CompanyField : IComponent
    {
        public BFC_OurPartners_CompanyField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        private IWebElement _companyField;
        public void EnterCompanyName(string companyName)
        {
            _companyField.SendText(companyName);
        }

        public void EnterCompanyNameTab(string companyName)
        {
            _companyField.SendKeys(companyName);
            _companyField.SendKeys(Keys.Tab);
        }
    }
}
