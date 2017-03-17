using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using ExpenseFunctionalTests.Infrastructure;
using System;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class CreateExpensePage : PageBase
    {
        private IWebDriver _driver;
        private ReceiptPage _receiptPage;
        private Menu _menuPage;

        public CreateExpensePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
            _receiptPage = new ReceiptPage(Driver);
            _menuPage = new Menu(Driver);
        }

        //createExpense selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-title']")]
        protected IWebElement Title { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-supplier']")]
        protected IWebElement Supplier { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-invoice-number']")]
        protected IWebElement InvoiceNumber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-date']")]
        protected IWebElement Date { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='currency']/option[2]")]
        protected IWebElement CurrencyInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='expenses']/option[3]")]
        protected IWebElement ChooseExpenseType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='paymentMethod']/option[3]")]
        protected IWebElement PaymentMethod { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-amount']")]
        protected IWebElement Amount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-vat']")]
        protected IWebElement VAT { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-description']")]
        protected IWebElement Description { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='']")]
        protected IWebElement SaveButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-delete-option']")]
        protected IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-add-option']")]
        protected IWebElement MoreOptionsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='expense-send-form']")]
        protected IWebElement SendButton { get; set; }

        [FindsBy(How = How.Id, Using = "myModalLabel")]
        protected IWebElement ReceiptPreview { get; set; }

        [FindsBy(How = How.Id, Using = "myModalLabel")]
        protected IWebElement ExpensePreview { get; set; }
        //createExpense selectors

        //createExpense methods
        //public string StoreCreateReceiptName()
        //{
        //    createReceiptName = Title.Text;
        //    return createReceiptName;
        //}


        public string GetReceiptPreviewText()
        {
            return ReceiptPreview.Text;
        }

        public void AssertReceiptPreview(string text)
        {
            Assert.IsTrue(GetReceiptPreviewText().Contains(text), "Can't see preview!");
        }

        public string GetExpensePreviewText()
        {
            return ExpensePreview.Text;
        }

        public string GetCreatedReceiptName()
        {
            WaitForAjax();
            var title = Title.GetAttribute("value");
            return title;  
        }

        public CreateExpensePage AssertCreatedReceiptTitle(string name)
        {
            Assert.IsTrue(GetCreatedReceiptName().Contains(name));
            return this;
        }

        public CreateExpensePage SetDate(string setDate)
        {
            Date.Clear();
            Date.SendKeys(setDate);
            return this;
        }
        public CreateExpensePage SetInvoiceNumber(string setInvoiceNumber)
        {
            InvoiceNumber.Clear();
            InvoiceNumber.SendKeys(setInvoiceNumber);
            return this;
        }
        public CreateExpensePage SetTitle(string setDate)
        {
            Title.Clear();
            Title.SendKeys(setDate);
            return this;
        }

        public CreateExpensePage SetSupplier(string setSupplier)
        {
            Supplier.Clear();
            Supplier.SendKeys(setSupplier);
            return this;
        }


        public CreateExpensePage CurrencyClick()
        {
            CurrencyInput.Click();
            return this;
        }

        public CreateExpensePage ExpenseTypeClick()
        {
            ChooseExpenseType.Click();
            return this;
        }
        public CreateExpensePage PaymentMethodClick()
        {
            PaymentMethod.Click();
            return this;
        }

        public CreateExpensePage SetAmount(string setAmount)
        {
            Amount.SendKeys(setAmount);
            return this;
        }
        public CreateExpensePage SetVAT(string setVAT)
        {
            VAT.Clear();
            VAT.SendKeys(setVAT);
            return this;
        }

        public CreateExpensePage SetDescription(string setDescription)
        {
            Description.SendKeys(setDescription);
            return this;
        }

        public CreateExpensePage SaveButtonClick()
        {
            SaveButton.Click();
            return this;
        }


        public CreateExpensePage DeleteButtonClick()
        {
            DeleteButton.Click();
            return this;
        }


        public CreateExpensePage MoreOptionButtonClick()
        {
            MoreOptionsButton.Click();
            return this;
        }

        public CreateExpensePage SendButtonClick()
        {
            SendButton.Click();
            return this;
        }

        public void CreateExpense(string receiptName)
        {
            _menuPage.ClickReceipts();
            _receiptPage.ClickCreateNewExpense();
            this.SetTitle(receiptName);
            this.SetSupplier("UAB Supplier");
            this.SetInvoiceNumber("Nr.123");
            this.PaymentMethodClick();
            this.CurrencyClick();
            this.SetAmount("132.32");
            this.SetVAT("21.00");
            this.ExpenseTypeClick();
            this.SetDescription("Was traveling to train station.");
            this.SendButtonClick();
            WaitForAjax();
        }
        //createExpense methods
    }
}
