using System.Collections.Generic;
using System.Threading;
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

        public void SelectDirectorCompany(string industryField)
        {
            var selectElement = new SelectElement(_directorCompanyField);
            selectElement.SelectByValue(industryField);

        }
        public IWebDriver Driver { get; set; }
    }
}
