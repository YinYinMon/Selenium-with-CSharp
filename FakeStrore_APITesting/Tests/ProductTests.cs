using FakeStrore_APITesting.TestModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FakeStrore_APITesting;
using FakeStrore_APITesting.ApiClientNameSpace;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FakeStrore_APITesting.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("https://fakestoreapi.com");
        }

        //Check Get all products
        [Test]
        public void TestGetAllProducts()
        {
            //Sending GET request to retrieve all products
            var response = _apiClient.SendRequest("/products", Method.Get);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            //Check products 
            var products = JArray.Parse(response.Content);
            Assert.IsTrue(products.Count > 0, "No products found!");
        }


        //Check Get all products with wrong endpoints
        [Test]
        public void TestGetAllProducts_InvalidEndpoints()
        {
            //Sending GET request to retrieve all products
            var response = _apiClient.SendRequest("/productsss", Method.Get);

            // Assert the response status code to be 404 (Not Found)
            Assert.AreEqual(404, (int)response.StatusCode);
        }

        //Check Get a single product
        [Test]
        public void TestGetSingleProducts()
        {
            int productId = 1;

            // Sending GET request to retrieve a single product by ID
            var response = _apiClient.SendRequest($"/products/{productId}", Method.Get);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            // Ensure the response content is not null or empty
            if (string.IsNullOrEmpty(response.Content))
            {
                Assert.Fail("Response content is empty or null");
            }

            // Parse the JSON response and assert certain fields
            var productResponse = JObject.Parse(response.Content);
            Assert.AreEqual(productId, (int)productResponse["id"]);  // Assert the product ID
            Assert.IsNotNull(productResponse["title"]);  // Ensure the product has a title
            Assert.IsNotNull(productResponse["price"]);  // Ensure the product has a price
        }

        //Check Add new product with valid data
        [Test]
        public void TestPostProduct_ValidData()
        {
            var newProduct = new ProductModel
            {
                Title = "New Product",
                Price = 29.99,
                Description = "A sample product",
                Image = "https://i.pravatar.cc",
                Category = "electronics"
            };

            //Sending POST request to create a new product
            var response = _apiClient.SendRequest("/products", Method.Post, newProduct);

            // Assert the response status code to be 201 (Created)
            Assert.AreEqual(201, (int)response.StatusCode);

            //Check created product
            var createdProduct = JObject.Parse(response.Content);
            Assert.AreEqual(newProduct.Title, createdProduct["title"].ToString());
        }

        //Check Add new product with invalid data
        [Test]
        public void TestPostProduct_InvalidData()
        {
            var newProduct = new ProductModel
            {
                Title = "New Product",
            };

            //Sending POST request to create a new product
            var response = _apiClient.SendRequest("/products", Method.Post, newProduct);

            // Assert the response status code to be 400 (Bad Request)
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        //Check Update a product that is already having in list
        [Test]
        public void TestPutProduct_ExistingProduct()
        {
            int productId = 1;
            var updatedProduct = new ProductModel
            {
                Title = "Updated Product",
                Price = 39.99,
                Description = "An updated description",
                Image = "https://i.pravatar.cc",
                Category = "furniture"
            };

            //Sending PUT request to update a product
            var response = _apiClient.SendRequest($"/products/{productId}", Method.Put, updatedProduct);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            //Check updated product
            var updatedProductResponse = JObject.Parse(response.Content);
            Assert.AreEqual(updatedProduct.Title, updatedProductResponse["title"].ToString());
        }


        //Check Update a product that is not having in list
        [Test]
        public void TestPutProduct_NonExistingProduct()
        {
            int productId = 999999;
            var updatedProduct = new ProductModel
            {
                Title = "Updated Product",
                Price = 39.99,
                Description = "An updated description",
                Image = "https://i.pravatar.cc",
                Category = "furniture"
            };

            //Sending PUT request to update a product
            var response = _apiClient.SendRequest($"/products/{productId}", Method.Put, updatedProduct);

            // Assert the response status code to be 404 (Not Found)
            Assert.AreEqual(404, (int)response.StatusCode);
        }

        //Check Delete a product that is having in list
        [Test]
        public void TestDelete_ExistingProduct()
        {
            int productId = 3;
            var response = _apiClient.SendRequest($"/products/{productId}", Method.Delete);

            // Log response content for debugging
            Console.WriteLine(response.Content); // Add this line to check the content

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        //Check Delete a product that is not having in list
        [Test]
        public void TestDelete_NonExistingProduct()
        {
            int productId = 9999999;
            var response = _apiClient.SendRequest($"/products/{productId}", Method.Delete);

            // Log response content for debugging
            Console.WriteLine(response.Content); // Add this line to check the content

            // Assert the response status code to be 404 (Not Found)
            Assert.AreEqual(404, (int)response.StatusCode);
        }
    }
}
