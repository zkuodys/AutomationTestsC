using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ExpenseFunctionalTests.Infrastructure
{
    [TestClass]
    public abstract class TestBase
    {
        protected static IWebDriver Driver { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("http://www.google.lt");

            BeforeTest();
        }

        [TestCleanup]
        public void Teardown()
        {
            AfterTest();
            Driver.Close();
        }

        public abstract void BeforeTest();
        public abstract void AfterTest();

    }
}