using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    class EnterLoanAmount : IComponent
    {
        public EnterLoanAmount(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "funding-amount-altered")]
        private IWebElement _EnterLoanField;

        public void EnterLoan(string loanAmount)
        {
            _EnterLoanField.SendText(loanAmount);
        }

        public IWebDriver Driver { get; set; }
    }
}
