using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ClassLibrary1
{
    [Binding]
    public class SpecFlowSteps
    {
        private IWebDriver _driver;
        [Given(@"I'm on login website")]
        public void GivenIMOnLoginWebsite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://hd.aursad.eu/site/staff");
        }
        
        [Given(@"I have entered username")]
        public void GivenIHaveEnteredUsername()
        {
            _driver.FindElement(By.Id("LoginForm_username")).SendKeys("JP@hd.lt");
        }
        
        [Given(@"I have entered password")]
        public void GivenIHaveEnteredPassword()
        {
            _driver.FindElement(By.Id("LoginForm_password")).SendKeys("3A90XiBS2h");
        }
        
        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            _driver.FindElement(By.ClassName("btn-primary")).Click();
        }
        
        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.Equal("HelpDesk - Kreipiniai", _driver.Title);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
