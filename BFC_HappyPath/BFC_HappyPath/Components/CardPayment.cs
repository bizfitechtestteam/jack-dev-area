using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class CardPayment : IComponent
    {
        public CardPayment(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public IWebDriver Driver { get; set; }
    }
}
