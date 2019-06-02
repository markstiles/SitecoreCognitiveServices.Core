using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary
{
    public class VocabularyRepository : IVocabularyRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public VocabularyRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<VocabulariesSummary> List(VocabulariesQuery query)
        {
            var parameters = query.ToParameters();

            return await Client.Get<VocabulariesSummary>($"{ApiKeys.Endpoint}vocabulary", ApiKeys.ApiToken, parameters).ConfigureAwait(false);
        }

        public async Task<VocabularyResponse> Get(VocabularyWordsQuery query)
        {
            var parameters = query.ToParameters();

            return await Client.Get<VocabularyResponse>($"{ApiKeys.Endpoint}vocabulary/{query.Id}", ApiKeys.ApiToken, parameters).ConfigureAwait(false);
        }

        public async Task Remove(VocabularyRemoveCriteria criteria)
        {
            Argument.IsNotNull(criteria, nameof(criteria));

            if (criteria.VocabularyId.HasValue)
            {
                await Client.Delete($"{ApiKeys.Endpoint}vocabulary/{criteria.VocabularyId}", ApiKeys.ApiToken, null).ConfigureAwait(false);
            }
            else
            {
                var parameters = criteria.ToParameters();

                await Client.Delete($"{ApiKeys.Endpoint}vocabulary", ApiKeys.ApiToken, parameters).ConfigureAwait(false);
            }
        }
    }
}