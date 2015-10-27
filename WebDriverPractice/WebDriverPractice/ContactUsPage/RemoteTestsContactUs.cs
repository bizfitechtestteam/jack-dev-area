using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebDriverPractice
{
    [TestClass]
    public class RemoteTestsContactUs : RemoteBase
    {
        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_HappyPath()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "jack.bro@arealemail.com", "This is a test message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_SentSuccessfully();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_AllBlank()
        {
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_FirstName_FieldRequiredError();
            ContactUsPage.ContactUsForm_LastName_FieldRequiredError();
            ContactUsPage.ContactUsForm_Email_FieldRequiredError();
            ContactUsPage.ContactUsForm_Message_FieldRequiredError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_InvalidEmail_NoDot()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "thisisnotaemail@gmail", "testy messagey");//    Allows just @ ???
            ContactUsPage.ContactUsForm_Email_ValidRequiredError();
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_GeneralError();
            ContactUsPage.ContactUsForm_Email_ValidRequiredError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_InvalidEmail()
        {
            ContactUsPage.FillContactUsForm("Jack", "Bro", "thisisnotaemail", "testy messagey2");
            ContactUsPage.ContactUsForm_Email_ValidRequiredError();
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_GeneralError();
            ContactUsPage.ContactUsForm_Email_ValidRequiredError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_FirstName()
        {
            ContactUsPage.FillContactUsForm("Jack", "", "", "");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_LastName_FieldRequiredError();
            ContactUsPage.ContactUsForm_Email_FieldRequiredError();
            ContactUsPage.ContactUsForm_Message_FieldRequiredError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_LastName()
        {
            ContactUsPage.FillContactUsForm("", "Broughton", "", "");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_FirstName_FieldRequiredError();
            ContactUsPage.ContactUsForm_Email_FieldRequiredError();
            ContactUsPage.ContactUsForm_Message_FieldRequiredError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_Email()
        {
            ContactUsPage.FillContactUsForm("", "", "jackbro@email.com", "");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_FirstName_FieldRequiredError();
            ContactUsPage.ContactUsForm_LastName_FieldRequiredError();
            ContactUsPage.ContactUsForm_Message_FieldRequiredError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_Only_Message()
        {
            ContactUsPage.FillContactUsForm("", "", "", "This is a message!");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_FirstName_FieldRequiredError();
            ContactUsPage.ContactUsForm_LastName_FieldRequiredError();
            ContactUsPage.ContactUsForm_Email_FieldRequiredError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_Email()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton",
                "JackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJa@email.com",
                "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_GeneralError();
            ContactUsPage.ContactusForm_Email_OverMaxCharsError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("JackJackJackJackJackJackJackJackJackJackJackJackJack", "Broughton",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_GeneralError();
            ContactUsPage.ContactusForm_FirstName_OverMaxCharsError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_OverMaxChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Broughton", "JackJackJackJackJackJackJackJackJackJackJackJackJack",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_GeneralError();
            ContactUsPage.ContactusForm_LastName_OverMaxCharsError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_Email()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton",
                "JackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJackJa@email.com",
                "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_SentSuccessfully();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("JackJackJackJackJackJackJackJackJackJackJackJackJa", "Broughton",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_SentSuccessfully();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_MaxChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Jack", "JackJackJackJackJackJackJackJackJackJackJackJackJa",
                "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactUsForm_SentSuccessfully();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_NonAlphaChar_FirstName()
        {
            ContactUsPage.FillContactUsForm("$Jack#£££", "Broughton", "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactusForm_FirstName_NonAlphaError();
            ContactUsPage.ContactUsForm_GeneralError();
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void ContactForm_NonAlphaChar_LastName()
        {
            ContactUsPage.FillContactUsForm("Jack", "Broughton123!$%^", "email@email.email", "Test Message");
            ContactUsPage.Submit();
            ContactUsPage.ContactusForm_LastName_NonAlphaError();
            ContactUsPage.ContactUsForm_GeneralError();
        }
    }
}