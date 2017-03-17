using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using ExpenseFunctionalTests.Infrastructure;
using NUnit.Framework;
using System;

namespace ExpenseFunctionalTests.Pages.UserPages
{
    public class UploadReceiptsPage : PageBase
    {
        private IWebDriver _driver;

        public UploadReceiptsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        //UploadReceiptsPage selectors
        
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='file-upload-browse-button']")]
        protected IList<IWebElement> BrowseButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='upload-receipts-btn']")]
        protected IWebElement UploadReceiptsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='upload-status-message']")]
        protected IWebElement UploadMessage { get; set; }

        //UploadReceiptsPage methods

        public UploadReceiptsPage SetUploadFile()
        {
            WaitForAjax();
            UploadReceiptsButton.Click();

            string jsCmd = @"return document.evaluate(""//input[@name='file']/.."", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.style = """"";
            _driver.Execute<string>(jsCmd);
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = "Image\\AutomatedTestData.jpg";
            var fileInput = _driver.FindElement(By.XPath(".//input[@name='file']"));
            fileInput.SendKeys(currentDirectory + "\\" + filePath);
            return this;
        }

        public string GetUploadMessageText()
        {
            return UploadMessage.Text;
        }

        public void AssertUploadSucessMessage()
        {
            WaitForAjax();
            Assert.IsTrue(GetUploadMessageText().Contains("Upload successful"), "File didn't upload");
        }

    }
}