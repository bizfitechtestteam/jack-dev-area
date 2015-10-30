using OpenQA.Selenium;

namespace BFC_HappyPath
{

    public interface IComponent
    {
        IWebDriver Driver { get; set; }
    }

}