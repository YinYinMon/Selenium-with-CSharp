using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace FakeStrore_APITesting.ApiClientNameSpace
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse SendRequest(string endpoint, Method method, object body = null)
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Content-Type", "application/json");

            if (body != null)
                request.AddJsonBody(body);

            return _client.Execute(request);
        }
    }
}
