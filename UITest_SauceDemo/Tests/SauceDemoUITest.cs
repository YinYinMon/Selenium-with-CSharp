using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITest_SauceDemo.Pages;
using UITest_SauceDemo.PO;
using UITest_SauceDemo.Utilities;
using OpenQA.Selenium.Chrome;

namespace UITest_SauceDemo.Tests
{
    public class SauceDemoUITest : BaseTest
    {
        public void PageObjects()
        {

        }
        [Test]
        public void StartToEndPurchaseWorkFlow()
        {
            //Page Objects
            var loginPage = new LoginPage(Driver);
            var productsPage = new ProductPage(Driver);
            var cartPage = new CartPage(Driver);
            var checkoutPage = new CheckoutPage(Driver);

            //Test Working Flow
            //Navigate to SauceDemo page
            loginPage.OpenLoginPage("https://www.saucedemo.com/");

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Apply Valid Credentials
            loginPage.Login("standard_user", "secret_sauce");

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Add Products to Cart
            productsPage.AddProductsToCart(2);

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Open Cart
            productsPage.OpenCart();

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Check items in Cart
            var cartItems = cartPage.GetCartItems();
            Assert.IsTrue(cartItems.Count > 0, "Cart should not be empty");

            // Verify the "Sauce Labs Backpack" is in the cart
            bool isBackpackPresent_Cart = checkoutPage.IsItemInCart("Sauce Labs Backpack");
            Assert.IsTrue(isBackpackPresent_Cart, "Sauce Labs Backpack is not in the cart");

            // Verify the "Sauce Labs Bike Light" is in the cart
            bool isBikeLightPresent_Cart = checkoutPage.IsItemInCart("Sauce Labs Bike Light");
            Assert.IsTrue(isBikeLightPresent_Cart, "Sauce Labs Bike Light is not in the cart");

            //Click "Checkout" 
            checkoutPage.ProceedToCheckout();

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Apply information
            checkoutPage.FillCheckoutDetails("Yin Yin", "Mon", "10240");

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            // Verify the "Sauce Labs Backpack" is in the Check : Overview
            bool isBackpackPresent = checkoutPage.IsItemInCart("Sauce Labs Backpack");
            Assert.IsTrue(isBackpackPresent, "Sauce Labs Backpack is not in the cart");

            // Verify the "Sauce Labs Bike Light" is in the Check : Overview
            bool isBikeLightPresent = checkoutPage.IsItemInCart("Sauce Labs Bike Light");
            Assert.IsTrue(isBikeLightPresent, "Sauce Labs Bike Light is not in the cart");

            //Scroll to view Finish button
            checkoutPage.ScrollViewFinish();

            //Check Total Price
            string totalPrice = checkoutPage.GetTotalPrice();
            Assert.IsNotNull(totalPrice, "Total price should be displayed");

            //Finish purchase
            checkoutPage.ComplePurchase();

            //Check Product order is success
            string Success_FinalPage = checkoutPage.GetSuccss();
            Assert.AreEqual("Back Home", Success_FinalPage);

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void StartToEndPurchaseWorkFlow_NoSelectionProducts()
        {
            //Page Objects
            var loginPage = new LoginPage(Driver);
            var productsPage = new ProductPage(Driver);
            var cartPage = new CartPage(Driver);
            var checkoutPage = new CheckoutPage(Driver);

            //Test Working Flow
            //Navigate to SauceDemo page
            loginPage.OpenLoginPage("https://www.saucedemo.com/");

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Apply Valid Credentials
            loginPage.Login("standard_user", "secret_sauce");

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            //Open Cart
            productsPage.OpenCart();

            // Sleep for 1 second
            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(false,checkoutPage.Visible_Checkout());
        }
    }
}
