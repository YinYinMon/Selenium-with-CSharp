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
    public class SortingTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("https://fakestoreapi.com");
        }

        [Test]
        public void TestGetSortedProducts_Ascending()
        {
            var response = _apiClient.SendRequest("/products?sort=asc", Method.Get);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            var products = JArray.Parse(response.Content);

            for (int i = 1; i < products.Count; i++)
            {
                int currentId = (int)products[i]["id"];
                int previousId = (int)products[i - 1]["id"];
                Assert.IsTrue(currentId >= previousId, "Products are not sorted!");
            }
        }

        [Test]
        public void TestGetProductsSortedProducts_Descending()
        {
            var response = _apiClient.SendRequest("/products?sort=desc", Method.Get);

            // Assert the response status code to be 200 (OK)
            Assert.AreEqual(200, (int)response.StatusCode);

            var products = JArray.Parse(response.Content);

            for (int i = 1; i < products.Count; i++)
            {
                int currentId = (int)products[i]["id"];
                int previousId = (int)products[i - 1]["id"];
                Assert.IsTrue(currentId <= previousId, "Products are not sorted!");
            }
        }

        [Test]
        public void TestGetProductsSortedProducts_InvalidSorting()
        {
            var response = _apiClient.SendRequest("/products?sort=invalid", Method.Get);

            // Assert the response status code to be 400 (Bad Request)
            Assert.AreEqual(400, (int)response.StatusCode);
        }

    }
}
