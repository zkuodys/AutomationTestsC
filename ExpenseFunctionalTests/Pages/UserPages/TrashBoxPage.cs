using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using ExpenseFunctionalTests.Infrastructure;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class TrashBoxPage : PageBase
    {
        private IWebDriver _driver;
        private string receiptName;

        public TrashBoxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //TrashBoxPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='restore-button']")]
        protected IWebElement RestoreButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='delete-button']")]
        protected IWebElement RemovePermButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[text()='You have no items to show...']")]
        protected IWebElement EmptyTable { get; set; }
        //TrashBoxPage selectors

        //TrashBoxPage methods
        public string StoreReceiptName()
        {
            receiptName = ReceiptName.Text;
            return receiptName;
        }

        public string GetCreatedReceiptName()
        {
            return ReceiptName.Text;
        }

        public TrashBoxPage waitForAjax()
        {
            WaitForAjax();
            return this;
        }

        public TrashBoxPage ClickRestoreFromTrashBoxButton()
        {
            RestoreButton.Click();
            return this;
        }

        public TrashBoxPage ClickRemovePermanenentlyButton()
        {
            RemovePermButton.Click();
            return this;
        }

        public string GetEmptyTableText()
        {
            return EmptyTable.Text;
        }

        public void AssertExpenseDeleted(string text)
        {
            Assert.IsTrue(GetEmptyTableText().Contains(text), "Didn't loged out");
        }

        public void VerifyIfRowExists(string receiptNname)
        {
            bool found = false;
            var GridContainer = _driver.FindElement(By.CssSelector("[data-test-id='grid']"));
            var GridRows = GridContainer.FindElements(By.CssSelector("[data-test-id='grid-row']"));
            foreach (var gridRow in GridRows)
            {
                var firstColumn = gridRow.FindElement(By.CssSelector("[data-test-id='grid-name-column-cell']"));
                if (firstColumn.Text.Contains(receiptNname))
                {
                    found = true;
                    break;
                }
            }
            Assert.IsTrue(found, "Could not find!");
        }

        public void VerifyIfRowIsDeleted(string receiptNname)
        {
            bool notfound = true;
            var GridContainer = _driver.FindElement(By.CssSelector("[data-test-id='grid']"));
            var GridRows = GridContainer.FindElements(By.CssSelector("[data-test-id='grid-row']"));
            foreach (var gridRow in GridRows)
            {
                var firstColumn = gridRow.FindElement(By.CssSelector("[data-test-id='grid-name-column-cell']"));
                if (firstColumn.Text.Contains(receiptNname))
                {
                    notfound = false;
                    break;
                }
            }
            Assert.IsTrue(notfound, "Could find!");
        }
        //TrashBoxPage methods
    }
}