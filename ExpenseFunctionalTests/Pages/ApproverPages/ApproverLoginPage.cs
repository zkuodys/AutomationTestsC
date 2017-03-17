using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace ExpenseFunctionalTests.Pages.ApproverPages
{
    public class ApproverLoginPage : PageBase
    {
        private IWebDriver _driver;
        private string _windowHandler;

        public ApproverLoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='google-login-button']")]
        protected IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        protected IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "next")]
        protected IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = "Passwd")]
        protected IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "signIn")]
        protected IWebElement SingnInButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "expenseVismaApprover@gmail.com")]
        protected IWebElement UserID { get; set; }

        //Methods

        public ApproverLoginPage ClickLoginButton()
        {
            WaitForAjax();
            LoginButton.Click();
            return this;
        }

        public ApproverLoginPage SwitchToGoogleLoginPopup()
        {
            _windowHandler = _driver.CurrentWindowHandle;
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().Last());
            return this;
        }

        public ApproverLoginPage SetEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }

        public ApproverLoginPage ClickNextButton()
        {
            NextButton.Click();
            return this;
        }

        public ApproverLoginPage SetPassword(string password)
        {
            Password.SendKeys(password);
            return this;
        }

        public ApproverLoginPage ClickSignInButton()
        {
            SingnInButton.Click();
            return this;
        }

        public ApproverLoginPage SwitchToMainWindow()
        {
            _driver.SwitchTo().Window(_windowHandler);
            return this;
        }

        public string GetTitleUserID()
        {
            return UserID.Text;
        }

        public void AssertUserName(string username)
        {
            Assert.IsTrue(GetTitleUserID().Contains(username), "Didn't loged in");
        }

        public void LogIn()
        {
            this.ClickLoginButton();
            this.SwitchToGoogleLoginPopup();
            this.SetEmail("expenseVismaApprover@gmail.com");
            this.ClickNextButton();
            this.SetPassword("expenseapprover");
            this.ClickSignInButton();
            this.SwitchToMainWindow();
        }

        public void LogInAsUsser_Approver()
        {
            this.ClickLoginButton();
            this.SwitchToGoogleLoginPopup();
            this.SetEmail("expensesmanualtests@gmail.com");
            this.ClickNextButton();
            this.SetPassword("2017manual");
            this.ClickSignInButton();
            this.SwitchToMainWindow();
        }
    }
}
