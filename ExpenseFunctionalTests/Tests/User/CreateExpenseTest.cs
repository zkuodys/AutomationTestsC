using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class CreateExpenseTest : TestBase
    {
        private Menu _menuPage;
        private ReceiptPage _receiptPage;
        private CreateExpensePage _createExpensePage;
        private LoginPage _loginPage;
        private AwaitingApprovalPage _awaitingApprovalPage;

       [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateReceiptDatabase();

            _menuPage = new Menu(Driver);
            _receiptPage = new ReceiptPage(Driver);
            _createExpensePage = new CreateExpensePage(Driver);
            _loginPage = new LoginPage(Driver);
            _awaitingApprovalPage = new AwaitingApprovalPage(Driver);  
        }

        [Test, Category("Dream")]
        public void TestCreateNewExpense()
        {
            _loginPage.LogIn();

            _createExpensePage.CreateExpense("AutomatedTestData.jpg");
           
            _menuPage.ClickAwaitingApproval();
           // _awaitingApprovalPage.VerifyIfRowExists("AutomatedTestData.jpg");
        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
