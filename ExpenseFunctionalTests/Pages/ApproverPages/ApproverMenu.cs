using ExpenseFunctionalTests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class ApproverMenu : PageBase
    {
        private IWebDriver _driver;

        public ApproverMenu(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //ApproverMenu selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='inbox']")]
        protected IWebElement InboxButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='ready-for-payment']")]
        protected IWebElement ReadyForPaymentButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='paid']")]
        protected IWebElement PaidButton { get; set; }

        //ApproverMenu methods
        public ApproverMenu ClickInboxButton()
        {
            WaitForAjax();
            InboxButton.Click();
            return this;
        }

        public ApproverMenu ClickReadyForPaymentButton()
        {
            WaitForAjax();
            ReadyForPaymentButton.Click();
            return this;
        }

        public ApproverMenu ClickPaidButton()
        {
            WaitForAjax();
            PaidButton.Click();
            return this;
        }
    }
}
