using System.Threading;
using OpenQA.Selenium;

namespace ExpenseFunctionalTests.Infrastructure
{
    public abstract class PageBase : WebOperationsBase
    {
        protected PageBase(IWebDriver driver) : base(driver)
        {
        }

        public void WaitForAngular()
        {
            Thread.Sleep(1000);   // :)
        }
    }
}
