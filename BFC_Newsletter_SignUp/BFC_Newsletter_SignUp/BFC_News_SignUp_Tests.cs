using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BFC_Newsletter_SignUp
{
    [TestClass]
    public class BFC_News_SignUp_Tests : TestBase
    {

        public RemoteWebDriver Driver { get; set; }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Valid_SignUp()
        {
            BFC_NewsPage.Enter_Email("jacktest@gmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Blank_NoClick_SignUp()
        {
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_fieldRequiredMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Blank_SignUp()
        {
            BFC_NewsPage.Enter_Email("");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_fieldRequiredMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoUsername_SignUp()
        {
            BFC_NewsPage.Enter_Email("@testgmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoAt_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoDot_SignUp()    //Your subscription could not be completed //NO WARNING ON EMAIL CHAR LIMIT, APPEARS TO BE 100
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail@gmail");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoDot_NoAt_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail@");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Invalid_Valid_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
            BFC_NewsPage.Enter_Email("jack.broughton@gmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoDomain_NoSignUp()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail@");
            BFC_NewsPage.ClickElseWhere();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_DotDomain_SignUp()
        {
            BFC_NewsPage.Enter_Email("jacktest@gmail.co.uk");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_PlusSymbol_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack+test@gmail.co.uk");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_TwoPlusSymbol_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack@test@gmail.co.uk");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NonAlpha_SignUp()
        {
            BFC_NewsPage.Enter_Email("#@%^%#$@#$@#.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Spaces_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack test@gmail.co.uk");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_UnderScores_SignUp()
        {
            BFC_NewsPage.Enter_Email("jack___test@gmail.co.uk");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_Text_SignUp()
        {
            BFC_NewsPage.Enter_Email("jacktest@gmail.co.uk Hello");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_MultipleDots_SignUp()
        {
            BFC_NewsPage.Enter_Email("jacktest@gmail..com Hello");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NewsArticle_SignUp()
        {
            WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/news/government-announces-1m-cyber-security-scheme-for-smes/");
            BFC_NewsPage.Enter_Email("jacktest@gmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NewsArticle_NoDomain_SignUp()
        {
            WebDriver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/news/government-announces-1m-cyber-security-scheme-for-smes/");
            BFC_NewsPage.Enter_Email("jacktest@gmail.");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
    }
}
