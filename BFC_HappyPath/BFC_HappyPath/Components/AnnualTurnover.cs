﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class AnnualTurnover : IComponent
    {
        [FindsBy(How = How.Id, Using = "business-annual-turnover")]
        private IWebElement annualTurnoverField;
        public AnnualTurnover(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public void setAnnualTurnover(string annualTurnover)
        {
            annualTurnoverField.SendKeys(annualTurnover);
        }
        public IWebDriver Driver { get; set; }

    }
}
