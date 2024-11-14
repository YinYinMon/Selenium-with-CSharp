using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest_SauceDemo.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;
        private By addToCartButtons = By.CssSelector(".inventory_item button");
        private By cartIcon = By.Id("shopping_cart_container");


        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddProductsToCart(int numberOfProducts)
        {
            var buttons = _driver.FindElements(addToCartButtons);
            for (int i = 0; i < numberOfProducts && i < buttons.Count; i++)
            {
                buttons[i].Click();
            }
        }
        public void OpenCart()
        {
           _driver.FindElement(cartIcon).Click();
        }
    }
}