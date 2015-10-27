using OpenQA.Selenium;

namespace WebDriverPractice
{
    public interface IComponent
    {
        IWebDriver Driver { get; set; }
    }
}
