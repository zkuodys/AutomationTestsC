using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class ReceiptPage : PageBase
    {
        private IWebDriver _driver;
        public string receiptName;
        private string _windowHandler;

        public ReceiptPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //ReceiptPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='create-button']")]
        protected IWebElement CreateNewExpenseButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='view-button']")]
        protected IWebElement ViewReceiptButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='delete-button']")]
        protected IWebElement DeleteReceiptButton { get; set; }

        [FindsBy(How = How.CssSelector ,Using = "[data-test-id='grid-name-column-cell']")]
        protected IWebElement ReceiptName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-dismiss='modal']")]
        protected IWebElement X { get; set; }
        //ReceiptPage selectors

        //ReceiptPage methods
        public ReceiptPage SwitchToPreviewPopup()
        {
            _windowHandler = _driver.CurrentWindowHandle;
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().Last());
            return this;
        }
 
        public ReceiptPage SwitchToMainWindow()
        {
            //_windowHandler = _driver.CurrentWindowHandle;
            _driver.SwitchTo().Window(_windowHandler);
            //_driver.SwitchTo().DefaultContent();
            return this;
        }

        public string StoreReceiptName()
        {
            receiptName = ReceiptName.Text;
            return receiptName;
        }
        
        public ReceiptPage ClickCreateNewExpense()
        {
            CreateNewExpenseButton.Click();
            return this;
        }

        public ReceiptPage ClickViewReceipt()
        {
            ViewReceiptButton.Click();
            return this;
        }

        //public void WaitForAjax()
        //{
        //    //Wait for angular is loaded
        //    new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(
        //        driver =>
        //        {
        //            try
        //            {
        //                //Ajax.WaitVs().WaitUntilInvisible();
        //                ((IJavaScriptExecutor)driver).ExecuteAsyncScript("if(!window.angular){return;} var callback = arguments[arguments.length - 1];" + "angular.element(document.body).injector().get('$browser').notifyWhenNoOutstandingRequests(callback);");
        //                return true;
        //            }
        //            catch (Exception)
        //            {
        //                return false;
        //            }
        //        });
        //}
        public ReceiptPage waitForAjax()
        {
            WaitForAjax();
            return this;
        }

        public ReceiptPage ClickX()
        {
            WaitForAjax();
            X.Click();
            return this;
        }

        public ReceiptPage ClickDeleteReceipt()
        {
            DeleteReceiptButton.Click();
            return this;
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
        //ReceiptPage methods
    }
}
