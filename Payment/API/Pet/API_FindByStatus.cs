using Payment.Base;
using Payment.Model;
using Payment.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payment.API.Pet
{
    public class API_FindByStatus : BaseAPI
    {
        public List<Pets> responseBody;

        public API_FindByStatus()
        {
            restClient = new RestClient(ProjectSettings.BASE_URL);
            request = new RestRequest("/v2/pet/findByStatus", Method.Get);
        }

        public void SetStatusParameter(string value)
        {
            request.AddParameter("status", value);
        }

        public void Execute()
        {
            response = restClient.ExecuteAsync(request).GetAwaiter().GetResult();
            responseBody = APIHelper.DeserializeObject<List<Pets>>(response);
        }

        public int GetResponseStatusCode()
        {
            return (int)response.StatusCode;
        }

        public string GetFirstPetId()
        {
            SetStatusParameter("available");
            Execute();
            return responseBody[0].id.ToString();
        }

        public string GenerateInvalidPetId()
        {
            SetStatusParameter("available");
            Execute();
            bool flag = true;
            Execute();
            List<string> ids = responseBody.Select(property => property.id.ToString()).ToList();
            string invalidPetId = "";
            Random r = new Random();

            while (flag)
            {
                if (!ids.Contains(r.Next().ToString()))
                {
                    invalidPetId = r.Next().ToString();
                    flag = false;
                }
            }
            return invalidPetId;
        }
    }
}
