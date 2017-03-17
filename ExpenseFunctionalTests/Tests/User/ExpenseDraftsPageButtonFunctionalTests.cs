using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class ExpenseDraftsPageButtonFunctionalTests : TestBase
    {
        private LoginPage _loginPage;
        private Menu _menuPage;
        private ExpenseDraftsPage _expenseDraftsPage;        
        private CreateExpensePage _createExpensePage;
        private TrashBoxPage _trashBoxPAge;

       [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateExpenseDraftsDatabase();

            _loginPage = new LoginPage(Driver);
            _menuPage = new Menu(Driver);
            _expenseDraftsPage = new ExpenseDraftsPage(Driver);
            _createExpensePage = new CreateExpensePage(Driver);
            _trashBoxPAge = new TrashBoxPage(Driver);
        }

        [Test, Category("Dream")]
        public void EditDraftButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickExpenseDrafts();
            var receiptName = _expenseDraftsPage.StoreReceiptName();
            _expenseDraftsPage.ClickEditDraftButton();
            _createExpensePage.AssertCreatedReceiptTitle(receiptName);       
        }

        [Test, Category("Dream")]
        public void RemoveDraftButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickExpenseDrafts();
            var receiptName = _expenseDraftsPage.StoreReceiptName();
            _expenseDraftsPage.ClickRemoveDraftButton();
            _menuPage.ClickTrashBox();
            _trashBoxPAge.VerifyIfRowExists(receiptName);
        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
