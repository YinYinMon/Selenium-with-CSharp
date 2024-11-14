using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest_SauceDemo.Pages
{
    public class CartPage
    {
        private IWebDriver _driver;
        private By cartItems = By.CssSelector(".cart_item");

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<string> GetCartItems()
        {
            return _driver.FindElements(cartItems).Select(item => item.Text).ToList();
        }

       
    }
}
