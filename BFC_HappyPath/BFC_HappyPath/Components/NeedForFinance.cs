using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class NeedForFinance : IComponent
    {
        public NeedForFinance(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = ".c-radio__inner.c-radio__inner--inline")]
        private IList<IWebElement> _fundingOptions;

        [FindsBy(How = How.Id, Using = "funding-purpose")]
        private IWebElement _fndingPurposeField;

        public void SelectFundingPurpose(string fundingPurpose)
        {
            foreach (IWebElement fundingPurposeChoice in _fundingOptions.Where(x => x.Text == fundingPurpose))
            {
                fundingPurposeChoice.Click();
            }
        }
        public void OtherFunding(string otherFundingPurpose)
        {
            _fndingPurposeField.SendKeys(otherFundingPurpose);
        }

        public IWebDriver Driver { get; set; }
    }
}
