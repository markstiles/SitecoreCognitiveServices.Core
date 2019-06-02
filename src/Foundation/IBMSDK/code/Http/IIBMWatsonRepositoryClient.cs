using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Filters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http
{
    public interface IIBMWatsonRepositoryClient : IDisposable
    {
        HttpClient BaseClient { get; }

        MediaTypeFormatterCollection Formatters { get; }

        List<IHttpFilter> Filters { get; }

        IIBMWatsonRepositoryClient WithAuthentication(string username, string password);

        IRequest DeleteAsync(string url);

        IRequest GetAsync(string url);

        IRequest PostAsync(string url);

        IRequest PostAsync<TBody>(string url, TBody body);

        IRequest PutAsync(string url);

        IRequest PutAsync<TBody>(string url, TBody body);

        IRequest SendAsync(string url, HttpMethod method);

        IRequest SendAsync(string url, HttpRequestMessage message);
    }
}