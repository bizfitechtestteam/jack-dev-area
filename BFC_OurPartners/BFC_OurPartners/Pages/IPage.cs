using OpenQA.Selenium;

namespace BFC_OurPartners
{
    interface IPage
    {

        IWebDriver Driver { get; set; }

        string GetPageTitle();
    }
}
