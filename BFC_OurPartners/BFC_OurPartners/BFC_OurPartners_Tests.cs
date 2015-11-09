using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BFC_OurPartners
{
    [TestClass]
    public class BFC_OurPartners_Tests : TestBase
    {
        public RemoteWebDriver Driver { get; set; }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_Valid_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("Jack Bro","JackBroLTD","jackbro@emailtests.com","Partner","Free monies","Heres some money");
            Assert.AreEqual(_successfullMessage, BFC_OurPartners_Page.ConfirmationField());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_AllBlank_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("","","","","","");
            List<string> myList = new List<string>() {BFC_OurPartners_Page.NameError(),BFC_OurPartners_Page.CompanyError(),BFC_OurPartners_Page.EmailError(),BFC_OurPartners_Page.MessageError(),BFC_OurPartners_Page.PartnerError(),BFC_OurPartners_Page.SubjectError()};
            myList.ListAsserts(_fieldReqErrorMessage,_generalErrorMessage,BFC_OurPartners_Page.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_EmailNoAt_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("Jack Bro", "JackBroLTD", "jackbroemailtests.com", "Partner", "Free monies", "Heres some money");
            Assert.AreEqual(_validEmailErrorMessage, BFC_OurPartners_Page.EmailError());
            Assert.AreEqual(_generalErrorMessage, BFC_OurPartners_Page.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_EmailNoDot_Submit() //*
        {
            BFC_OurPartners_Page.OurPartners_FillForm("Jack Bro", "JackBroLTD", "jackbro@emailtestscom", "Partner", "Free monies", "Heres some money");
            Assert.AreEqual(_validEmailErrorMessage, BFC_OurPartners_Page.EmailError());
            Assert.AreEqual(_generalErrorMessage, BFC_OurPartners_Page.GeneralError());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_OnlyName_Submit() 
        {
            BFC_OurPartners_Page.OurPartners_FillForm("Jack Bro", "", "", "", "", "");
            List<string> myList = new List<string>() {BFC_OurPartners_Page.CompanyError(), BFC_OurPartners_Page.EmailError(), BFC_OurPartners_Page.MessageError(), BFC_OurPartners_Page.PartnerError(), BFC_OurPartners_Page.SubjectError()};
            myList.ListAsserts(_fieldReqErrorMessage, _generalErrorMessage, BFC_OurPartners_Page.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_OnlyEmail_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("", "", "jackbro@bizfitest.com", "", "", "");
            List<string> myList = new List<string>() {BFC_OurPartners_Page.NameError(),BFC_OurPartners_Page.CompanyError(), BFC_OurPartners_Page.MessageError(), BFC_OurPartners_Page.PartnerError(), BFC_OurPartners_Page.SubjectError()};
            myList.ListAsserts(_fieldReqErrorMessage, _generalErrorMessage, BFC_OurPartners_Page.GeneralError());
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_OnlyMessage_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("", "", "", "", "", "Only Message");
            List<string> myList = new List<string>() { BFC_OurPartners_Page.NameError(), BFC_OurPartners_Page.CompanyError(), BFC_OurPartners_Page.EmailError(), BFC_OurPartners_Page.PartnerError(), BFC_OurPartners_Page.SubjectError() };
            myList.ListAsserts(_fieldReqErrorMessage, _generalErrorMessage, BFC_OurPartners_Page.GeneralError());
        }
        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_NameNonAlpha_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillForm("Jack Bro #£$&", "JackBROLTD", "jackbro@testemailss.com", "Partner", "subjects", "Only Message");
        }

        [DataSource("XmlDataSource"), TestMethod]
        public void OurPartners_Valid_Tab_Submit()
        {
            BFC_OurPartners_Page.OurPartners_FillFormTab("Jack Bro TAB", "JackBROLTD", "jackbro@testemailss.com", "Partner", "subjects", "Only Message");
            Assert.AreEqual(_successfullMessage, BFC_OurPartners_Page.ConfirmationField());
        }
    }
}
