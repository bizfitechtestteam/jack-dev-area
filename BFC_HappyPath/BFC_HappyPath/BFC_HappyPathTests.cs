using System.Threading;
using BFC_HappyPath.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BFC_HappyPath
{
    [TestClass]
    public class BFC_HappyPathTests : TestBase
    {
        public RemoteWebDriver Driver { get; set; }
        [DataSource("XmlDataSource"), TestMethod]
        public void TestPage()
        {
            WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/start");
            StartPage.FillOutStartPage("12345","testyasd");
            StartPage.Submit();
            Thread.Sleep(2500);
            //YourBusinessPage.FillOutYourBusinessPage(611, "123456", "Property purchase", "A large proportion of my customers");
            YourBusinessPage.FillOutYourBusinessPage("SoleTrader"," "," "," ", 611,"123456", "Property purchase", "A large proportion of my customers");
        }   
    }
}
