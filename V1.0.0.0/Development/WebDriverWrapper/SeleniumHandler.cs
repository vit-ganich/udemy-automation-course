using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper
{
    public class SeleniumHandler
    {
        private string webDriverParams = "{ \"Driver\":\"Firefox\" }";
        public string WebDriverParams
        {
            get { return webDriverParams; }
            set { webDriverParams = value; }
        }
        private IWebDriver webDriver = null;
        public IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = SetWebDriver();
                }
                return webDriver;
            }
        }

        private IWebDriver SetWebDriver()
        {
            throw new NotImplementedException();
        }
        private IWebDriver SetFirefoxDriver()
        {
            throw new NotImplementedException();
        }
        private IWebDriver SetChromeDriver()
        {
            throw new NotImplementedException();
        }
        private IWebDriver SetInternetExolorerDriver()
        {
            throw new NotImplementedException();
        }
    }
}
