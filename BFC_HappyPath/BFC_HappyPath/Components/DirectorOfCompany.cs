using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class DirectorOfCompany : IComponent
    {
        public DirectorOfCompany(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = ".c-radio__inner.c-radio__inner--inline")]
        private IList<IWebElement> _directorCompanyField;
        public void SelectDirectorCompany(string directorAnswer)
        {
            foreach (IWebElement companyDirector in _directorCompanyField.Where(x => x.Text == directorAnswer))
            {
                companyDirector.Click();
            }
        }

        public IWebDriver Driver { get; set; }
    }
}
