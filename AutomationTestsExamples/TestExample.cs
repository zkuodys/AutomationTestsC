using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTestsExamples
{
    [TestClass]
    public class TestExample
    {
        public string searchKeyword = "asd";

        private IWebDriver _driver;
        private TestPage _testPage;

        [TestInitialize]
        public void BeforeTests()
        {
            _driver = new ChromeDriver();
            _testPage = new TestPage(_driver);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _driver.Navigate().GoToUrl("http://");
            _testPage.ClickItem();
            _testPage.SendKeYS("");
            _testPage.ClickItem();
        }

        [TestMethod]
        public void TestCreateNewExpense()
        {
            _testPage.SendKeYS(searchKeyword);
            _testPage.assert(searchKeyword);
            _testPage.hoveronaccount();
            _testPage.ClickItem();
        }

        [TestCleanup]
        public void AfterTest()
        {
            _driver.Quit();
        }
    }
}
