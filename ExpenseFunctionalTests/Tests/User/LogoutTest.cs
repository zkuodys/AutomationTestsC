using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class LogoutTest : TestBase
    {
        private LoginPage _loginPage;
        private HeaderPage _headerPage;

       [SetUp]
        public override void BeforeTest()
        {
            _loginPage = new LoginPage(Driver);
            _headerPage = new HeaderPage(Driver);
        }

        [Test, Category("MinionsTeam")]
        public void TestLogout()
        {
            _loginPage.LogIn();
            _headerPage.ClickLogoutButton();
            _headerPage.AssertLogout("Log in with your existing accounts");
        }

        public override void AfterTest()
        {
        }
    }
}
