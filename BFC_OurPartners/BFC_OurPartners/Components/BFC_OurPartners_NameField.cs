using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners.Components
{
    public class BFC_OurPartners_NameField : IComponent
    {
        public BFC_OurPartners_NameField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }
        
        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _nameField;

        public void EnterName(string name)
        {
            _nameField.SendText(name);
        }

        public void EnterNameTab(string name)
        {
            _nameField.SendKeys(name);
            _nameField.SendKeys(Keys.Tab);
        }
    }
}
