using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using WebDriverWrapper;
using WebDriverWrapper.Extensions;

namespace UdemyAutomationProject
{
    /// <summary>
    /// Summary description for SeleniumBasicImplementationSamples
    /// </summary>
    [TestClass]
    [DeploymentItem("IEDriverServer.exe")]
    [DeploymentItem("ChromeDriver.exe")]
    [DeploymentItem("GeckoDriver.exe")]
    public class SeleniumBasicImplementationSamples : SeleniumHandler
    {
        public SeleniumBasicImplementationSamples()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void WebDriverSample()
        {
            //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            IWebDriver webDriver = new FirefoxDriver(/*binary, new FirefoxProfile()*/);
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
            //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            IWebDriver webDriver = new FirefoxDriver(/*binary, new FirefoxProfile()*/);
            webDriver.Navigate().GoToUrl("http://www.lastminutetravel.com");

            var radioButton = webDriver.FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']"));
            radioButton.Click();

            Assert.AreEqual(true, radioButton.Selected);

            webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom']")).SendKeys("New York");
            webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom_Combo']/div[1]/span/span[2]")).Click();


            webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo']")).SendKeys("Miami");
            webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo_Combo']/div[1]/span/span[2]")).Click();

            var textBox = webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_departDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));

            textBox = webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_returnDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(33).ToString("MM/dd/yyyy"));

            var comboBox = webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_departTime']"));
            var selectElement = new SelectElement(comboBox);
            selectElement.SelectByIndex(4);

            comboBox = webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_returnTime']"));
            selectElement = new SelectElement(comboBox);
            selectElement.SelectByValue("0;6");

            var checkBox = webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_cbNonStop']"));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);

            webDriver.FindElement(By.XPath("//*[@id='TGS_pfhr_butSearch']")).Click();

            webDriver.Dispose();
        }

        [TestMethod]
        public void JsonObjectSample()
        {
            var jsonSample = new SeleniumWrapper();
            jsonSample.ParseJson
                ("{\"FirstName\":\"Roei\",\"LastName\":\"Sabag\",\"Age\":34,\"LikeThisCourse\":true}");
        }

        [TestMethod]
        public void SeleniumHandlerSamples()
        {
            var drivers = new List<string>();
            drivers.Add("{\"Driver\":\"Firefox\"}");
            drivers.Add("{\"Driver\":\"IE\"}");
            drivers.Add("{\"Driver\":\"Chrome\"}");

            drivers.ForEach(_driver =>
            {
                var handler = new SeleniumHandler();
                handler.WebDriverParams = _driver;
                var driver = handler.WebDriver;
                try
                {
                    driver.Navigate().GoToUrl("http://www.lastminutetravel.com/hp2.aspx");
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.XPath("//*[@id='_ctl0_ucMNB_repTabs__ctl1_hlTab']")).Click();
                }
                catch (Exception)
                {
                    throw;
                }
                finally { driver.Dispose(); }
            });
        }

        [TestMethod]
        public void SearchHotelsWithWrapper()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var radioButton = FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']"));
            radioButton.Click();

            Assert.AreEqual(true, radioButton.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom']")).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom_Combo']/div[1]/span/span[2]")).Click();

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo']")).SendKeys("Miami");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo_Combo']/div[1]/span/span[2]")).Click();

            var textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_departDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));

            textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_returnDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(33).ToString("MM/dd/yyyy"));

            FindElement(By.XPath("//*[@id='TGS_pfhr_departTime']")).ComboBox().SelectByIndex(4);
            FindElement(By.XPath("//*[@id='TGS_pfhr_returnTime']")).ComboBox().SelectByValue("0;6");

            var checkBox = FindElement(By.XPath("//*[@id='TGS_pfhr_cbNonStop']"));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_butSearch']")).Click();

            Assert.AreNotEqual(0, FindElements(By.XPath("//*[@id='ext-comp-1002']/div[@style='width:100%']")).Count);

            WebDriver.Dispose();
        }

        [TestMethod]
        public void FindElementsSamples()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var elements = FindElements(By.XPath("//input[@type='radio']"));

            foreach (var element in elements)
            {
                element.Click();
            }
        }

        [TestMethod]
        public void GetDisplayedElementSample()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var xpath = "//*[contains(@id,'_txtDestination')]";

            GetDisplayedElement(By.XPath(xpath)).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_h_txtDestination_Combo']/div[1]/span/span[2]")).Click();

            var radioButton = FindElement(By.XPath("//*[@id='TGS_sb_pHRImg']"));
            radioButton.Click();

            GetDisplayedElement(By.XPath(xpath)).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_phr_txtDestination_Combo']/div[1]/span/span[2]")).Click();
        }

        [TestMethod]
        public void GetDisplayedElementsSample()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var elements = GetDisplayedElements(By.XPath("//input[@type='radio']"));

            foreach (var element in elements)
            {
                element.Click();
            }
        }

        [TestMethod]
        public void WaitForDispalyedElementSample()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var radioButton = FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']"));
            radioButton.Click();

            Assert.AreEqual(true, radioButton.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom']")).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom_Combo']/div[1]/span/span[2]")).Click();

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo']")).SendKeys("Miami");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo_Combo']/div[1]/span/span[2]")).Click();

            var textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_departDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));

            textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_returnDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(33).ToString("MM/dd/yyyy"));

            FindElement(By.XPath("//*[@id='TGS_pfhr_departTime']")).ComboBox().SelectByIndex(4);
            FindElement(By.XPath("//*[@id='TGS_pfhr_returnTime']")).ComboBox().SelectByValue("0;6");

            var checkBox = FindElement(By.XPath("//*[@id='TGS_pfhr_cbNonStop']"));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_butSearch']")).Click();
            WaitForDisplayedElement(By.XPath("//*[@id='spanPackagesSearchResults']")).Click();
            WebDriver.Dispose();
        }

        [TestMethod]
        public void ScrollPageSample()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            var radioButton = FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']"));
            radioButton.Click();

            Assert.AreEqual(true, radioButton.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom']")).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom_Combo']/div[1]/span/span[2]")).Click();

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo']")).SendKeys("Miami");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo_Combo']/div[1]/span/span[2]")).Click();

            var textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_departDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));

            textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_returnDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(33).ToString("MM/dd/yyyy"));

            FindElement(By.XPath("//*[@id='TGS_pfhr_departTime']")).ComboBox().SelectByIndex(4);
            FindElement(By.XPath("//*[@id='TGS_pfhr_returnTime']")).ComboBox().SelectByValue("0;6");

            var checkBox = FindElement(By.XPath("//*[@id='TGS_pfhr_cbNonStop']"));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_butSearch']")).Click();

            Assert.AreNotEqual(0, FindElements(By.XPath("//*[@id='ext-comp-1002']/div[@style='width:100%']")).Count);

            for (int i = 1; i < 5; i++)
            {
                WebDriver.ScrollBrowserPage(2000 * i);
                Thread.Sleep(500);
            }
            WebDriver.Dispose();
        }

        [TestMethod]
        public void ActionsSmaple()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            //FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']")).Actions().ContextClick().Perform();

            FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']")).ContextClick();

            Thread.Sleep(5000);
            WebDriver.Dispose();
        }

        [TestMethod]
        public void BannersSample()
        {
            WebDriverParams = "{\"Driver\":\"Firefox\"}";
            GoToUrl("http://www.lastminutetravel.com");

            WebDriver.BannersListener(By.XPath("//*[@id='optimizely_add_close']"));

            var radioButton = FindElement(By.XPath("//*[@id='TGS_sb_pFHRImg']"));
            radioButton.Click();

            Assert.AreEqual(true, radioButton.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom']")).SendKeys("New York");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtFrom_Combo']/div[1]/span/span[2]")).Click();

            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo']")).SendKeys("Miami");
            FindElement(By.XPath("//*[@id='TGS_pfhr_txtTo_Combo']/div[1]/span/span[2]")).Click();

            var textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_departDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));

            textBox = FindElement(By.XPath("//*[@id='TGS_pfhr_returnDate']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(33).ToString("MM/dd/yyyy"));

            FindElement(By.XPath("//*[@id='TGS_pfhr_departTime']")).ComboBox().SelectByIndex(4);
            FindElement(By.XPath("//*[@id='TGS_pfhr_returnTime']")).ComboBox().SelectByValue("0;6");

            var checkBox = FindElement(By.XPath("//*[@id='TGS_pfhr_cbNonStop']"));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);

            FindElement(By.XPath("//*[@id='TGS_pfhr_butSearch']")).Click();

            Assert.AreNotEqual(0, FindElements(By.XPath("//*[@id='ext-comp-1002']/div[@style='width:100%']")).Count);

            WebDriver.Dispose();
        }
    }
}