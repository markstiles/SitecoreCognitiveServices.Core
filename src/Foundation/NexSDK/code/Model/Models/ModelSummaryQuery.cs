using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model.Models
{
    public class ModelSummaryQuery
    {
        /// <summary>
        /// Limits models to those for a particular data source
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// Limits models to those created after this date
        /// </summary>
        public DateTimeOffset? CreatedAfterDate { get; set; }

        /// <summary>
        /// Limits models to those created before this date
        /// </summary>
        public DateTimeOffset? CreatedBeforeDate { get; set; }

        /// <summary>
        /// Paging info for the response
        /// </summary>
        public PagingInfo Page { get; set; }
    }
}