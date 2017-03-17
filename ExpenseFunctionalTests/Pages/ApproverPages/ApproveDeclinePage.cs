using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class ApproveDeclinePage : PageBase
    {
        private IWebDriver _driver;

        public ApproveDeclinePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //ApproverMenu selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='approve-button']")]
        protected IWebElement ApproveButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='decline-button']")]
        protected IWebElement DeclineButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='decline-modal-text-area']")]
        protected IWebElement CommentArea { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='decline-modal-ok-button']")]
        protected IWebElement DeclineOkButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='approve-modal-ok-button']")]
        protected IWebElement ApproveOkButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-title']")]
        protected IWebElement Title { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='expenses-covered-by']/option[3]")]
        protected IWebElement ExpenseCoveredBy { get; set; }

        [FindsBy(How = How.Id, Using = "company-name")]
        protected IWebElement ExpenseCompanyName { get; set; }

        [FindsBy(How = How.Id, Using = "project-title")]
        protected IWebElement ExpenseProjectTitle { get; set; }

        //ApproverMenu methods
        public string GetCreatedReceiptName()
        {
            WaitForAjax();
            var title = Title.GetAttribute("value");
            return title;
        }

        public ApproveDeclinePage AssertCreatedReceiptTitle(string name)
        {
            Assert.IsTrue(GetCreatedReceiptName().Contains(name));
            return this;
        }

        public ApproveDeclinePage ClickApproveButton()
        {
           ApproveButton.Click();
            return this;
        }

        public ApproveDeclinePage ClickDeclineButton()
        {
            DeclineButton.Click();
            return this;
        }

        public ApproveDeclinePage SetComment(string setComment)
        {
            CommentArea.Clear();
            CommentArea.SendKeys(setComment);
            return this;
        }

        public ApproveDeclinePage ClickDeclineModalOkButton()
        {
            DeclineOkButton.Click();
            return this;
        }

        public ApproveDeclinePage ClickApproveModalOkButton()
        {
            ApproveOkButton.Click();
            return this;
        }

        public ApproveDeclinePage SetExpenseCoveredBy()
        {
            ExpenseCoveredBy.Click();
            ExpenseCompanyName.SendKeys("UAB Company");
            ExpenseProjectTitle.SendKeys("HUGE TITLE");
            return this;
        }
    }
}
