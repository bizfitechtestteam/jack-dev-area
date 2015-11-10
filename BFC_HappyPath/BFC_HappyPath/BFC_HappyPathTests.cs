using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BFC_HappyPath
{
    [TestClass]
    public class BFC_HappyPathTests : TestBase
    {
        public RemoteWebDriver Driver { get; set; }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_HighScore_NoCompanyNumber_ManualAddress_CardPayments_ApplyDecision() //No matches?
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("54345","testy123");
            YourBusinessPage.FillOutYourBusinessPage("Sole trader", "123 Fake street","FakeTown","NG114ku", 60600000, "5125456", "Asset purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack","Bro","jackbro@email.com","01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApproval("123 test", "testland", "NG1 1AA", "12","12","1960","Beverage Products", "32345", "Global Payments");
            ApplyWithConfidencePage.ApplyForBestDecision(1);
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_HighScore_CompanyNumber_ManualAddress_ApplyDecision()
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("53300", "jack");
            YourBusinessPage.FillOutYourBusinessPage(4853, "5365000", "Asset purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack", "Bro", "jackbro@email.com", "01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApproval("321 test", "testland", "NG1 1AA", "12", "12", "1960", "Yes", "Beverage Products", "0", "");
            ApplyWithConfidencePage.ApplyForBestDecision(1);
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_HighScore_CompanyNumber_AutoAddress_FundOther()
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("65300", "jack");
            YourBusinessPage.FillOutYourBusinessPage(4853, "1136500", "Asset purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack", "Bro", "jackbro@email.com", "01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApproval("321 test", "testland", "NG1 1AA", "12", "12", "1950", "Yes", "Beverage Products", "0", "");
            ApplyWithConfidencePage.FundOther();
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_HighScore_NoCompanyNumber_AutoAddress_CardPayments_ApplyDecision_FundNext() //No matches
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("51000", "Pizzaaaa");
            YourBusinessPage.FillOutYourBusinessPage("Sole trader", "NG1 1AA", 60600000, "1555456", "Asset purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack", "Bro", "jackbro@email.com", "01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApprovalAuto("12345", "12","12","1960", "Financial Services", "32345", "Barclaycard");
            ApplyWithConfidencePage.ApplyForBestDecision(1);
            YourProfilePage.FundNextProduct();
        }
        
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_LowScore_CompanyNumber_AutoAddress_FundOther()
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("43500", "jacks");
            YourBusinessPage.FillOutYourBusinessPage(611, "3300", "Asset purchase", "No");
            AboutYouPage.FillOutAboutYouPage("Jack34", "Bro34", "jackbro@email.com", "01234567811");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApprovalAuto("NG1 1AA", "12","12","1990", "No");
            ApplyWithConfidencePage.NoMatches();
            YourProfilePage.FundOtherMatch();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_LowScore_CompanyNumber_ManualAddress_NoMatches()
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("43500", "jacks");
            YourBusinessPage.FillOutYourBusinessPage(005, "300", "Asset purchase", "No");
            AboutYouPage.FillOutAboutYouPage("Jack34", "Bro34", "jackbro@email.com", "01234567811");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApproval("321 test", "testland", "NG115st", "12","12","1994", "No");
            ApplyWithConfidencePage.NoMatches();
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_LowScore_NoCompanyNumber_ManualAddress_NoMatches()
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("18345", "testy14223");
            YourBusinessPage.FillOutYourBusinessPage("Sole trader", "123 Fake street", "FakeTown", "NG114ku", 4348, "31234", "Asset purchase", "A large proportion of my customers");
            AboutYouPage.FillOutAboutYouPage("Jack", "Bro", "jackbro@email.com", "01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApproval("123 test", "testland", "NG115st", "12","12","1993");
            ApplyWithConfidencePage.NoMatches();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_LowScore_NoCompanyNumber_AutoAddress_ApplyDecision_ApplyProfileProduct() //No Matches
        {
            StartPage.ClickCookie();
            StartPage.FillOutStartPage("25345", "testy14223");
            YourBusinessPage.FillOutYourBusinessPage("Sole trader", "NG11 1AA",1823,"51000", "Asset purchase", "No");
            AboutYouPage.FillOutAboutYouPage("Jack", "Bro", "jackbro@email.com", "01234567890");
            YourMatchesPage.GetCertainty();
            CertaintyApprovalPage.FillOutCertaintyApprovalAuto("NG11 1AA", "12","12","1975");
            ApplyWithConfidencePage.ApplyForBestDecision(1);
            YourProfilePage.FundNextProduct();
        }
    }
}
