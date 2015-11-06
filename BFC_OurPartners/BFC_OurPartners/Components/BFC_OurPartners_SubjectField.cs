using BFC_OurPartners.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_OurPartners
{
    public class BFC_OurPartners_SubjectField : IComponent
    {
        public BFC_OurPartners_SubjectField(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "subject")]
        private IWebElement _subjectField;

        public void EnterSubject(string subject)
        {
            _subjectField.SendText(subject);
        }
    }
}
