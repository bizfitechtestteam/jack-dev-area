using BFC_HappyPath.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class StartPage : IPage
    {

        public StartPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }
        private EnterLoanAmount EnterLoanAmount => new EnterLoanAmount(Driver);
        private EnterCompanyName EnterCompany => new EnterCompanyName(Driver);
        [FindsBy(How = How.CssSelector, Using = ".c-hero__get-started.c-get-started")]
        private IWebElement _getStartedButton;

        public void Submit()
        {
            _getStartedButton.Submit();
        }

        public void FillOutStartPage(string loanAmount, string companyName)
        {
            EnterLoanAmount.EnterLoan(loanAmount);
            EnterCompany.EnterCompanyField(companyName);
            Submit();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
