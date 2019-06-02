using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Import.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Import
{
    public class ImportRepository : IImportRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;

        public ImportRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<ImportDetailList> List(ImportDetailQuery query = null)
        {
            var parameters = query.ToParameters();
            
            var list = await Client
                .Get<ImportDetailList>($"{ApiKeys.Endpoint}imports", ApiKeys.ApiToken, parameters).ConfigureAwait(false);

            return list;
        }

        public async Task<ImportDetail> Get(Guid id)
        {
            return await Client
                .Get<ImportDetail>($"{ApiKeys.Endpoint}imports/{id}", ApiKeys.ApiToken, null)
                .ConfigureAwait(false);
        }

        public async Task<ImportDetail> ImportFromS3(ImportFromS3Request detail)
        {
            var response = await Client
                .Post<ImportDetail>($"{ApiKeys.Endpoint}imports/s3", ApiKeys.ApiToken, null, detail).ConfigureAwait(false);
            return response;
        }

        public async Task<ImportDetail> ImportFromUrl(ImportFromUrlRequest detail)
        {
            var response = await Client
                .Post<ImportDetail>($"{ApiKeys.Endpoint}imports/url", ApiKeys.ApiToken, null, detail)
                .ConfigureAwait(false);
            return response;
        }

        public async Task<ImportDetail> ImportFromAzure(ImportFromAzureRequest detail)
        {
            var response = await Client
                .Post<ImportDetail>($"{ApiKeys.Endpoint}imports/azure", ApiKeys.ApiToken, null, detail)
                .ConfigureAwait(false);
            return response;
        }
    }
}