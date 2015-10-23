using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

    public class RemoteDriver
    {
        private IWebDriver _driver;
        private const string DRIVER_PATH = @"C:\Users\jack.broughton\Documents";
    [SetUp]
        public void Setup()
         {
            //_driver = new ChromeDriver(DRIVER_PATH);
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities = DesiredCapabilities.Chrome();
            //capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            RemoteWebDriver x = new RemoteWebDriver(capabilities);
            // REMOTE MANAGER
            //capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
            Console.WriteLine("Test Ended\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
        }

        [Test]
        public void GoogleSearch()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://google.co.uk");

        }
}
