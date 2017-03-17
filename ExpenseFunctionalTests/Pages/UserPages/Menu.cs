using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ExpenseFunctionalTests.Infrastructure;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class Menu : PageBase
    {
        private IWebDriver _driver;

        public Menu(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //Menu selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='receipts-btn']")]
        protected IWebElement ReceiptsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-drafts-btn']")]
        protected IWebElement ExpenseDraftsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='awaiting-approval-btn']")]
        protected IWebElement AwaitingApprovalButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='approved-btn']")]
        protected IWebElement ApprovedButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='upload-receipts-btn']")]
        protected IWebElement UploadReceiptsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='trash-box-btn']")]
        protected IWebElement TrashBoxButton { get; set; }        
        //Menu selector

        //Menu methods
        public Menu ClickReceipts()
        {
            WaitForAjax();
            ReceiptsButton.Click();
            return this;
        }

        public Menu ClickExpenseDrafts()
        {
            WaitForAjax();
            ExpenseDraftsButton.Click();
            return this;
        }

        public Menu ClickAwaitingApproval()
        {
            AwaitingApprovalButton.Click();
            WaitForAjax();
            return this;
        }

        public Menu ClickApproved()
        {
            WaitForAjax();
            ApprovedButton.Click();
            return this;
        }

        public Menu ClickUploadReceipts()
        {
            WaitForAjax();
            UploadReceiptsButton.Click();
            return this;
        }

        public Menu ClickTrashBox()
        {
            WaitForAjax();
            TrashBoxButton.Click();
            return this;
        }
        //Menu methods
    }
}
