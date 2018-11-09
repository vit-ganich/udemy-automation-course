using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;

namespace UdemyTestsContainer.Components.PageObjects
{
    public class SearchEngine : SeleniumHandler
    {
        public SearchEngine() { }
        public SearchEngine(string url)
        {
            try
            {
                GoToUrl(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Search(string keyword)
        {
            try
            {
                GetDisplayedElement(By.XPath("//*[@id='lst-ib']")).SendKeys("udemy");
                WaitForDisplayedElement(By.XPath("//*[@id='sbtc']//li")).Click();
                WaitForDisplayedElement(By.XPath("//*[@class='g']"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ValidateSearchResulst(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
