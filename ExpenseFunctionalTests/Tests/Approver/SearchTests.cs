using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Pages.ApproverPages;
using ExpenseFunctionalTests.Pages.UserPages;
using NUnit.Framework;

namespace ExpenseFunctionalTests.Tests.User
{
    [TestFixture]
    public class SearchTests : TestBase
    {
        private HeaderPage _headerPage;
        private ApproverLoginPage _approverloginPage;
        private ApproverMenu _approverMenu;
        private PaidPage _paidPage;


       [SetUp]
        public override void BeforeTest()
        {
            _headerPage = new HeaderPage(Driver);
            _approverloginPage = new ApproverLoginPage(Driver);
            _approverMenu = new ApproverMenu(Driver);
            _paidPage = new PaidPage(Driver);
        }

        [Test, Category("MinionsTeam")]
        public void SearchByTitleTest()
        {
            _approverloginPage.LogIn();
            _approverMenu.ClickPaidButton();
            _paidPage.SetSearchByTitle("receipt");
            _paidPage.ClickSearchButton();
            //_paidPage.VerifyRowsNumber();
        }

        [Test, Category("MinionsTeam")]
        public void SearchByEmailTest()
        {
            _approverloginPage.LogIn();
            _approverMenu.ClickPaidButton();
            _paidPage.SetSearchByEmail("expenses");
            _paidPage.ClickSearchButton();
            //_paidPage.VerifyRowsNumber();
        }

        [Test, Category("MinionsTeam")]
        public void SearchByTitleAndEmailTest()
        {
            _approverloginPage.LogIn();
            _approverMenu.ClickPaidButton();
            _paidPage.SetSearchByTitle("download");
            _paidPage.SetSearchByEmail("expenses");
            _paidPage.ClickSearchButton();
            //_paidPage.VerifyRowsNumber();
        }

        public override void AfterTest()
        {
        }
    }
}
