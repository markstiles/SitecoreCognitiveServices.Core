using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http
{
    public class NexosisClient : INexosisClient
    {
        public HttpClient BaseClient { get; private set; }

        public NexosisClient()
        {
            BaseClient = new HttpClient();
        }
        
        public async Task<T> Get<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var uri = new Uri(url);
            if (parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("appliction/json"));
                return await MakeRequest<T>(apiToken, requestMessage).ConfigureAwait(false);
            }
        }

        public async Task Get(string url , string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamWriter output = null)
        {
            var uri = new Uri(url);
            if (parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await MakeRequest<Task>(apiToken, requestMessage, output).ConfigureAwait(false);
            }
        }

        public async Task<T> Post<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null)
        {
            return await SendObjectContent<T>(url, apiToken, HttpMethod.Post, parameters, body).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null)
        {
            return await SendStreamContent<T>(url, apiToken, HttpMethod.Post, parameters, body).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null)
        {
            return await SendObjectContent<T>(url, apiToken, HttpMethod.Put, parameters, body).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null)
        {
            return await SendStreamContent<T>(url, apiToken, HttpMethod.Put, parameters, body).ConfigureAwait(false);
        }

        public async Task Delete(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var uri = new Uri(url);
            if (parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await MakeRequest<object>(apiToken, requestMessage).ConfigureAwait(false);
            }
        }

        public async Task<T> Head<T>(string url, string apiToken, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var uri = new Uri(url);
            if (parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Head, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await MakeRequest<T>(apiToken, requestMessage).ConfigureAwait(false);
            }
        }

        public async Task<T> SendObjectContent<T>(string url, string apiToken, HttpMethod method, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null)
        {
            var uri = new Uri(url);
            if(parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(method, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                if(body != null)
                    requestMessage.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body, settings)));
                requestMessage.Content.Headers.Add("Content-Type", "application/json");

                return await MakeRequest<T>(apiToken, requestMessage).ConfigureAwait(false);
            }
        }

        public async Task<T> SendStreamContent<T>(string url, string apiToken, HttpMethod method, IEnumerable<KeyValuePair<string, string>> parameters = null, StreamReader body = null)
        {
            var uri = new Uri(url);
            if (parameters != null)
                uri.AddParameters(parameters.ToList());
            using (var requestMessage = new HttpRequestMessage(method, uri))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if(body != null)
                requestMessage.Content = new StreamContent(body.BaseStream);
                requestMessage.Content.Headers.Add("Content-Type", "text/csv");

                return await MakeRequest<T>(apiToken, requestMessage).ConfigureAwait(false);
            }
        }
        
        public async Task<T> MakeRequest<T>(string apiToken, HttpRequestMessage requestMessage, StreamWriter output = null)
        {
            requestMessage.Headers.Add("api-key", apiToken);
            requestMessage.Headers.Add("User-Agent", "Nexosis-DotNet-API-Client/1.0");

            var responseMessage = await BaseClient.SendAsync(requestMessage).ConfigureAwait(false);
            
            if (!responseMessage.IsSuccessStatusCode)
                return default(T);

            if (output != null)
            {
                await responseMessage.Content.CopyToAsync(output.BaseStream).ConfigureAwait(false);

                return default(T);
            }

            var resultContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var result = JsonConvert.DeserializeObject<T>(resultContent);
                if (result is ReturnsQuotas)
                {
                    (result as ReturnsQuotas).AssignQuotas(responseMessage.Headers);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new NexosisClientException("Error deserializing response.", e);
            }
        }
    }
}
