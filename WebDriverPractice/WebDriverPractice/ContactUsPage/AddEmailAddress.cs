using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class AddEmailAddress : IComponent
    {
        public AddEmailAddress(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailAddressField;
        
        public void EnterEmailAddress(string emailAddress)
        {
            _emailAddressField.SendKeys(emailAddress);
        }
        public void ClearEmailAddress()
        {
            _emailAddressField.Clear();
        }
        public IWebDriver Driver { get; set; }
    }
}
