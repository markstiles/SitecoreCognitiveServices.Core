using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Session.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session
{

    public class SessionRepository : ISessionRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public SessionRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<SessionResponse> CreateForecast(ForecastSessionRequest request)
        {
            Argument.IsNotNullOrEmpty(request?.DataSourceName, "dataSourceName");

            return await Client.Post<SessionResponse>($"{ApiKeys.Endpoint}sessions/forecast", ApiKeys.ApiToken, null, request);
        }

        public async Task<SessionResponse> AnalyzeImpact(ImpactSessionRequest request)
        {
            Argument.IsNotNullOrEmpty(request?.DataSourceName, "dataSourceName");
            Argument.IsNotNullOrEmpty(request?.EventName, "eventName");

            return await Client.Post<SessionResponse>($"{ApiKeys.Endpoint}sessions/impact", ApiKeys.ApiToken, null, request);
        }

        public async Task<SessionResponse> TrainModel(ModelSessionRequest request)
        {
            Argument.IsNotNullOrEmpty(request?.DataSourceName, "dataSourceName");

            return await Client.Post<SessionResponse>($"{ApiKeys.Endpoint}sessions/model", ApiKeys.ApiToken, null, request);
        }

        public async Task<SessionResponseList> List(SessionQuery query = null)
        {
            var parameters = query.ToParameters();

            return await Client.Get<SessionResponseList>($"{ApiKeys.Endpoint}sessions", ApiKeys.ApiToken, parameters);
        }

        public async Task Remove(SessionRemoveCriteria criteria)
        {
            var parameters = criteria.ToParameters();

            Client.Delete($"{ApiKeys.Endpoint}sessions", ApiKeys.ApiToken, parameters);
        }

        public async Task<SessionResponse> Get(Guid id)
        {
            return await Client.Get<SessionResponse>($"{ApiKeys.Endpoint}sessions/{id}", ApiKeys.ApiToken, null);
        }

        public async Task<SessionResultStatus> GetStatus(Guid id)
        {
            return await Client.Head<SessionResultStatus>($"{ApiKeys.Endpoint}sessions/{id}", ApiKeys.ApiToken, null);
        }

        public async Task Remove(Guid id)
        {
            Client.Delete($"{ApiKeys.Endpoint}sessions/{id}", null);
        }

        public async Task<SessionResult> GetResults(Guid id, SessionResultsQuery query = null)
        {
            var parameters = query.ToParameters();
            return await Client.Get<SessionResult>($"{ApiKeys.Endpoint}sessions/{id}/results", ApiKeys.ApiToken, parameters);
        }

        public async Task<ConfusionMatrixResult> GetResultConfusionMatrix(Guid id)
        {
            return await Client.Get<ConfusionMatrixResult>($"{ApiKeys.Endpoint}sessions/{id}/results/confusionmatrix", ApiKeys.ApiToken, null);
        }

        public async Task<SessionResult> GetResultAnomalyScores(Guid id)
        {
            return await Client.Get<SessionResult>($"{ApiKeys.Endpoint}sessions/{id}/results/anomalyscores", ApiKeys.ApiToken, null);
        }

        public async Task<SessionResult> GetResultClassScores(Guid id)
        {
            return await Client.Get<SessionResult>($"{ApiKeys.Endpoint}sessions/{id}/results/classscores", ApiKeys.ApiToken, null);
        }
    }
}
