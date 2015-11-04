using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace WebDriverPractice
{
    [TestClass]
    public class RemoteTestsContactUs : RemoteBase
    {
        public RemoteWebDriver Driver { get; set; }
        
       [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_HappyPath()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "jack.bro@arealemail.com", "This is a test message");
            ContactUsPage.Submit(); 
            Assert.AreEqual(sentSuccessfullyMessage, ThankYouPage.SuccessText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_AllBlank()
        {
            ContactUsPage.Submit();
            Assert.AreEqual(requiredMessage, ContactUsPage.FirstNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.LastNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.EmailError());
            Assert.AreEqual(requiredMessage, ContactUsPage.MessageError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_InvalidEmail_NoDot()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "thisisnotaemail@gmail", "testy messagey");// Allows just @ ???
            Assert.AreEqual(emailValidMessage, ContactUsPage.EmailError());
            ContactUsPage.Submit();
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
            Assert.AreEqual(emailValidMessage, ContactUsPage.EmailError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_InvalidEmail()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "thisisnotaemail", "testy messagey2");
            Assert.AreEqual(emailValidMessage, ContactUsPage.EmailError());
            ContactUsPage.Submit();
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
            Assert.AreEqual(emailValidMessage, ContactUsPage.EmailError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_FirstName()
        {
            ContactUsPage.FillContactUsForm("Jack", "", "", "");
            ContactUsPage.Submit();
            Assert.AreEqual(requiredMessage, ContactUsPage.LastNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.EmailError());
            Assert.AreEqual(requiredMessage, ContactUsPage.MessageError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_LastName()
        {
            ContactUsPage.FillContactUsForm("", "Broughton", "", "");
            ContactUsPage.Submit();
            Assert.AreEqual(requiredMessage, ContactUsPage.FirstNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.EmailError());
            Assert.AreEqual(requiredMessage, ContactUsPage.MessageError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_Email()
        {
            ContactUsPage.FillContactUsForm("", "", "jackbro@email.com", "");
            ContactUsPage.Submit();
            Assert.AreEqual(requiredMessage, ContactUsPage.FirstNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.LastNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.MessageError());
            Assert.AreEqual(generalErrorMessage, (ContactUsPage.GeneralError()));
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_Message()
        {
            ContactUsPage.FillContactUsForm("", "", "", "This is a message!");
            ContactUsPage.Submit();
            Assert.AreEqual(requiredMessage, ContactUsPage.FirstNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.LastNameError());
            Assert.AreEqual(requiredMessage, ContactUsPage.EmailError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_Email()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton",
                "JackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJa@email.com",
                "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
            Assert.AreEqual(over100CharErrorMessage, ContactUsPage.EmailError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("JackJackJackJackJackJackJackJackJackJackJackJackJack", "Broughton",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
            Assert.AreEqual(over50CharsErrorMessage, ContactUsPage.FirstNameError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Broughton", "JackJackJackJackJackJackJackJackJackJackJackJackJack",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
            Assert.AreEqual(over50CharsErrorMessage, ContactUsPage.LastNameError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_Email()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton",
                "JackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJa@email.com",
                "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(sentSuccessfullyMessage, ThankYouPage.SuccessText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("JackJackJackJackJackJackJackJackJackJackJackJackJa", "Broughton",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(sentSuccessfullyMessage, ThankYouPage.SuccessText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Jack", "JackJackJackJackJackJackJackJackJackJackJackJackJa",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(sentSuccessfullyMessage, ThankYouPage.SuccessText());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_NonAlphaChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("$Jack#£££", "Broughton", "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(nonAlphaErrorMessage, ContactUsPage.FirstNameError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_NonAlphaChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton123!$%^", "email@email.email", "Test Message");
            ContactUsPage.Submit();
            Assert.AreEqual(nonAlphaErrorMessage, ContactUsPage.LastNameError());
            Assert.AreEqual(generalErrorMessage, ContactUsPage.GeneralError());
        }
    }
}