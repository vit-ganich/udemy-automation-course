using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverWrapper;

namespace UdemyAutomationProject
{
    [TestClass]
    [DeploymentItem("IEDriverServer.exe")]
    [DeploymentItem("ChromeDriver.exe")]
    public class SeleniumBasicImplementationSamples
    {
        public TestContext TestContext { get; set; }

        public static IWebDriver GetFirefoxDriver()
        {
            IWebDriver webDriver = new FirefoxDriver();
            return webDriver;
        }

        //[TestInitialize]
        //public void WebDriverInitializeBeforeTest()
        //{
        //    ObjectRepository.WebDriver = GetFirefoxDriver();
        //}

        //[TestCleanup]
        //public void WebDriverCloseAfterTest()
        //{
        //    if (ObjectRepository.WebDriver != null)
        //    {
        //        ObjectRepository.WebDriver.Close();
        //        ObjectRepository.WebDriver.Quit();
        //        ObjectRepository.WebDriver = null;
        //    }
        //}

        [TestMethod]
        public void WebDriverSample()
        {
            IWebDriver webDriver = new FirefoxDriver();
            Thread.Sleep(1000);
            webDriver.Dispose();

            webDriver = new InternetExplorerDriver();
            Thread.Sleep(1000);
            webDriver.Dispose();

            webDriver = new ChromeDriver();
            Thread.Sleep(1000);
            webDriver.Dispose();
        }

        [TestMethod]
        public void WebElementSamples()
        {
            var webDriver = ObjectRepository.WebDriver;
            //Actions builder = new Actions(webDriver);
            webDriver.Navigate().GoToUrl("https://www.lastminutetravel.com/packages");
            webDriver.Manage().Window.Maximize();

            var radioButton = webDriver.FindElement(By.XPath("//*[@id='packages']/div/div[4]/div[1]/label"));
            radioButton.Click();

            Assert.AreNotEqual(true, radioButton.Selected);

            // Enter the city, than wait till the autocomplete menu appears
            webDriver.FindElement(By.XPath("//*[@id='autosuggest-flightsFrom']")).SendKeys("New York");
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='autosuggest-flightsTo']")).SendKeys("Miami");
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']")).Click();
     
            Thread.Sleep(2000);
            // Date of depart - return
            var textBoxDepart = webDriver.FindElement(By.XPath("//*[@id='checkInDateInput']"));
            textBoxDepart.Click();

            var dateDepart = webDriver.FindElement
                (By.XPath("//*[@id='dateRangeWrapper']/div/div/div[2]/div/div/div[3]/div/div[2]/table/tbody/tr[3]/td[2]"));
            Thread.Sleep(1000);
            dateDepart.Click();

            var dateReturn = webDriver.FindElement
                (By.XPath("//*[@id='dateRangeWrapper']/div/div/div[2]/div/div/div[3]/div/div[2]/table/tbody/tr[3]/td[7]"));
            Thread.Sleep(1000);
            dateReturn.Click();

            // 1 Room, 2 Guests
            webDriver.FindElement(By.XPath("//*[@id='occupancyField']/span[1]")).Click();

            var comboBox = webDriver.FindElement(By.XPath("//*[@id='packages']/div/div[1]/div/div/div[2]/div[2]/select"));

            var selectElement = new SelectElement(comboBox);
            selectElement.SelectByIndex(1);
            Thread.Sleep(1000);
            // OK
            webDriver.FindElement(By.XPath("//*[@class='okBtn']")).Click();
            Thread.Sleep(1000);
            // Find
            webDriver.FindElement(By.XPath("//*[@id='findPackages']")).Click();
        }

        [TestMethod]
        public void JsonObjectSample()
        {
            var jsonSample = new SeleniumWrapper();
            jsonSample.ParseJson("{\"FirstName\": \"Vitali\", \"SecondName\": \"Hanich\", \"Age\": 28, \"LikeThisCourse\": true}");
        }

        [TestMethod]
        public void SeleniumHandlerSamples()
        {
            var handler = new SeleniumHandler();
        }
    }
}
