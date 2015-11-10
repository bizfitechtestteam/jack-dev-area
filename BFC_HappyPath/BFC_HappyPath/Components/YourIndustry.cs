using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BFC_HappyPath.Components
{
    public class YourIndustry : IComponent
    {
        public YourIndustry(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "industry")]
        private IWebElement _directorCompanyField;
        [FindsBy(How = How.CssSelector, Using = "#industry")]
        private IWebElement _directorCompanyFieldCSS;

        public void SelectDirectorCompany(string industryField)
        {
            var selectElement = new SelectElement(_directorCompanyFieldCSS);
            selectElement.SelectByValue(industryField);

        }
        public IWebDriver Driver { get; set; }
    }
}
