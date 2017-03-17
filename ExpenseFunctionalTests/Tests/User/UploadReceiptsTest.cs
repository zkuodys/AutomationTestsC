using ExpenseFunctionalTests;
using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class UploadReceiptsTest : TestBase
    {
        private LoginPage _loginPage;
        private HeaderPage _headerPage;
        private UploadReceiptsPage _uploadReceiptsPage;
        private Menu _menu;

       [SetUp]
        public override void BeforeTest()
        {
            _loginPage = new LoginPage(Driver);
            _headerPage = new HeaderPage(Driver);
            _uploadReceiptsPage = new UploadReceiptsPage(Driver);
            _menu = new Menu(Driver);
        }

        [Test, Category("MinionsTeam")]
        public void UploadReceiptTest()
        {
            _loginPage.LogIn();
            _menu.ClickUploadReceipts();
            _uploadReceiptsPage.SetUploadFile();
            _uploadReceiptsPage.AssertUploadSucessMessage();

        }

        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
