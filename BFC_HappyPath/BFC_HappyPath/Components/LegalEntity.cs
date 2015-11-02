using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Components
{
    public class LegalEntity : IComponent
    {
        public LegalEntity(IWebDriver driver)
        {
            IWebDriver Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "business-entity")]
        private IList<IWebElement> _legalEntity;

        public void SetLegalEntity(string legalEntity)
        {
            foreach (IWebElement legalEntityChoice in _legalEntity.Where(x => x.Text == legalEntity))
            {
                legalEntityChoice.Click();
            }
        }

        public IWebDriver Driver { get; set; }
    }
}
