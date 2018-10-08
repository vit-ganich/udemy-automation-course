using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace UdemyAutomationProject
{
    [TestClass]
    //[DeploymentItem("ChromeDriver.exe")]
    //[DeploymentItem("GeckoDriver.exe")]
    //[DeploymentItem("IEDriverServer.exe")]
    public class SeleniumBasicImplementationSamples
    {
        public SeleniumBasicImplementationSamples()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void WebDriverSample()
        {
            // We use an interface IWebDriver
            // webdriver.exe need to be in the same folder as the test container
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
    }
}
