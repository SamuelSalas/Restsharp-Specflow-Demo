using Payment.Base;
using Payment.Model;
using Payment.Utilities;
using RestSharp;

namespace Payment.API.Pet
{
    public class API_DeletePet : BaseAPI
    {
        public ApiResponse responseBody;

        public API_DeletePet()
        {
            restClient = new RestClient(ProjectSettings.BASE_URL);
            request = new RestRequest("v2/pet/{idPet}", Method.Delete);
        }

        public void SetPetId(string petId)
        {
            request.AddUrlSegment("idPet", petId);
        }

        public void Execute()
        {
            response = restClient.ExecuteAsync(request).GetAwaiter().GetResult();
            responseBody = APIHelper.DeserializeObject<ApiResponse>(response);
        }

        public int GetResponseStatusCode()
        {
            return (int)response.StatusCode;
        }
    }
}
