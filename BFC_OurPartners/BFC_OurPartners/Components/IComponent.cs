using OpenQA.Selenium;

namespace BFC_OurPartners.Components
{
    public interface IComponent
    {
        IWebDriver Driver { get; set; }
    }
}
