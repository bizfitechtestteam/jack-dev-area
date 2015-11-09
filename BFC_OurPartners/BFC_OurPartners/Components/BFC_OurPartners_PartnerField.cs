using BFC_OurPartners.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners
{
    public class BFC_OurPartners_PartnerField : IComponent
    {
        public BFC_OurPartners_PartnerField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "lenderPartner")]
        private IWebElement _partnerField;

        public void EnterPartnerField(string partner)
        {
            _partnerField.SendText(partner);
        }

        public void EnterPartnerFieldTab(string partner)
        {
            _partnerField.SendKeys(partner);
            _partnerField.SendKeys(Keys.Tab);
        }
    }
}
