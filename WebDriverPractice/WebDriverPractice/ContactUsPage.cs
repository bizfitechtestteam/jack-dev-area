using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class ContactUsPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
