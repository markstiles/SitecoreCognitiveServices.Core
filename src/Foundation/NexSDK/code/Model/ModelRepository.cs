using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Model.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model
{
    public class ModelRepository : IModelRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public ModelRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<ModelSummary> Get(Guid id)
        {
            return await Client
                .Get<ModelSummary>($"{ApiKeys.Endpoint}models/{id}", ApiKeys.ApiToken)
                .ConfigureAwait(false);
        }

        public async Task<ModelSummaryList> List(ModelSummaryQuery query = null)
        {
            var parameters = query.ToParameters();
            var response = await Client
                .Get<ModelSummaryList>($"{ApiKeys.Endpoint}models", ApiKeys.ApiToken, parameters)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<ModelPredictionResult> Predict(ModelPredictionRequest request)
        {
            Argument.IsNotNull(request.Data, nameof(ModelPredictionRequest.Data));

            var requestBody = new
            {
                request.Data,
                request.ExtraParameters
            };

            return await Client.Post<ModelPredictionResult>($"{ApiKeys.Endpoint}models/{request.ModelId}/predict", ApiKeys.ApiToken, null, requestBody);
        }

        public async Task Remove(ModelRemoveCriteria criteria)
        {
            Argument.IsNotNull(criteria, nameof(criteria));

            if (criteria.ModelId.HasValue)
            {
                await Client.Delete($"{ApiKeys.Endpoint}models/{criteria.ModelId}", null)
                    .ConfigureAwait(false);
            }
            else
            {
                var parameters = criteria.ToParameters();

                await Client.Delete($"{ApiKeys.Endpoint}models", ApiKeys.ApiToken, parameters)
                    .ConfigureAwait(false);
            }
        }
    }
}
