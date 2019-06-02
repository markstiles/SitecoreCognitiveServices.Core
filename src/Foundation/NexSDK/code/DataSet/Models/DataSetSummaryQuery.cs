using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    /// <summary>
    /// Query criteria to be used when retrieving DataSets
    /// </summary>
    public class DataSetSummaryQuery
    {
        /// <summary>
        /// All DataSets whose name contains this string will be reuturned  
        /// </summary>
        public string PartialName { get; set; }

        /// <summary>
        /// Paging information for the response
        /// </summary>
        public PagingInfo Page { get; set; }
        
    }
}