using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPractice
{
    interface IPage
    {

        IWebDriver Driver { get; set; }

        string GetPageTitle();
    }
}
