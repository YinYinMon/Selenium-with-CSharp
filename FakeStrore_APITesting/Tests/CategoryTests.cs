using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeStrore_APITesting.ApiClientNameSpace;

namespace FakeStrore_APITesting.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("https://fakestoreapi.com");
        }

        //Check Get all categories
        [Test]
        public void TestGetProductCategories()
        {
            var response = _apiClient.SendRequest("/products/categories", Method.Get);
            Assert.AreEqual(200, (int)response.StatusCode);

            var categories = JArray.Parse(response.Content);
            Assert.IsTrue(categories.Count > 0, "No categories found!");
        }

        //Check Get all categories with wrong endpoint
        [Test]
        public void TestGetProductCategories_InvalidEndpoints()
        {
            var response = _apiClient.SendRequest("/products/categoriees", Method.Get);
            Assert.AreEqual(404, (int)response.StatusCode);
        }

        //Check Get products in a specific category
        [Test]
        public void TestGetProductsByCategory()
        {
            string category = "jewelery";

            // Sending GET request to retrieve products in the 'jewelery' category
            var response = _apiClient.SendRequest($"/products/category/{category}", Method.Get);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            // Ensure the response content is not null or empty
            if (string.IsNullOrEmpty(response.Content))
            {
                Assert.Fail("Response content is empty or null");
            }

            // Parse the JSON response and check if the products are in the 'jewelery' category
            var productsResponse = JArray.Parse(response.Content);

            // Ensure that products are returned
            Assert.IsTrue(productsResponse.Count > 0, "No products found in the specified category");

            // Check if at least one product belongs to the 'jewelery' category
            foreach (var product in productsResponse)
            {
                Assert.AreEqual(category, product["category"].ToString().ToLower());
            }
        }
    }
}
