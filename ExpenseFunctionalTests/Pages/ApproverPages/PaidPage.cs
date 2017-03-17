using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ExpenseFunctionalTests.Infrastructure;


namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class PaidPage : PageBase
    {
        private IWebDriver _driver;

        public PaidPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        //ApprovedPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='view-button']")]
        protected IWebElement ViewReceiptButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='search-by-title']")]
        protected IWebElement SearchByTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='search-by-email']")]
        protected IWebElement SearchByEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='search-btn']")]
        protected IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }

        //ApprovedPage methods
        public PaidPage ClickViewReceipt()
        {
            ViewReceiptButton.Click();
            return this;
        }

        public PaidPage SetSearchByTitle(string title)
        {
            SearchByTitle.SendKeys(title);
            return this;
        }

        public PaidPage SetSearchByEmail(string emailadress)
        {
            SearchByEmail.SendKeys(emailadress);
            return this;
        }

        public PaidPage ClickSearchButton()
        {
            SearchButton.Click();
            return this;
        }

        //public void VerifyRowsNumber()
        //{
        //    var num = Grid.GridUtils().GetNumberRows();
        //}
    }
}