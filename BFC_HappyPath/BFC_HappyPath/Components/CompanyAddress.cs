using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class CompanyAddress : IComponent
    {
        public CompanyAddress(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private string fieldCSS= ".pcaitem.pcafirstitem.pcaselected";

        [FindsBy(How = How.CssSelector, Using = ".pcaitem.pcafirstitem.pcaselected")]
        private IWebElement autoAddress;
        [FindsBy(How = How.Id, Using = "business-address")]
        private IWebElement addressField;
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

        public void EnterAutoAddress(string postCode)
        {
            Thread.Sleep(1000);
            addressField.SendKeys(postCode);
            Thread.Sleep(2000);
            addressField.SendKeys(Keys.Space);
            Thread.Sleep(1100);
            addressField.SendKeys(Keys.Enter);

        }
        public IWebDriver Driver { get; set; }
    }
}
