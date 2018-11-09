using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverWrapper.Extensions
{
    public static class IWebDriverExtensions
    {
        public static void ScrollBrowserPage(this IWebDriver driver, int scrollLength)
        {
            try
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript(string.Format("window.scroll(0,{0});", scrollLength.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BannersListener(this IWebDriver driver, By by, int interval = 500)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    while (driver != null)
                    {
                        try
                        {
                            driver.FindElements(by).ToList().ForEach(element => { element.Click(); });
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(interval);
                        }
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubmitForm(this IWebDriver driver, string formId)
        {
            try
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript(string.Format("document.forms[\"{0}\"].submit();", formId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubmitForm(this IWebDriver driver, int formIndex)
        {
            try
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript(string.Format("document.forms[{0}].submit();", formIndex.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ExecuteScript(this IWebDriver driver, string script, params object[] args)
        {
            try
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
