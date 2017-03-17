using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ExpenseFunctionalTests.Infrastructure
{
    [TestFixture]
    public abstract class TestBase
    {
        protected static IWebDriver Driver { get; set; }

       [SetUp]
        public void Setup()
        {

            //BeforeTest();
            //Driver = new FirefoxDriver();
            Driver = new ChromeDriver();

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl("http://lt-practice.vsw.datakraftverk.no/Web/#!/login");
        }

        [TearDown]
        public void Teardown()
        {
            AfterTest();
            Driver.Close(); 
        }

        public abstract void BeforeTest();
        public abstract void AfterTest();

    }
}