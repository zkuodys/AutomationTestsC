using ExpenseFunctionalTests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class ApprovedPage : PageBase
    {
        private IWebDriver _driver;
        private string receiptName;

        public ApprovedPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        //ApprovedPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='view-button']")]
        protected IWebElement ViewApprovedExpenseButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }
        //ApprovedPage selectors

        //ApprovedPage methods
        public ApprovedPage ClickViewApprovedButton()
        {
            ViewApprovedExpenseButton.Click();
            return this;
        }

        public string StoreReceiptName()
        {
            receiptName = ReceiptName.Text;
            return receiptName;
        }
        //ApprovedPage methods
    }
}