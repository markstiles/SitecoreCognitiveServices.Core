using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public interface IDataSetService
    {
        /// <summary>
        /// Save data in a dataset.
        /// </summary>
        /// <param name="source">A <see cref="IDataSetSource"/> containing the data.  Create one of these with <see cref="SitecoreCognitiveServices.Foundation.NexSDK.DataSet.From"/>.</param>
        /// <returns>A <see cref="DataSetSummary"/> for the dataset created.</returns>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>PUT to https://ml.nexosis.com/v1/v1/{dataSetName}</remarks>
        Task<DataSetSummary> Create(IDataSetSource source);

        /// <summary>
        /// Gets the list of datasets that have been saved to the system, filtering by partial name match.
        /// </summary>
        /// <param name="query">A <see cref="DataSetSummaryQuery"/> with the filter criteria for the DataSets to retrieve.</param>
        /// <returns>A list of <see cref="DataSetSummary"/>.</returns>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>GET of https://ml.nexosis.com/v1/data</remarks>
        Task<DataSetSummaryList> List(DataSetSummaryQuery query = null);


        /// <summary>Get the data in the set, written to a CSV file, optionally filtering it.</summary>
        /// <param name="query">A <see cref="DataSetDataQuery"/> with the filter criteria for retrieving data from the DataSet.  Create one of these with <see cref="SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Where"/></param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>GET of https://ml.nexosis.com/v1/data/{dataSetName}</remarks>
        Task<DataSetData> Get(DataSetDataQuery query);

        /// <summary>Remove data from a dataset or the entire set.</summary>
        /// <param name="criteria">A <see cref="DataSetRemoveCriteria"/> with the criteria for which data to remove</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>DELETE to https://ml.nexosis.com/v1/data/{dataSetName}</remarks>
        Task Remove(DataSetRemoveCriteria criteria);

        /// <summary>
        /// Retrieve statistics about a dataset
        /// </summary>
        /// <param name="dataSetName">The dataset whose stats should be retrieved</param>
        /// <remarks>GET to https://ml.nexosis.com/v1/data/{dataSetName}/stats</remarks>
        Task<DataSourceStatsResult> Stats(string dataSetName);
    }
}