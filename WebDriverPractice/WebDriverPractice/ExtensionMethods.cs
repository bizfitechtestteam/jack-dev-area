using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public static class ExtensionMethods
    {

        public static void SendKeys(this IWebElement field, string input)
        {
            field.SendKeys(input);
        }
        public static string ElementIDTxt(this IWebElement findID, IWebDriver driver, string IDStr)
        {
            return driver.FindElement(By.Id(IDStr)).Text;
        }
    }


    public class ContactErrorList
    {
        public string success { get; set; }
        public string general { get; set; }
        public string emailField { get; set; }
    }
}
