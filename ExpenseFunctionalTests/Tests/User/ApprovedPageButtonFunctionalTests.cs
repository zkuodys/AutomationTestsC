using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class ApprovedPageButtonFunctionalTests : TestBase
    {
        private Menu _menuPage;
        private ApprovedPage _approvedPage;
        private CreateExpensePage _createExpensePage;
        private LoginPage _loginPage;

        [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateApprovedDatabase();

            _menuPage = new Menu(Driver);
            _approvedPage = new ApprovedPage(Driver);
            _createExpensePage = new CreateExpensePage(Driver);
            _loginPage = new LoginPage(Driver);
        }

        [Test, Category("Dream")]
        public void ViewApprovedButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickApproved();
            var receiptName = _approvedPage.StoreReceiptName();
            _approvedPage.ClickViewApprovedButton();
            _createExpensePage.AssertCreatedReceiptTitle(receiptName);
        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
