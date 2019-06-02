using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    /// <summary>
    /// Listing of DataSets
    /// </summary>
    public class DataSetSummaryList : Paged<DataSetSummary>
    {
        /// <summary>
        /// The DataSets
        /// </summary>
        public List<DataSetSummary> Items { get; set; }
    }
}