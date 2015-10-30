using BFC_HappyPath.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class YourBusinessPage : IPage
    {
        private HowLongTrading HowLongTrading => new HowLongTrading(Driver);
        public YourBusinessPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a.c-questions__btn")]
        private IWebElement _continueButton;
        public void FillOutYourBusinessPage(int howLongVal)
        {
            HowLongTrading.SetTradingTime(howLongVal);
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
