using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPractice
{
    public class ThankYouPage:IPage
    {
        [FindsBy(How = How.Id, Using = "gform_confirmation_message_13")]private IWebElement _SuccessfullMessage;
        public ThankYouPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebDriver Driver { get; set; }
        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string SuccessText()
        {
            try
            {
                return _SuccessfullMessage.Text;
            }

            catch(ElementNotVisibleException)
            {
                Driver.Dispose();
                Assert.Fail("404 Page");
                return "";
            }
        }
    }
}
