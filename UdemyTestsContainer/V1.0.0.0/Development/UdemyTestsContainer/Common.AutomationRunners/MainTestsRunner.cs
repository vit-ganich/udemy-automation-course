using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UdemyTestsContainer.Common.AutomationSequences;

namespace UdemyTestsContainer.Common.AutomationRunners
{
    /// <summary>
    /// Summary description for MainTestsRunner
    /// </summary>
    [TestClass]
    [DeploymentItem("Resources.WebDrivers\\ChromeDriver.exe")]
    [DeploymentItem("Resources.WebDrivers\\IEDriverServer.exe")]
    [DeploymentItem("Resources.WebDrivers\\MicrosoftWebDriver.exe")]
    [DeploymentItem("Resources.WebDrivers\\PhantomJSDriver.exe")]
    [DeploymentItem("Resources.WebDrivers\\geckodriver.exe")] // Firefox Driver - need to be handled like the other drivers (selenium 3 and above)
    public class MainTestsRunner
    {
        public MainTestsRunner()
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
        public void SearchForUdemyOnTheWeb()
        {
            var testCase = new SearchForUdemyOnTheWeb();
            var actual = testCase.AutomationSequence();

            Assert.AreEqual(true, actual);
        }
    }
}
