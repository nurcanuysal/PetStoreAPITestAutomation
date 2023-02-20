using Newtonsoft.Json;
using RestSharp;

namespace PetStoreTest.Helpers
{
    public class Response<T>
    {
        public Entities GetResponseContent<Entities>(RestResponse response)
        {
            var content = response.Content;
            Entities entitiesObject = JsonConvert.DeserializeObject<Entities>(content);
            return entitiesObject;
        }
    }
}



