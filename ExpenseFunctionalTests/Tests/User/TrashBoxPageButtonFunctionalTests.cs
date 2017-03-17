using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class TrashBoxPageButtonFunctionalTests : TestBase
    {
        private LoginPage _loginPage;
        private Menu _menuPage;
        private TrashBoxPage _trashBoxPage;
        private ReceiptPage _receiptPage;


       [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateTrashboxDatabase();

            _loginPage = new LoginPage(Driver);
            _menuPage = new Menu(Driver);
            _trashBoxPage = new TrashBoxPage(Driver);
            _receiptPage = new ReceiptPage(Driver);
        }
        
        [Test, Category("Dream")]
        public void RemovePermanentlyButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickTrashBox();
            var receiptName = _trashBoxPage.StoreReceiptName();
            _trashBoxPage.ClickRemovePermanenentlyButton();
            _trashBoxPage.WaitForAjax();
            _trashBoxPage.AssertExpenseDeleted("You have no items to show...");
        }

        [Test, Category("Dream")]
        public void RestoreButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickTrashBox();
            var receiptName = _trashBoxPage.StoreReceiptName();
            _trashBoxPage.ClickRestoreFromTrashBoxButton();
            _menuPage.ClickReceipts();
            _receiptPage.VerifyIfRowExists(receiptName);
        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
