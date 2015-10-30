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
            StartPage.FillOutStartPage("12345","testy");
            StartPage.Submit();
            Thread.Sleep(5500);
            YourBusinessPage.FillOutYourBusinessPage(1217);
        }   
    }
}
