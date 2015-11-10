using BFC_OurPartners.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners.Pages
{
    public class BFC_OurPartners_Page :IPage
    {

        [FindsBy(How = How.Id, Using = "gform_submit_button_15")]
        private IWebElement _submitButton;
        [FindsBy(How = How.Id, Using = "gform_confirmation_message_15")]
        private IWebElement _confirmationMessage;
        [FindsBy(How = How.CssSelector, Using = ".btn.cb-enable")]
        private IWebElement _cookieOkay;

        [FindsBy(How = How.Id, Using = "error-message")]
        private IWebElement _generalError;
        [FindsBy(How = How.Id, Using = "name-error")]
        private IWebElement _nameError;
        [FindsBy(How = How.Id, Using = "company-error")]
        private IWebElement _companyError;
        [FindsBy(How = How.Id, Using = "email-error")]
        private IWebElement _emailError;
        [FindsBy(How = How.Id, Using = "lenderPartner-error")]
        private IWebElement _partnerError;
        [FindsBy(How = How.Id, Using = "subject-error")]
        private IWebElement _subjectError;
        [FindsBy(How = How.Id, Using = "message-error")]
        private IWebElement _messageError;
        private BFC_OurPartners_NameField BFC_OurPartners_NameField => new BFC_OurPartners_NameField(Driver);
        private BFC_OurPartners_CompanyField BFC_OurPartners_CompanyField => new BFC_OurPartners_CompanyField(Driver);
        private BFC_OurPartners_EmailField BFC_OurPartners_EmailField => new BFC_OurPartners_EmailField(Driver);
        private BFC_OurPartners_PartnerField BFC_OurPartners_PartnerField => new BFC_OurPartners_PartnerField(Driver);
        private BFC_OurPartners_SubjectField BFC_OurPartners_SubjectField => new BFC_OurPartners_SubjectField(Driver);
        private BFC_OurPartners_MessageField BFC_OurPartners_MessageField => new BFC_OurPartners_MessageField(Driver);

        public IWebDriver Driver { get; set; }
        public BFC_OurPartners_Page(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public void ClickCookies()
        {
            _cookieOkay.Click();
        }
        public void OurPartners_FillForm(string name,string company,string email,string partner,string subject,string message)
        {
            BFC_OurPartners_NameField.EnterName(name);
            BFC_OurPartners_CompanyField.EnterCompanyName(company);
            BFC_OurPartners_EmailField.EnterEmail(email);
            BFC_OurPartners_PartnerField.EnterPartnerField(partner);
            BFC_OurPartners_SubjectField.EnterSubject(subject);
            BFC_OurPartners_MessageField.EnterMessage(message);
            Submit();
        }
        public void OurPartners_FillFormTab(string name, string company, string email, string partner, string subject, string message)
        {
            BFC_OurPartners_NameField.EnterNameTab(name);
            BFC_OurPartners_CompanyField.EnterCompanyNameTab(company);
            BFC_OurPartners_EmailField.EnterEmailTab(email);
            BFC_OurPartners_PartnerField.EnterPartnerFieldTab(partner);
            BFC_OurPartners_SubjectField.EnterSubjectTab(subject);
            BFC_OurPartners_MessageField.EnterMessageTab(message);
            Submit();
        }
        public void Submit()
        {
            _submitButton.click();
        }
        public string ConfirmationField()
        {
            return _confirmationMessage.Text;
        }

        public string GeneralError()
        {
            return _generalError.Text;
        }
        public string NameError()
        {
            return _nameError.Text;
        }
        public string CompanyError()
        {
            return _companyError.Text;
        }
        public string EmailError()
        {
            return _emailError.Text;
        }
        public string PartnerError()
        {
            return _partnerError.Text;
        }
        public string SubjectError()
        {
            return _subjectError.Text;
        }
        public string MessageError()
        {
            return _messageError.Text;
        }
        public string GetPageTitle()
        {
            return Driver.Title;
        }

    }
}
