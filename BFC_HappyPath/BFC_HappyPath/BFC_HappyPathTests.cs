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
            StartPage.FillOutStartPage("12345","testy123");
            StartPage.Submit();
            //YourBusinessPage.FillOutYourBusinessPage(611, "123456", "Property purchase", "A large proportion of my customers");
            YourBusinessPage.FillOutYourBusinessPage("Sole trader", "123 Fake street","FakeTown","NG114ku", 4853,"555456", "Property purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack","Bro","jackbro@email.com","01234567890");
            YourMatchesPage.FillYourMatchesPage();
            CertaintyApprovalPage.FillOutCertaintyApproval("123 test", "testland", "NG115st", "12121990","Beverage Products", "12345", "Global Payments");
           // CertaintyApprovalPage.FillOutCertaintyApproval("123 test","testland","NG115st","12121990", "Yes", "Beverage Products","12345", "Global Payments");
        }
    }
}
