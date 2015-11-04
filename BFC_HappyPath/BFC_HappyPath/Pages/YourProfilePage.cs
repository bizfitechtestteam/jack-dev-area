using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class YourProfilePage : IPage
    {
        public YourProfilePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".c-your-profile__btn.c-btn.c-btn--b.js-score-modal.js-tracking-see-my-profile")]
        private IWebElement _seeScore;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/main/form/section/div[2]/section[2]/div/table/tbody/tr[3]/td[6]/button")]
        private IWebElement _fundNextProduct;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/main/form/section/section/div/div/table/tbody/tr[1]/td[6]/button")]
        private IWebElement _otherMatchProduct;

        public void FundNextProduct()
        {
            _fundNextProduct.Click();
        }

        public void FundOtherMatch()
        {
            _otherMatchProduct.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
