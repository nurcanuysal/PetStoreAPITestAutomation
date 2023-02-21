using System;
using Newtonsoft.Json.Linq;
using PetStoreAPI.Helpers;
using PetStoreAPI.Modals;
using System.Net;
using PetStoreAPI.Models;
using RestSharp;
using FluentAssertions;

namespace PetStoreAPI.Functions
{
    public class UserFunctions
    {

        public RestResponse GetUserByUsername(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/user/" + userName, Method.Get);

            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse UpdateUser(User body, string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/user/" + userName, Method.Put);

            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            return response;
        }

        public string DeleteUser(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            string url = "https://petstore.swagger.io/v2/";
            var client = new RestClient(url);
            var request = new RestRequest("/user/" + userName, Method.Delete);
            request.AddUrlSegment("username", userName);

            var response = client.Execute(request);

            //Assert
            response.StatusCode.Should().Be(expectedStatusCode);

            return response.Content;
        }
    }
}
