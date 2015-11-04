using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class EnterDOB : IComponent
    {
        public EnterDOB(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "individual-dob-day")]
        private IWebElement _EnterDOB;

        public void FillDOB(string DOB)
        {
            _EnterDOB.SendKeys(DOB);
        }

        public IWebDriver Driver { get; set; }
    }
}
