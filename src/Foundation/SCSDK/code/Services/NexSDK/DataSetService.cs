using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class DataSetService : IDataSetService
    {
        protected readonly IDataSetRepository DataSetRepository;
        protected readonly ILogWrapper Logger;
        
        public DataSetService(
            IDataSetRepository dataSetRepository,
            ILogWrapper logger)
        {
            DataSetRepository = dataSetRepository;
            Logger = logger;
        }

        public async Task<DataSetSummary> Create(IDataSetSource source)
        {
            try
            {
                var result = await DataSetRepository.Create(source);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DataSetService.Create failed", this, ex);
            }

            return null;
        }

        public async Task<DataSetSummaryList> List(DataSetSummaryQuery query)
        {
            try
            {
                var result = await DataSetRepository.List(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DataSetService.List failed", this, ex);
            }

            return null;
        }

        public async Task<DataSetData> Get(DataSetDataQuery query)
        {
            try
            {
                var result = await DataSetRepository.Get(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DataSetService.Get failed", this, ex);
            }

            return null;
        }

        public async Task Remove(DataSetRemoveCriteria criteria)
        {
            try
            {
                DataSetRepository.Remove(criteria);
            }
            catch (Exception ex)
            {
                Logger.Error("DataSetService.Remove failed", this, ex);
            }
        }

        public async Task<DataSourceStatsResult> Stats(string dataSetName)
        {
            try
            {
                var result = await DataSetRepository.Stats(dataSetName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DataSetService.Stats failed", this, ex);
            }

            return null;
        }
    }
}