using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class HeaderPage : PageBase
    {
        private IWebDriver _driver;

        public HeaderPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "first-level-item")]
        protected IWebElement UserID { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='log-out-button']")]
        protected IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='login-text']")]
        protected IWebElement SignInWindowText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='header-username']")]
        protected IWebElement HeaderUsernameText { get; set; }

        //Methods


        public HeaderPage ClickLogoutButton()
        {
            WaitForAjax();
            LogoutButton.Click();
            return this;
        }

        public string GetSignInWindowText()
        {
            return SignInWindowText.Text;
        }

        public void AssertLogout(string text)
        {
            Assert.IsTrue(GetSignInWindowText().Contains(text), "Didn't loged out");
        }
        public string GetHeaderUsernameText()
        {
            return HeaderUsernameText.Text;
        }

        public void AssertLogin(string text)
        {
            Assert.IsTrue(GetHeaderUsernameText().Contains(text), "Didn't loged out");
        }
    }
}
