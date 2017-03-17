using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class LoginTest : TestBase
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
        public void TestLogin()
        {
            _loginPage.LogIn();
            _headerPage.AssertLogin("vismaexpenses@gmail.com");

        }

        public override void AfterTest()
        {
        }
    }
}
