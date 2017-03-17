using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExpenseFunctionalTests.Infrastructure
{
    public abstract class PageBase : WebOperationsBase
    {
        IWebDriver _driver;

        protected PageBase(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void WaitForAjax()
        {
            //Wait for angular is loaded
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(
                driver =>
                {
                    try
                    {
                        //Ajax.WaitVs().WaitUntilInvisible();
                        ((IJavaScriptExecutor)Driver).ExecuteAsyncScript("if(!window.angular){return;} var callback = arguments[arguments.length - 1];" + "angular.element(document.body).injector().get('$browser').notifyWhenNoOutstandingRequests(callback);");
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
        }
    }
}
