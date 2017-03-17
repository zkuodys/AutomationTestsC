using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class ReceiptsPageButtonFunctionalTests : TestBase
    {
        private LoginPage _loginPage;
        private Menu _menuPage;
        private ReceiptPage _receiptPage;
        private TrashBoxPage _trashBoxPage;

       [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateReceiptDatabase();

            _loginPage = new LoginPage(Driver);
            _menuPage = new Menu(Driver);
            _receiptPage = new ReceiptPage(Driver);
            _trashBoxPage = new TrashBoxPage(Driver);

        }

        [Test, Category("Dream")]
        public void ViewReceiptButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickReceipts();
            _receiptPage.ClickViewReceipt();
            _receiptPage.SwitchToPreviewPopup();
            _receiptPage.ClickX();
        }

        [Test, Category("Dream")]
        public void DeleteReceiptButtonTest()
        {
            _loginPage.LogIn();

            _menuPage.ClickReceipts();
            var receiptName = _receiptPage.StoreReceiptName();
            _receiptPage.ClickDeleteReceipt();
            _menuPage.ClickTrashBox();
            _trashBoxPage.VerifyIfRowExists(receiptName);
        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
