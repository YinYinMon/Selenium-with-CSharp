using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest_SauceDemo.Pages
{
    public class CheckoutPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;
        private By firstNameField = By.Id("first-name");
        private By lastNameField = By.Id("last-name");
        private By postalCodeField = By.Id("postal-code");
        private By continueButton = By.Id("continue");
        private By finishButton = By.Id("finish");
        private By summaryItems = By.CssSelector(".cart_item");
        private By totalPrice = By.CssSelector(".summary_total_label");
        private By finalSuccess = By.Id("back-to-products");
        private By checkoutButton = By.Id("checkout");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
        }
        
        public bool Visible_Checkout()
        {
            return _driver.FindElement(checkoutButton).Displayed;
        }

        public void ProceedToCheckout()
        {
            _driver.FindElement(checkoutButton).Click();
        }

        public void FillCheckoutDetails(string firstName, string lastName, string postalCode)
        {
            _driver.FindElement(firstNameField).SendKeys(firstName);
            _driver.FindElement(lastNameField).SendKeys(lastName);
            _driver.FindElement(postalCodeField).SendKeys(postalCode);
            _driver.FindElement(continueButton).Click();
        }

        public bool ValidateItems(List<string> expectedItems)
        {
            var actualItems = _driver.FindElements(summaryItems).Select(item
                 => item.Text).ToList();
            return !expectedItems.Except(actualItems).Any();
        }

        public bool IsItemInCart(string itemName)
        {
            try
            {
                // Check if item exists in the cart by locating the item name
                IWebElement item = _driver.FindElement(By.XPath($"//div[contains(text(), '{itemName}')]"));
                return item != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetTotalPrice()
        {
            return _driver.FindElement(totalPrice).Text;
        }

        public void ScrollViewFinish()
        {
            wait.Until(driver => driver.FindElement(finishButton).Displayed);
        }

        public void ComplePurchase()
        {
            _driver.FindElement(finishButton).Click();  
        }

        public string GetSuccss()
        {
            return _driver.FindElement(finalSuccess).Text;
        }
    }
}
