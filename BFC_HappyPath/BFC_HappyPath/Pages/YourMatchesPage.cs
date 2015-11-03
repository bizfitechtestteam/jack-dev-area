using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class YourMatchesPage : IPage
    {
        public YourMatchesPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a.c-page__btn.js-tracking-get-certainty-of-approval")]
        private IWebElement _getCertaintyApproval;

        public void FillYourMatchesPage()
        {
            _getCertaintyApproval.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
