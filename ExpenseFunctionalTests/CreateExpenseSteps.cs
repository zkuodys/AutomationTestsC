using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using TechTalk.SpecFlow;

namespace ExpenseFunctionalTests
{
    [Binding]
    public class CreateExpenseSteps
    {
        private IWebDriver _driver;
        private CreateExpensePage _createExpensePage;
        private ReceiptPage _receiptPage;
        private MainPage _mainPage;

        [Given(@"I'm logged in as a user")]
        public void GivenIMLoggedInAsAUser()
        {
            _driver = new ChromeDriver();
            _createExpensePage = new CreateExpensePage(_driver);
            _receiptPage = new ReceiptPage(_driver);
            _mainPage = new MainPage(_driver);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
        
        [Given(@"I'm on create expense screen")]
        public void GivenIMOnCreateExpenseScreen()
        {
            _driver.Navigate().GoToUrl("http://localhost:7123/#!/dashboard/commonList/expenseFormEditable");
        }
        
        [Given(@"I have set date on receipt")]
        public void GivenIHaveSetDateOnReceipt()
        {
            _createExpensePage.SetDate("1990.09.09");
        }
        
        [Given(@"I have set currency")]
        public void GivenIHaveSetCurrency()
        {
            _createExpensePage.CurrencyClick();
        }
        
        [Given(@"I have set expense type")]
        public void GivenIHaveSetExpenseType()
        {
            _createExpensePage.ExpenseTypeClick();
        }
        
        [Given(@"I have set amount of money i've spent")]
        public void GivenIHaveSetAmountOfMoneyIVeSpent()
        {
            _createExpensePage.SetAmount("111.11");
        }
        
        [Given(@"I have filled the description")]
        public void GivenIHaveFilledTheDescription()
        {
            _createExpensePage.SetDescription("taip ir taip");
        }
        
        [When(@"I press send button")]
        public void WhenIPressSendButton()
        {
            _createExpensePage.OptionButtonClick();
        }
        
        [Then(@"Expense should be created")]
        public void ThenExpenseShouldBeCreated()
        {
            _createExpensePage.MoreOptionButtonClick();
        }
    }
}
