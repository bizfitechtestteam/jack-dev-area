using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class AboutYouPage : IPage
    {
        public AboutYouPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.CssSelector, Using = "c-btn c-btn--a c-questions__btn")]
        private IWebElement _seeMatchesButton;
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
