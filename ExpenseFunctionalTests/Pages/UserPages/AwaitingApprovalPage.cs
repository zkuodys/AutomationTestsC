using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using ExpenseFunctionalTests.Infrastructure;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class AwaitingApprovalPage : PageBase
    {
        private IWebDriver _driver;
        private string receiptName;

        public AwaitingApprovalPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        //AwaitingApprovalPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='view-button']")]
        protected IWebElement ViewAwaitingExpenseButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }
        //AwaitingApprovalPage selectors

        //AwaitingApprovalPage methods
        public AwaitingApprovalPage ClickViewAwaitingButton()
        {
            ViewAwaitingExpenseButton.Click();
            return this;
        }

        public string StoreReceiptName()
        {
            receiptName = ReceiptName.Text;
            return receiptName;
        }
        
        //AwaitingApprovalPage methods
    }
}