using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    class EnterCompanyName : IComponent
    {
        public EnterCompanyName(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        [FindsBy(How = How.Id, Using = "business-name")]
        private IWebElement _EnterCompanyfield;

        public void EnterCompanyField(string companyName)
        {
            if (companyName.Length > 5)
            {
                _EnterCompanyfield.SendText(companyName);
            }
            else
            {
                _EnterCompanyfield.SendText(companyName);
                Thread.Sleep(1500);
                _EnterCompanyfield.SendText(Keys.ArrowDown);
                Thread.Sleep(500);
                _EnterCompanyfield.SendText(Keys.Tab);
            }
        }
        public IWebDriver Driver { get; set; }
    }
}
