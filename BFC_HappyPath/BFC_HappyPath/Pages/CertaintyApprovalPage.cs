using System.Threading;
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
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/button")]
        private IWebElement _seeCertaintyXPath;
        
        [FindsBy(How = How.Id, Using = "individual-dob-year")]
        private IWebElement dobField;



        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string day, string month, string year, string directorAnswer, string industryType,string creditAmount, string cardProvider)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(day,month,year);
            DirectorOfCompany.SelectDirectorCompany(directorAnswer);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount,cardProvider);
            dobField.SendKeys(Keys.Enter);
        }
        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string day, string month, string year, string industryType, string creditAmount, string cardProvider)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(day, month, year);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount, cardProvider);
            _seeCertainty.Click();
        }
        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string day, string month, string year, string directorAnswer)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(day, month, year);
            DirectorOfCompany.SelectDirectorCompany(directorAnswer);
            _seeCertainty.Click();
        }

        public void FillOutCertaintyApproval(string customerAddress1, string customerCity, string customerPostcode, string day, string month, string year)
        {
            _bizAddress.SendText(Keys.Tab);
            CompanyAddress.EnterManualAddress(customerAddress1, customerCity, customerPostcode);
            EnterDOB.FillDOB(day, month, year);
            dobField.SendKeys(Keys.Enter);
        }
        public void FillOutCertaintyApprovalAuto(string customerPostCode, string day, string month, string year, string directorAnswer, string industryType, string creditAmount, string cardProvider)
        {
            CompanyAddress.EnterAutoAddress(customerPostCode);
            EnterDOB.FillDOB(day, month, year);
            DirectorOfCompany.SelectDirectorCompany(directorAnswer);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount, cardProvider);
            dobField.SendKeys(Keys.Enter);
            _seeCertainty.Click();
        }
        public void FillOutCertaintyApprovalAuto(string customerPostCode, string day, string month, string year, string industryType, string creditAmount, string cardProvider)
        {
            CompanyAddress.EnterAutoAddress(customerPostCode);
            EnterDOB.FillDOB(day, month, year);
            YourIndustry.SelectDirectorCompany(industryType);
            CardTerminal.SetCreditAmount(creditAmount, cardProvider);
            _seeCertainty.Click();
        }
        public void FillOutCertaintyApprovalAuto(string customerPostCode, string day, string month, string year, string directorAnswer)
        {
            CompanyAddress.EnterAutoAddress(customerPostCode);
            EnterDOB.FillDOB(day, month, year);
            DirectorOfCompany.SelectDirectorCompany(directorAnswer);
            _seeCertainty.Click();
        }
        public void FillOutCertaintyApprovalAuto(string customerPostcode, string day, string month, string year)
        {
            CompanyAddress.EnterAutoAddress(customerPostcode);
            EnterDOB.FillDOB(day, month, year);
            dobField.SendKeys(Keys.Enter);
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
