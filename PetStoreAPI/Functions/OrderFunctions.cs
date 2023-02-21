using System;
using Newtonsoft.Json.Linq;
using PetStoreAPI.Helpers;
using PetStoreAPI.Modals;
using System.Net;
using RestSharp;
using PetStoreAPI.Models;
using System.Net.NetworkInformation;
using FluentAssertions;

namespace PetStoreAPI.Functions
{
	public class OrderFunctions
	{
        public RestResponse PlaceAnOrderForAPet(Order body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var jsonBody = JsonHandler.Serialize(body);
            var request = new RestRequest("/store/order/", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);

            return response;
        }

        public RestResponse PetInventoryByStatus(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/store/order/", Method.Get);

            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response;
        }

        public string DeletePurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/store/order/" + orderId.ToString(), Method.Delete);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            return response.Content;
        }

        public RestResponse FindPurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/store/order/" + orderId.ToString(), Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            return response;
        }
    }
}

