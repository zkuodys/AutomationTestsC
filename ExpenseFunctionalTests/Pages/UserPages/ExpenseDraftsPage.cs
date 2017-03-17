using ExpenseFunctionalTests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class ExpenseDraftsPage : PageBase
    {
        private IWebDriver _driver;
        private string receiptName;

        public ExpenseDraftsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;         
        }

        //ExpenseDraftsPage selectors        
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='edit-button']")]
        protected IWebElement EditButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='delete-button']")]
        protected IWebElement RemoveExpenseDraftButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }
        //ExpenseDraftsPage selectors

        //ExpenseDraftsPage methods
        public string StoreReceiptName()
        {
            receiptName = ReceiptName.Text;
            return receiptName;
        }

        public ExpenseDraftsPage ClickEditDraftButton()
        {

            EditButton.Click();
            return this;
        }

        public ExpenseDraftsPage ClickRemoveDraftButton()
        {
            RemoveExpenseDraftButton.Click();
            return this;
        }

        public void VerifyIfRowExists(string receiptNname)
        {
            var rowNum = Grid.GridUtils().GetRowNumByText(receiptNname);
            Assert.IsTrue(rowNum > -1);
        }

        //public void VerifyIfRowExists(string receiptNname)
        //{
        //    bool found = false;
        //    var GridContainer = _driver.FindElement(By.TagName("exp-common-list"));
        //    var GridRows = GridContainer.FindElements(By.ClassName("items"));
        //    foreach (var gridRow in GridRows)
        //    {
        //        var firstColumn = gridRow.FindElement(By.TagName("div"));
        //        if (firstColumn.Text.Contains(receiptNname))
        //        {
        //            found = true;
        //            break;
        //        }
        //    }
        //    Assert.IsTrue(found, "Could not find!");
        //}
        //ExpenseDraftsPage methods
    }
}