using RestSharp;

namespace Payment.Base
{
    public class BaseAPI
    {
        public RestClient restClient;
        public RestRequest request;
        public RestResponse response;
    }
}
