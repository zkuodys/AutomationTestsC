using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class AwaitingApprovalPageButtonFunctionalTests : TestBase
    {
        private LoginPage _loginPage;
        private Menu _menuPage;
        private AwaitingApprovalPage _awaitingApprovalPage;
        private CreateExpensePage _createExpensePage;

       [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateAwaitingApprovalDatabase();

            _menuPage = new Menu(Driver);
            _awaitingApprovalPage = new AwaitingApprovalPage(Driver);
            _createExpensePage = new CreateExpensePage(Driver);
            _loginPage = new LoginPage(Driver);
        }

        [Test, Category("Dream")]
        public void ViewAwaitingExpenseButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickAwaitingApproval();
            var receiptName = _awaitingApprovalPage.StoreReceiptName();
            _awaitingApprovalPage.ClickViewAwaitingButton();
            _createExpensePage.AssertCreatedReceiptTitle(receiptName);
        }
        
        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
