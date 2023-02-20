using RestSharp;
using PetStoreAPI.Models;
using PetStoreAPI.Helpers;

namespace PetStoreAPI.Functions;
public class PetFunctions
{
    public RestResponse FindPetById(long petId)
    {
        string url = "https://petstore.swagger.io/v2/";
        var client = new RestClient(url);
        var request = new RestRequest("/pet/" + petId.ToString(), Method.Get);

        request.AddHeader("Accept", "application/json");
        request.RequestFormat = DataFormat.Json;

        RestResponse response = client.Execute(request);
        return response;
    }

    public RestResponse FindPetByStatus(PetStatus status)
    {
        string url = "https://petstore.swagger.io/v2/";
        var client = new RestClient(url);
        var request = new RestRequest("/pet/findByStatus", Method.Get);

        request.AddHeader("Accept", "application/json");
        request.AddParameter("status", status);
        request.RequestFormat = DataFormat.Json;

        RestResponse response = client.Execute(request);
        return response;
    }

    public RestResponse AddNewPetToStore(Pet body)
    {
        string url = "https://petstore.swagger.io/v2/";
        var client = new RestClient(url);
        var request = new RestRequest("/pet", Method.Post);
        var jsonBody = JsonHandler.Serialize(body);
        request.AddHeader("Accept", "application/json");
        request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        request.RequestFormat = DataFormat.Json;

        RestResponse response = client.Execute(request);
        return response;
    }

    public RestResponse UpdatePet(Pet body)
    {
        string url = "https://petstore.swagger.io/v2/";
        var client = new RestClient(url);
        var request = new RestRequest("/pet", Method.Put);
        var jsonBody = JsonHandler.Serialize(body);
        request.AddHeader("Accept", "application/json");
        request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        request.RequestFormat = DataFormat.Json;

        RestResponse response = client.Execute(request);
        return response;
    }

    public RestResponse DeletePetById(long petId)
    {
        string url = "https://petstore.swagger.io/v2/";
        var client = new RestClient(url);
        var request = new RestRequest("/pet/" + petId.ToString(), Method.Delete);
        request.AddHeader("Accept", "application/json");
        request.RequestFormat = DataFormat.Json;

        RestResponse response = client.Execute(request);
        return response;
    }
}



