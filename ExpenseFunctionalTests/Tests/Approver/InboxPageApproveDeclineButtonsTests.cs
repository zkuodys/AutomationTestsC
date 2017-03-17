using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.ApproverPages;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.Approver
{
    [TestFixture]
    public class InboxPageApproveDeclineButtonsTests : TestBase
    {
        private LoginPage _loginPage;
        private ApproverMenu _approverMenuPage;
        private InboxPage _inboxPage;
        private ApproveDeclinePage _approveDeclinePage;
        private ReadyForPaymentPage _readyForPaymentPage;
        private CreateExpensePage _createExpensePage;
        private Menu _menu;
        private ExpenseDraftsPage _expenseDraftsPage;

        [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateReceiptDatabase();

            _loginPage = new LoginPage(Driver);
            _menu = new Menu(Driver);
            _approverMenuPage = new ApproverMenu(Driver);
            _inboxPage = new InboxPage(Driver);
            _approveDeclinePage = new ApproveDeclinePage(Driver);
            _readyForPaymentPage = new ReadyForPaymentPage(Driver);
            _createExpensePage = new CreateExpensePage(Driver);
            _expenseDraftsPage = new ExpenseDraftsPage(Driver);
        }

        [Test, Category("DreamTeam")]
        public void ApproveButtonTest()
        {
            _loginPage.LogIn();

            _createExpensePage.CreateExpense("AutomatedTestData.jpg");

            _approverMenuPage.ClickInboxButton();
            _inboxPage.ClickViewReceipt("AutomatedTestData.jpg");
            _approveDeclinePage.ClickApproveButton();
            _approveDeclinePage.SetExpenseCoveredBy();
            _approveDeclinePage.ClickApproveModalOkButton();

            _approverMenuPage.ClickReadyForPaymentButton();
            _readyForPaymentPage.VerifyIfRowExists("AutomatedTestData.jpg");

        }

        [Test, Category("DreamTeam")]
        public void DeclineButtonTest()
        {
            _loginPage.LogIn();

            _createExpensePage.CreateExpense("AutomatedTestData.jpg");

            _approverMenuPage.ClickInboxButton();
            _inboxPage.ClickViewReceipt("AutomatedTestData.jpg");

            _approveDeclinePage.ClickDeclineButton();
            _approveDeclinePage.SetComment("Smth filled wrong");
            _approveDeclinePage.ClickDeclineModalOkButton();

            _menu.ClickExpenseDrafts();
            _expenseDraftsPage.VerifyIfRowExists("AutomatedTestData.jpg");
            

        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
