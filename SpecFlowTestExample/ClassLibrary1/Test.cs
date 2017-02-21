using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowDemo
{
    public class Test
    {
        [Fact]
        public void StartApplication()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://hd.aursad.eu/site/staff");
            driver.FindElement(By.Id("LoginForm_username")).SendKeys("JP@hd.lt");
            driver.FindElement(By.Id("LoginForm_password")).SendKeys("3A90XiBS2h");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.Equal("HelpDesk - Kreipiniai", driver.Title);

        }       
    }
}
