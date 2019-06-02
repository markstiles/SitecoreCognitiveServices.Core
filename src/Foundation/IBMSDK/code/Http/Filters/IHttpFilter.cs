using System.Net.Http;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http.Filters
{
    public interface IHttpFilter
    {
        void OnRequest(IRequest request, HttpRequestMessage requestMessage);

        void OnResponse(IResponse response, HttpResponseMessage responseMessage);
    }
}