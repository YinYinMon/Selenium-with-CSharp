using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest_SauceDemo.PO
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private By  usernameField = By.Id("user-name");
        private By  passwordField = By.Id("password");
        private By  loginButton = By.Id("login-button");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenLoginPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(usernameField).SendKeys(username);
            _driver.FindElement(passwordField).SendKeys(password);
            _driver.FindElement(loginButton).Click();
        }
    }
}
