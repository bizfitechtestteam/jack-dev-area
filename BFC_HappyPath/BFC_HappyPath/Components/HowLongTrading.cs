using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class HowLongTrading : IComponent
    {
        /*
            0-0, 0-5. 6-11, 12-17, 18-23, 24-29, 30-35, 36-41, 42-47, 48-53, 54-59, 60-600000 how-long-value.value
        */
        public HowLongTrading(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "c-input-container__plus")]
        private IWebElement _plusButton;
        [FindsBy(How = How.ClassName, Using = "c-input-container__minus")]
        private IWebElement _minusButton;
        [FindsBy(How = How.Id, Using = "how-long-value")]
        private IWebElement _howLongValue;

        private int howLong;

        public void CheckTimeTrading(int howLongValue, string stringHowLong)
        {
            stringHowLong = _howLongValue.GetAttribute("value").ToString();
            stringHowLong = stringHowLong.Replace("-", "");
            howLong = int.Parse(stringHowLong);
        }

        public void SetTradingTime(int howLongValue)
        {
            string stringHowLong = "";
            CheckTimeTrading(howLongValue, stringHowLong);

            while (howLongValue < howLong)
            {
                CheckTimeTrading(howLongValue, stringHowLong);
                if (howLongValue < howLong)
                {
                    _minusButton.Click();
                }
            }

            while (howLongValue > howLong)
            {
                CheckTimeTrading(howLongValue, stringHowLong);
                if (howLongValue > howLong)
                {
                    _plusButton.Click();
                }
            
            }
        }

        public IWebDriver Driver { get; set; }
    }
}
