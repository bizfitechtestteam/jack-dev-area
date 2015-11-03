﻿using BFC_HappyPath.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BFC_HappyPath.Pages
{
    public class YourBusinessPage : IPage
    {
        private HowLongTrading HowLongTrading => new HowLongTrading(Driver);
        private AnnualTurnover AnnualTurnover => new AnnualTurnover(Driver);
        private NeedForFinance NeedForFinance => new NeedForFinance(Driver);
        private BusinessCustomers BusinessCustomers => new BusinessCustomers(Driver);
        private LegalEntity LegalEntity => new LegalEntity(Driver);
        private CompanyAddress CompanyAddress => new CompanyAddress(Driver);
        public YourBusinessPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".c-btn.c-btn--a.c-questions__btn")]
        private IWebElement _continueButton;

        public void FillOutYourBusinessPage(int howLongVal,string setAnnualTurnover,string fundingPurpose, string businessCustomers)
        {
            HowLongTrading.SetTradingTime(howLongVal);
            AnnualTurnover.setAnnualTurnover(setAnnualTurnover);
            NeedForFinance.SelectFundingPurpose(fundingPurpose);
            BusinessCustomers.SetBusinessCustomer(businessCustomers);
            _continueButton.Click();
        }
        public void FillOutYourBusinessPage(string legalEntity, string companyAddress1, string companyCity, string companyPostcode, int howLongVal, string setAnnualTurnover, string fundingPurpose, string businessCustomers)
        {
            LegalEntity.SetLegalEntity(legalEntity);
            CompanyAddress.EnterManualAddress(companyAddress1,companyCity, companyPostcode);
            HowLongTrading.SetTradingTime(howLongVal);
            AnnualTurnover.setAnnualTurnover(setAnnualTurnover);
            NeedForFinance.SelectFundingPurpose(fundingPurpose);
            BusinessCustomers.SetBusinessCustomer(businessCustomers);
            _continueButton.Click();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
