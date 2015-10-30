using OpenQA.Selenium;

namespace WebDriverPractice
{
    interface IPage
    {

        IWebDriver Driver { get; set; }

        string GetPageTitle();
    }
}
