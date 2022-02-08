using Payment.Base;
using Payment.Model;
using Payment.Utilities;
using RestSharp;

namespace Payment.API.Pet
{
    public class API_AddPet : BaseAPI
    {
        public Pets requestBody;
        public Pets responseBody;

        public API_AddPet()
        {
            restClient = new RestClient(ProjectSettings.BASE_URL);
            request = new RestRequest("v2/pet", Method.Post);
            requestBody = APIHelper.ParseJsonFile<Pets>(@"/petPayload.json");
            request.AddJsonBody(requestBody);
        }

        public void Execute()
        {
            response = restClient.ExecuteAsync(request).GetAwaiter().GetResult();
            responseBody = APIHelper.DeserializeObject<Pets>(response);
        }

        public int GetResponseStatusCode()
        {
            return (int)response.StatusCode;
        }
    }
}
