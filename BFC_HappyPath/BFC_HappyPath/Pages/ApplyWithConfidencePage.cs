using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class ApplyWithConfidencePage : IPage
    {
        public ApplyWithConfidencePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/main/form/section/div/table")]
        private IList<IWebElement> _lenderOptions;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/main/form/section/div/div/ul/li[2]")]
        private IWebElement _decisionSort;
        [FindsBy(How = How.CssSelector, Using = ".c-table-sorter__option>a")]
        private IWebElement _certaintySort;
        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a")]
        private IWebElement _seeProfile;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/main/form/section/div/table/tbody/tr[1]/td[6]/a/button")]
        private IWebElement firstGetFundedButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/main/form/section/div/table/tbody/tr[3]/td[6]/a/button")]
        private IWebElement secondGetFundedButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/main/form/section/div/table/tbody/tr[5]/td[6]/a/button")]
        private IWebElement thirdGetFundedButton;
        public IWebDriver Driver{get;set;}

        public void ApplyForBestDecision(int productPlace)
        {
            _decisionSort.Click();
            switch (productPlace)
            {
                case 1:
                    firstGetFundedButton.Click();
                    break;
                case 2:
                    secondGetFundedButton.Click();
                    break;
                case 3:
                    thirdGetFundedButton.Click();
                    break;
            }
        }

        public void NoMatches()
        {
            _seeProfile.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
