using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.View.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View
{

    public class ViewRepository : IViewRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public ViewRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<ViewDefinitionList> List(ViewQuery viewQuery = null)
        {
            var parameters = viewQuery.ToParameters();
            
            return await Client.Get<ViewDefinitionList>($"{ApiKeys.Endpoint}views", ApiKeys.ApiToken, parameters).ConfigureAwait(false);
        }

        public async Task<ViewDetail> Get(ViewDataQuery query)
        {
            Argument.IsNotNullOrEmpty(query?.Name, nameof(ViewDataQuery.Name));
            
            var parameters = query.ToParameters();

            return await Client.Get<ViewDetail>($"{ApiKeys.Endpoint}views/{query.Name}", ApiKeys.ApiToken, parameters)
                .ConfigureAwait(false);
        }

        public async Task<ViewDefinition> Create(string viewName, ViewInfo view)
        {
            Argument.IsNotNullOrEmpty(viewName, nameof(viewName));
            Argument.IsNotNull(view, nameof(view));
            
            return await Client.Put<ViewDefinition>($"{ApiKeys.Endpoint}views/{viewName}", ApiKeys.ApiToken, null, view)
                .ConfigureAwait(false);
        }

        public async Task Remove(ViewDeleteCriteria criteria)
        {
            Argument.IsNotNullOrEmpty(criteria?.Name, nameof(criteria.Name));

            var parameters = criteria.ToParameters();

            await Client.Delete($"{ApiKeys.Endpoint}views/{criteria.Name}", ApiKeys.ApiToken, parameters)
                .ConfigureAwait(false);
        }
    }
}