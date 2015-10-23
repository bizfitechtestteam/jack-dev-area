
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebDriverPractice
{
    [TestFixture]
    public class JackTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("http://www.bbc.co.uk");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }

        [Test]
        public void FirstTest()
        {
            IWebElement newsLink = _driver.FindElement(By.LinkText("News"));

            newsLink.Click();
            Assert.That(_driver.Title, Is.EqualTo("Home - BBC News"));
        }
        [Test]
        public void FindSport()
        {
            IWebElement sportsLink = _driver.FindElement(By.ClassName("orb-nav-sport"));
            sportsLink.Click();
            Assert.That(_driver.Title, Is.EqualTo("BBC Sport - Sport"));
        }

        [Test]
        public void SearchSport()
        {
            FindSport();
            IWebElement searchBar = _driver.FindElement(By.Id("blq-search-q"));
            searchBar.SendKeys("Cricket");
            searchBar.Submit();
        }

        [Test]
        public void LeagueTable()
        {
            //string team = "Nottm Forest";
            FindSport();
            IWebElement football = _driver.FindElement(By.LinkText("Football"));
            football.Click();
            IWebElement tables = _driver.FindElement(By.LinkText("Tables"));
            tables.Click();
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("uk-group-drop-down")));
            IList<IWebElement> dropdownOptions = dropdown.Options;
            dropdown.SelectByText("Championship");
            IWebElement updateTable = _driver.FindElement(By.Id("filter-nav-submit"));
            updateTable.Click();
            IWebElement userTeam = _driver.FindElement(By.Name("Nottm Forest"));
            userTeam.Click();
                
            foreach (IWebElement dropDownOption in dropdownOptions)
            {
                List<string> optionsText = new List<string>();
                Console.WriteLine(dropDownOption.Text);
                optionsText.Add(dropDownOption.Text);
                //if (dropDownOption.Text == " Championship ")
                //{
                //    Assert.That(dropDownOption.Text, Is.EqualTo(" Championship "));
                //}
            }

        }

        [Test]
        public void Food()
        {
            IWebElement moreLink = _driver.FindElement(By.LinkText("More"));
            moreLink.Click();
            IWebElement foodLink = _driver.FindElement(By.LinkText("Food"));
            foodLink.Click();
            IWebElement searchBar = _driver.FindElement(By.Id("search-keywords"));
            searchBar.Click();
            searchBar.SendKeys("Pizza");
            searchBar.Submit();
            IWebElement pizzaLink = _driver.FindElement(By.LinkText("Prosciutto, mozzarella and fig pizza"));
            pizzaLink.Click();
            IWebElement ingredients = _driver.FindElement(By.Id("ingredients"));
            IWebElement preparation = _driver.FindElement(By.Id("preparation"));
            string[] textIn = {ingredients.Text };
            string[] textPr = { preparation.Text };
            foreach (string line in textIn)
                {
                    Console.WriteLine(ingredients.Text);
                }

            foreach (string line in textPr)
            {
                Console.WriteLine(preparation.Text);
            }
        }
        

    }
}
