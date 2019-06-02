using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Http
{
    public class BigMLRepositoryClient : IBigMLRepositoryClient
    {
        #region Constructor

        protected readonly IBigMLApiKeys ApiKeys;
        protected readonly IBigMLApiClient ApiClient;

        protected readonly JsonSerializerSettings SerialSettings;

        public BigMLRepositoryClient(IBigMLApiKeys apiKeys, IBigMLApiClient apiClient)
        {
            ApiKeys = apiKeys;
            ApiClient = apiClient;
            SerialSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        #endregion
        
        private string ApiUrl(string apiPath) => $"{ApiKeys.Endpoint}/{apiPath}?username=${ApiKeys.Username};api_key=${ApiKeys.ApiKey}";
        private string JsonContentType => "application/json";

        public T SendGet<T>(string apiPath)
        {
            ApiClient.InnerClient.DefaultRequestHeaders.Clear();
            using (var res = Task.Run(() => ApiClient.InnerClient.GetAsync(ApiUrl(apiPath))))
            {
                var content = Task.Run(() => res.Result.Content.ReadAsStringAsync()).Result;
                var response = JsonConvert.DeserializeObject<T>(content);

                return response;
            }
        }

        public T SendPost<T>(string apiPath, object parameter)
        {
            var serialContent = JsonConvert.SerializeObject(parameter, SerialSettings);
            
            var paramContent = new StringContent(serialContent, Encoding.UTF8, JsonContentType);
            ApiClient.InnerClient.DefaultRequestHeaders.Clear();
            ApiClient.InnerClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            using (var res = Task.Run(() => ApiClient.InnerClient.PostAsync(ApiUrl(apiPath), paramContent)))
            {
                var content = Task.Run(() => res.Result.Content.ReadAsStringAsync()).Result;
                var response = JsonConvert.DeserializeObject<T>(content);

                return response;
            }
        }

        public T SendPut<T>(string apiPath, object parameter)
        {
            var serialContent = JsonConvert.SerializeObject(parameter, SerialSettings);

            var paramContent = new StringContent(serialContent, Encoding.UTF8, JsonContentType);
            ApiClient.InnerClient.DefaultRequestHeaders.Clear();
            ApiClient.InnerClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            using (var res = Task.Run(() => ApiClient.InnerClient.PutAsync(ApiUrl(apiPath), paramContent)))
            {
                var content = Task.Run(() => res.Result.Content.ReadAsStringAsync()).Result;
                var response = JsonConvert.DeserializeObject<T>(content);

                return response;
            }
        }

        public HttpStatusCode SendDelete(string apiPath)
        {
            ApiClient.InnerClient.DefaultRequestHeaders.Clear();
            using (var res = Task.Run(() => ApiClient.InnerClient.DeleteAsync(ApiUrl(apiPath))))
            {
                var status = Task.Run(() => res.Result.StatusCode).Result;

                return status;
            }
        }
    }
}