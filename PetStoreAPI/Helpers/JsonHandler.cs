using System;
using Newtonsoft.Json;

namespace PetStoreAPI.Helpers
{
    public static class JsonHandler
    {
        public static string Serialize<T>(T body)
        {
            return JsonConvert.SerializeObject(body, Formatting.Indented);
        }
    }
}

