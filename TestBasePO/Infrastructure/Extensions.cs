using ExpenseFunctionalTests.Infrastructure.Utils;
using OpenQA.Selenium;

namespace ExpenseFunctionalTests.Infrastructure
{
    public static class Extensions
    {
        public static T Execute<T>(this IWebDriver driver, string script)
        {
            return (T)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static GridComponentUtils GridUtils(this IWebElement element)
        {
            return new GridComponentUtils(element);
        }

    }
}
