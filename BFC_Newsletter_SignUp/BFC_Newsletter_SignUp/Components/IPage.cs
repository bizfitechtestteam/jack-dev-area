using OpenQA.Selenium;

interface IPage
{

    IWebDriver Driver { get; set; }

    string GetPageTitle();
}