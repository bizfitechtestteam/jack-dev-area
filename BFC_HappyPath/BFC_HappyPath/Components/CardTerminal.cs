using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BFC_HappyPath.Components
{
    public class CardTerminal : IComponent
    {
        public CardTerminal(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver,this);
        }

        private string cardProviderCSS = ".c-radio__inner.c-radio__inner--inline";
        [FindsBy(How = How.Id, Using = "credit-card")]
        private IWebElement _averageCreditAmount;
        [FindsBy(How = How.CssSelector, Using = ".c-radio__inner.c-radio__inner--wide")]
        private IWebElement _noCreditButton;
        [FindsBy(How = How.CssSelector, Using = ".c-radio__inner.c-radio__inner--inline")]
        private IList<IWebElement> _terminalProviders;
      
        public void SetCreditAmount(string creditAmount, string cardProvider)

        {
            if (int.Parse(creditAmount) > 0)
            {
                foreach (IWebElement cardChoices in _terminalProviders.Where(x => x.Text == cardProvider))
                {
                    _averageCreditAmount.SendKeys(creditAmount);
                    Driver.WaitForElement(By.CssSelector(cardProviderCSS));
                    cardChoices.Click();
                }
            }
            else


            {
                _noCreditButton.Click();
            }       
        }

        public IWebDriver Driver { get; set;}
    }
}
