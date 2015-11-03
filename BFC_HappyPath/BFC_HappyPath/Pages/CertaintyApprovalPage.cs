using BFC_HappyPath.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class CertaintyApprovalPage : IPage
    {
        private CompanyAddress CompanyAddress => new CompanyAddress(Driver);
        private EnterDOB EnterDOB => new EnterDOB(Driver);
        private DirectorOfCompany DirectorOfCompany => new DirectorOfCompany(Driver);
        private YourIndustry YourIndustry => new YourIndustry(Driver);
        private CardPayment CardPayment => new CardPayment(Driver);
        private CardTerminal CardTerminal => new CardTerminal(Driver);
        public CertaintyApprovalPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }
        [FindsBy(How = How.Id, Using = "business-address")]
        private IWebElement _bizAddress;
        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a.c-questions__btn.is-submit.js-tracking-see-certainty-of-approval.c-btn--tall")]
        private IWebElement _seeCertainty;

        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string DOB, string directorAnswer, string industryType,string creditAmount, string cardProvider)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(DOB);
            DirectorOfCompany.SelectDirectorCompany(directorAnswer);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount,cardProvider);
            _seeCertainty.Click();

        }
        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string DOB, string industryType, string creditAmount, string cardProvider)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(DOB);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount, cardProvider);
            _seeCertainty.Click();

        }
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
