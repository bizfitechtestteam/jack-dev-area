using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_Newsletter_SignUp
{
    public class BFC_NewsPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public BFC_NewsPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        [FindsBy(How = How.Id, Using = "gform_submit_button_12")]
        private IWebElement _signUpButton;
        [FindsBy(How = How.Id, Using = "email-error")]
        private IWebElement _emailErrorMessage;
        [FindsBy(How = How.ClassName, Using = "gform_confirmation_message")]
        private IWebElement _confirmationMessage;
        [FindsBy(How = How.CssSelector, Using = ".fa.fa-envelope")]
        private IWebElement _mailImage;

        private BFC_News_EmailField BFC_News_EmailField => new BFC_News_EmailField(Driver);

        public void Enter_Email(string emailAddress)
        {
            BFC_News_EmailField.EnterEmailField(emailAddress);
        }
        public void SignUp()
        {
            _signUpButton.click();
        }
        public void ClickElseWhere()
        {
            _mailImage.click();
        }
        public string emailErrorText()
        {
            return _emailErrorMessage.Text;
        }
        public string confirmationText()
        {
            return _confirmationMessage.Text;
        }
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
