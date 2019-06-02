using System.Net.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http.Filters
{
    public class ErrorFilter : IHttpFilter
    {
        public void OnRequest(IRequest request, HttpRequestMessage requestMessage) { }

        public void OnResponse(IResponse response, HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                ServiceResponseException exception =
                    new ServiceResponseException(response, responseMessage, $"The API query failed with status code {responseMessage.StatusCode}: {responseMessage.ReasonPhrase}");

                var error = responseMessage.Content.ReadAsStringAsync().Result;

                if (responseMessage.Content.Headers.ContentType.MediaType == HttpMediaType.APPLICATION_JSON)
                {
                    exception.Error = JsonConvert.DeserializeObject<Error>(error);
                }
                else
                {
                    exception.Error = new Error()
                    {
                        CodeDescription = responseMessage.StatusCode.ToString(),
                        Message = error
                    };
                }

                throw exception;
            }
                
        }
    }
}