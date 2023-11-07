using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KenesApi.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public dynamic GetOrder(string token,string id)
        {
            var client = new RestClient("https://externalapi.kenes.com/test/order/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = $"{{\"token\": \"{token}\"}}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetOrders(string token)
        {

            var client = new RestClient("https://externalapi.kenes.com/test/orders");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = $"{{\"token\": \"{token}\"}}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;




        }

        public string GetToken()
        {

            var client = new RestClient("https://externalapi.kenes.com/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic dGVzdDptZHVoODNoc0BzYzJAU2FjdDE=");
            IRestResponse response = client.Execute(request);

            dynamic d = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return d.access_token;
        }


    }
}
