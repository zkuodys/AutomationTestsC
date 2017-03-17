using ExpenseFunctionalTests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class InboxPage : PageBase
    {
        private IWebDriver _driver;
        private string receiptName;

        public InboxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        //ApprovedPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='view-button']")]
        protected IWebElement ViewReceiptButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }
        //ApprovedPage selectors

        //ApprovedPage methods
        public InboxPage ClickViewReceipt()
        {
            ViewReceiptButton.Click();
            return this;
        }
        public InboxPage ClickViewReceipt(string receiptName)
        {
            var rowNum = Grid.GridUtils().GetRowNumByText(receiptName);
            var cellElement = Grid.GridUtils().GetCellByColumnNameAndRowNum("Actions", rowNum-1);
            cellElement.FindElement(By.CssSelector("[data-test-id='view-button']")).Click();    
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