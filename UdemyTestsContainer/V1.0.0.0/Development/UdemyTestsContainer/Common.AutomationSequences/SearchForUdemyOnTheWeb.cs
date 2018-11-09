using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UdemyTestsContainer.Components.PageObjects;
using WebDriverWrapper;

namespace UdemyTestsContainer.Common.AutomationSequences
{
    public class SearchForUdemyOnTheWeb
    {
        public object AutomationSequence()
        {
            var sEngine = new SearchEngine("http://www.google.com");
            try
            {
                var actual = false;
                sEngine.Search("udemy");

                //var result = handler.WaitForDisplayedElement(By.XPath("//*[@class='g']"));
                //var results = handler.GetDisplayedElements(By.XPath("//*[@class='g']"));
                //Assert.IsFalse(results[0].Text.Contains("https://www.udemy.com"), "The first result is not for udemy.com");

                actual = true;
                return actual;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally { sEngine.WebDriver.Dispose(); }
        }
    }
}
