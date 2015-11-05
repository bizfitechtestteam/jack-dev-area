using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BFC_Newsletter_SignUp
{
    [TestClass]
    public class BFC_News_SignUp_Tests : TestBase
    {
        public RemoteWebDriver Driver { get; set; }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_SignUp_ValidEmail()
        {
            BFC_NewsPage.Enter_Email("jacktest@gmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_BlankEmail_NoClick_SignUp()
        {
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_fieldRequiredMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_BlankEmail_Click_SignUp()
        {
            BFC_NewsPage.Enter_Email("");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_fieldRequiredMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoAt()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoDot()    //Your subscription could not be completed
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail@gmail");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_Email_NoDotNoAddress()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail@");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void BFC_NewsLetter_InvalidEmail_ValidEmail()
        {
            BFC_NewsPage.Enter_Email("jack.broughtongmail");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_validEmailErrorMessage, BFC_NewsPage.emailErrorText());
            BFC_NewsPage.Enter_Email("jack.broughton@gmail.com");
            BFC_NewsPage.SignUp();
            Assert.AreEqual(_thankyouMessage, BFC_NewsPage.confirmationText());
        }
            //NO WARNING ON EMAIL CHAR LIMIT, APPEARS TO BE 100
    }
}
