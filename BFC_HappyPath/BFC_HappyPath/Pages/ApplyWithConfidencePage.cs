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
        private IList<IWebElement> _financeOptions;
        [FindsBy(How = How.CssSelector, Using = ".c-table-sorter__option.c-table-sorter__option--current>a")]
        private IWebElement _certaintySort;
        [FindsBy(How = How.Id, Using = "c-table-sorter__option")]
        private IWebElement _decisionSort;
        public IWebDriver Driver{get;set;}

        public void ApplyForBestCertainty()
        {
            _certaintySort.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
