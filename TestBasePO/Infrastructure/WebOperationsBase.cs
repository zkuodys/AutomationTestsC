using OpenQA.Selenium;

namespace ExpenseFunctionalTests.Infrastructure
{

    public abstract class WebOperationsBase
    {
        protected internal static IWebDriver Driver { get; set; }

        protected WebOperationsBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public static IWebDriver GetDriver()
        {
            return Driver;
        }

    }
}
