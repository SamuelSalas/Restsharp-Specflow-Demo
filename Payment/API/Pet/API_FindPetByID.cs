using Payment.Base;
using Payment.Model;
using Payment.Utilities;
using RestSharp;
using System.Net;

namespace Payment.API.Pet
{
    public class API_FindPetByID : BaseAPI
    {
        public Pets responseBody;
        public ApiResponse errorResponse;

        public API_FindPetByID()
        {
            restClient = new RestClient(ProjectSettings.BASE_URL);
            request = new RestRequest("/v2/pet/{id}", Method.Get);
        }

        public void SetPetIdUrlSegment(string id)
        {
            request.AddUrlSegment("id", id);
        }

        public void Execute()
        {
            response = restClient.ExecuteAsync(request).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.NoContent)
            {
                errorResponse = APIHelper.DeserializeObject<ApiResponse>(response);
            }

            responseBody = APIHelper.DeserializeObject<Pets>(response);
        }

        public string GetResponsePetId()
        {
            return responseBody.id.ToString();
        }

        public int GetResponseStatusCode()
        {
            return (int)response.StatusCode;
        }

        public int GetErrorCode()
        {
            return errorResponse.code;
        }

        public string GetErrorType()
        {
            return errorResponse.type;
        }

        public string GetErrorMessage()
        {
            return errorResponse.message;
        }
    }
}
