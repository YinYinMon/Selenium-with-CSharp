using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace UITest_SauceDemo.Utilities
{
    public class BaseTest : BaseTestBase
    {
        private IWebDriver driver;
        private const string url = "https://www.saucedemo.com/";
        public WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();  
            }
        }
    }
}
