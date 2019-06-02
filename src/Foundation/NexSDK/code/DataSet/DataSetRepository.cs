using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet
{
    public class DataSetRepository : IDataSetRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public DataSetRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<DataSetSummary> Create(IDataSetSource source)
        {
            Argument.IsNotNullOrEmpty(source.Name, nameof(source.Name));
            
            switch (source)
            {
                    case DataSetDetailSource detail:
                        Argument.IsNotNull(detail.Data, nameof(detail.Data));
                        return await Client.Put<DataSetSummary>($"{ApiKeys.Endpoint}data/{detail.Name}", ApiKeys.ApiToken, null, detail.Data).ConfigureAwait(false);
                    case DataSetStreamSource stream:
                        Argument.IsNotNull(stream.Data, nameof(stream.Data));
                        return await Client.Put<DataSetSummary>($"{ApiKeys.Endpoint}data/{stream.Name}", ApiKeys.ApiToken, null, stream.Data).ConfigureAwait(false);
                    default:
                        throw new NotImplementedException($"No DataSet create supported for {source.GetType()}");
            }
        }

        public async Task<DataSetSummaryList> List(DataSetSummaryQuery query)
        {
            var parameters = query.ToParameters();
            
            var result = await Client
                .Get<DataSetSummaryList>($"{ApiKeys.Endpoint}data", ApiKeys.ApiToken, parameters)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<DataSetData> Get(DataSetDataQuery query)
        {
            Argument.IsNotNullOrEmpty(query.Name, nameof(query.Name));
            var parameters = query.ToParameters();
            return await Client.Get<DataSetData>($"{ApiKeys.Endpoint}data/{query.Name}", ApiKeys.ApiToken, parameters);
        }

        public async Task Remove(DataSetRemoveCriteria criteria)
        {
            Argument.IsNotNullOrEmpty(criteria.Name, nameof(criteria.Name));
            
            var parameters = criteria.ToParameters();
            await Client.Delete($"{ApiKeys.Endpoint}data/{criteria.Name}", ApiKeys.ApiToken, parameters).ConfigureAwait(false);
        }

        public async Task<DataSourceStatsResult> Stats(string dataSetName)
        {
            Argument.IsNotNullOrEmpty(dataSetName, nameof(dataSetName));

            return await Client.Get<DataSourceStatsResult>($"{ApiKeys.Endpoint}data/{dataSetName}/stats", ApiKeys.ApiToken);
        }
    }
}
