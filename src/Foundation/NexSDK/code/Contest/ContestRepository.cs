using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Contest
{
    public class ContestRepository : IContestRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public ContestRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<ContestResponse> GetContest(Guid sessionId)
        {
            return await Client.Get<ContestResponse>($"{ApiKeys.Endpoint}sessions/{sessionId}/contest", ApiKeys.ApiToken);
        }

        public async Task<ContestantResponse> GetChampion(Guid sessionId, ChampionQueryOptions options = null)
        {
            var parameters = options.ToParameters();
            return await Client.Get<ContestantResponse>($"{ApiKeys.Endpoint}sessions/{sessionId}/contest/champion", ApiKeys.ApiToken, parameters);
        }

        public async Task<ContestSelectionResponse> GetSelection(Guid sessionId)
        {
            return await Client.Get<ContestSelectionResponse>($"{ApiKeys.Endpoint}sessions/{sessionId}/contest/selection", ApiKeys.ApiToken);
        }

        public async Task<ChampionContestantList> ListContestants(Guid sessionId)
        {
            return await Client.Get<ChampionContestantList>($"{ApiKeys.Endpoint}sessions/{sessionId}/contest/contestants", ApiKeys.ApiToken);
        }

        public async Task<ContestantResponse> GetContestant(Guid sessionId, string contestantId, ChampionQueryOptions options = null)
        {
            var parameters = options.ToParameters();
            
            return await Client.Get<ContestantResponse>($"{ApiKeys.Endpoint}sessions/{sessionId}/contest/contestants/{contestantId}", ApiKeys.ApiToken, parameters);
        }
    }
}