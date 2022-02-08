using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Payment.Base;
using RestSharp;
using System;
using System.IO;

namespace Payment.Utilities
{
    public static class APIHelper
    {
        public static string GetFilePath(string file)
        {
            return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, file).ToString();
        }

        public static DTO ParseJsonFile<DTO>(string file)
        {
            return JsonConvert.DeserializeObject<DTO>(File.ReadAllText(ProjectSettings.PAYLOADS_PATH + file));
        }

        public static DTO DeserializeObject<DTO>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<DTO>(response.Content);
        }

        public static string GetGUIDString()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GetResponseObject(this RestResponse response, string responseObject)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();
        }
    }
}
