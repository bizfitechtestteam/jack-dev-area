using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class BusinessCustomers : IComponent
    {
        public BusinessCustomers(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".c-radio__inner.c-radio__inner--wide")]
        private IList<IWebElement> _businessCustomers;
        public void SetBusinessCustomer(string businessCustomers)
        {
            foreach (IWebElement businessesChoice in _businessCustomers.Where(x => x.Text == businessCustomers))
            {
                businessesChoice.Click();
            }
        }
        public IWebDriver Driver { get; set; }
    }
}
