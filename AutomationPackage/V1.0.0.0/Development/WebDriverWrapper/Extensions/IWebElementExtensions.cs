using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper.Extensions
{
    public static class IWebElementExtensions
    {
        public static SelectElement ComboBox(this IWebElement webElement)
        {
            try
            {
                return new SelectElement(webElement);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Actions Actions(this IWebElement webElement)
        {
            try
            {
                var driver = ((IWrapsDriver)webElement).WrappedDriver;
                var actions = new Actions(driver);
                actions.MoveToElement(webElement);
                return actions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Actions ContextClick(this IWebElement webElement)
        {
            try
            {
                var driver = ((IWrapsDriver)webElement).WrappedDriver;
                var actions = new Actions(driver);
                actions.MoveToElement(webElement).ContextClick().Perform();
                return actions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
