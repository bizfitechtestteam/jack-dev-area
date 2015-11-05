using System.Threading;
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

        [FindsBy(How = How.Id, Using = "individual-dob-day")]
        private IWebElement _EnterDay;
        [FindsBy(How = How.Id, Using = "individual-dob-month")]
        private IWebElement _EnterMonth;
        [FindsBy(How = How.Id, Using = "individual-dob-year")]
        private IWebElement _EnterYear;


        public void FillDOB(string day, string month, string year)
        {
            Driver.WaitForElement(By.Id("individual-dob-day"));
            Thread.Sleep(500);
            _EnterDay.SendKeys(day);
            _EnterMonth.SendKeys(month);
            _EnterYear.SendKeys(year);
        }

        public IWebDriver Driver { get; set; }
    }
}
