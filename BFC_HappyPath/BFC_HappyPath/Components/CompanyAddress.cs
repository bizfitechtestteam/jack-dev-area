using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class CompanyAddress : IComponent
    {
        public CompanyAddress(IWebDriver driver)
        {
            IWebDriver Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "business-address-1")]
        private IWebElement _companyAddressLine1;
        [FindsBy(How = How.Id, Using = "business-address-town")]
        private IWebElement _companyCity;
        [FindsBy(How = How.Id, Using = "business-address-postcode")]
        private IWebElement _companyPostcode;
        [FindsBy(How = How.CssSelector, Using = ".js-manual-address")]
        private IWebElement _findMyAddress;
        public void EnterManualAddress(string companyLine1,string companyCity,string companyPostcode)
        {
            _findMyAddress.Click();
            _companyAddressLine1.SendText(companyLine1);
            _companyCity.SendText(companyCity);
            _companyPostcode.SendText(companyPostcode);
        }

        public IWebDriver Driver { get; set; }
    }
}
