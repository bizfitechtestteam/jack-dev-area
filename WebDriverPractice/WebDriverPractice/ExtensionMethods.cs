using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebDriverPractice
{
    public static class ExtensionMethods
    {

        public static void SendKey(this IWebElement field, string input)
        {
            try
            {
                field.Clear();
                field.SendKeys(input);
            }

            catch (NoSuchElementException e)
            {
                Assert.Fail("Didn't find the element");
            }
        }

        public static void click(this IWebElement field)
        {
            if (!field.Enabled && !field.Displayed)
            {
                throw new ElementNotVisibleException("The element passed is not displayed/enabled");
            }
                field.Click();
        }
        
    }

 
}
