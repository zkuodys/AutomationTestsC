using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class ReadyForPaymentPage : PageBase
    {
        private IWebDriver _driver;

        public ReadyForPaymentPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        //ApprovedPage selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='grid']")]
        protected IWebElement Grid { get; set; }
        //ApprovedPage selectors

        //ApprovedPage methods
        public void VerifyIfRowExists(string receiptNname)
        {
            var rowNum = Grid.GridUtils().GetRowNumByText(receiptNname);
            Assert.IsTrue(rowNum > -1);
        }
        //ApprovedPage methods
    }
}