using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebDriverPractice;
namespace WebDriverPractice
{
    public class RemoteDriverManager
    {
        readonly DesiredCapabilities _desiredCapabilities = new DesiredCapabilities();

        public IWebDriver CreateDriver(string browser, string version, string platform)
        {
            try
            {
                _desiredCapabilities.SetCapability(CapabilityType.BrowserName, browser.ToLower());
                _desiredCapabilities.SetCapability(CapabilityType.Version, version);
                _desiredCapabilities.SetCapability(CapabilityType.Platform, platform.ToUpper());
                return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), _desiredCapabilities, TimeSpan.FromSeconds(300));
            }
            catch (WebDriverException)
            {
                Assert.Fail("Could not connect to Hub or Node. Check if Hub and Node are running.");
            }
            return null;
        }
    }
}
