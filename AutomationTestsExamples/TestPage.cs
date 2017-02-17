using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace AutomationTestsExamples
{
    class TestPage
    {
        private IWebDriver _driver;

        public TestPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //Test Page selectors
        [FindsBy(How = How.CssSelector, Using = "button[class='btn dropdown-toggle btn-default'][data-id='Kreipinys_kr_tipas']")]
        protected IWebElement Type { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Paskyra')]")]
        protected IWebElement Account { get; set; }

        [FindsBy(How = How.ClassName, Using = "text-muted")]
        protected IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = "paieska")]
        protected IWebElement Search { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        protected IWebElement LoginButton { get; set; }
        //Test Page selectors

        //TEST PAGE METHODS

        public TestPage ClickItem()
        {
            Type.Click();
            return this;
        }
        
        //helps with hover on item
        public void hoveronaccount()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(Account).Perform();
        }

        public TestPage SendKeYS(string setSearch)
        {
            Search.SendKeys(setSearch);
            return this;
        }

        public string GetResult()
        {
            return Title.Text;
        }

        public string GetTitle()
        {
            return Title.Text;

        }

        public TestPage assert(string dsa)
        {
            Assert.IsTrue(GetResult().Contains(dsa), "fail");
            return this;
        }
        //TEST PAGE METHODS

    }
}
