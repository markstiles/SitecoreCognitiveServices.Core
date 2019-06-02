using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http
{
    public interface INexosisClient
    {
        Task<T> Get<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null);
        Task Get(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamWriter output = null);
        Task<T> Post<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null);
        Task<T> Post<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null);
        Task<T> Put<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null);
        Task<T> Put<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null);
        Task Delete(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null);
        Task<T> Head<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null);
        Task<T> SendObjectContent<T>(string url, string apiToken, HttpMethod method, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null);
        Task<T> SendStreamContent<T>(string url, string apiToken, HttpMethod method, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null);
        Task<T> MakeRequest<T>(string apiToken, HttpRequestMessage requestMessage, StreamWriter output = null);
    }
}
