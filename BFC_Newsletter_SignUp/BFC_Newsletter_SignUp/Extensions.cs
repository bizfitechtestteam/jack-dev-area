using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BFC_Newsletter_SignUp
{
    public static class Extensions
    {
        public static void SendText(this IWebElement field, string input)
        {
            try
            {
                field.Clear();
                field.SendKeys(input);
            }

            catch (NoSuchElementException)
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

        public static void WaitForElement(this IWebDriver Driver, string cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }
        public static void WaitForElement(this IWebDriver Driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }


        public static bool IsElementDisplayed(this IWebDriver driver, By element)
        {
            if (driver.FindElements(element).Count > 0)
            {
                if (driver.FindElement(element).Displayed)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

    }
}
