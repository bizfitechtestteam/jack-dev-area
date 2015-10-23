
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebDriverPractice
{
    [TestFixture]
    public class SecondTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://bfc-test.bftcloud.com/start");
           
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }

      

        [Test]
        public void StartPage(int loanAmount, string companyString)
        {
           IWebElement amountField = _driver.FindElement(By.Id("funding-amount-altered"));
           IWebElement companyName = _driver.FindElement(By.Id("business-name"));
           IWebElement submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div/div/main/section[1]/form/fieldset/button"));
           amountField.Clear();

           amountField.SendKeys(loanAmount.ToString());
           companyName.SendKeys(companyString);
           submitButton.Click();
        }

        [Test]
        public void AboutYou(string addressLine1,string cityname,string postcode,string annual)
        {
            // IWebElement addressBar = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[1]/div[1]"));
            // addressBar.Click();

            IWebElement addressField = _driver.FindElement(By.Id("business-address"));
            addressField.SendKeys(Keys.Tab);
            //Thread.Sleep(1000);
            IWebElement enterManually = _driver.FindElement(By.ClassName("js-manual-address"));
            enterManually.Click(); 
            IWebElement aLine1 = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[1]/div[1]/div/div[2]/div/ul/li[1]/input"));
            aLine1.SendKeys(addressLine1);
            IWebElement cityName = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[1]/div[1]/div/div[2]/div/ul/li[4]/input"));
            cityName.SendKeys(cityname);
            IWebElement postCode = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[1]/div[1]/div/div[2]/div/ul/li[5]/input"));
            postCode.SendKeys(postcode);
            IWebElement legalEntity = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[2]/div[1]/div/div[2]/div/ul/li[2]/label/div"));
            legalEntity.Click();
            IWebElement tradingPlus = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[3]/div[1]/div/div[2]/div/button[1]"));
            IWebElement tradingMinus = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[3]/div[1]/div/div[2]/div/input[1]"));
            tradingPlus.Click();
            IWebElement annualTurnover = _driver.FindElement(By.Id("business-annual-turnover"));
            annualTurnover.SendKeys(annual);
            IWebElement propertyPurchase = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[5]/div[1]/div/div[2]/div/ul/li[4]/label/div/span"));
            propertyPurchase.Click();
            IWebElement smallPortion = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[6]/div/div[1]/div[2]/div/ul/li[2]/label/div"));
            IWebElement sendMatches = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/main/section[2]/form/fieldset/div[6]/button"));
            smallPortion.Click();
            sendMatches.Click();
        }

        [Test]
        public void AboutYou2(string title, string first, string second, string email,string phone)
        {
       //     IWebElement titleField = _driver.FindElement(By.Name("Questions[0].Item.Value"));
            IWebElement firstName = _driver.FindElement(By.Name("firstName"));
            IWebElement secondName = _driver.FindElement(By.Name("lastName"));
            IWebElement emailAddress = _driver.FindElement(By.Name("Questions[1].Item.Value"));
            IWebElement phoneNumber = _driver.FindElement(By.Name("Questions[2].Item.Value"));
            IWebElement submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div/div/main/section[2]/form/fieldset/button"));
      //      titleField.SendKeys(_title);
            firstName.SendKeys(first);
            secondName.SendKeys(second);
            emailAddress.SendKeys(email);
            phoneNumber.SendKeys(phone);
            submitButton.Click();
        }

        [Test]
        public void YourMatches()
        {
            //SelectElement matches = new SelectElement(_driver.FindElement(By.XPath(("/html/body/div/div/div/div/main/form/section[1]/div/table/tbody"))));
            //IList<IWebElement> matchesOptions = matches.Options;
            //foreach (IWebElement matchesOption in matchesOptions)
            //   {
            //      List<string> optionsText = new List<string>();
            //      Console.WriteLine(matchesOption.Text);
            //      optionsText.Add(matchesOption.Text);
               
            //   }
            IWebElement getCertainty = _driver.FindElement(By.XPath("/html/body/div/div/div/div/main/form/section[1]/header/a"));
            getCertainty.Click();
        }

        [Test]
        public void RunThrough()
        {

            Assert.That(_driver.Title, Is.EqualTo("Business funding alternatives | Business Loans UK | Small Business funding"));
            StartPage(23450, "ASD Business");
            Assert.That(_driver.Title, Is.EqualTo("Your Business - Business Finance Compared"));
            AboutYou("123 Fake Street","Nottingham","NG111AA","123000");
            Assert.That(_driver.Title, Is.EqualTo("About You - Business Finance Compared"));
            AboutYou2("Mr","Jack","Broughton","jack.broughton@bizfitech.com","01234567891");
            Assert.That(_driver.Title, Is.EqualTo("Your Matched Products - Business Finance Compared"));
            YourMatches();

            CollectionSample("Limited");
        }

        private void CollectionSample(string buttonToClick)
        {
            IList<IWebElement> buttons = _driver.FindElements(By.CssSelector(".c-radio__inner.c-radio__inner--inline"));
            buttons[0].Click();

            foreach (IWebElement button in buttons)
            {
                if (button.Text == buttonToClick)
                {
                    button.Click();
                }
            }

            foreach (IWebElement button in buttons.Where(x => x.Text == buttonToClick))
            {
                button.Click();
            }
        }



    }
}
