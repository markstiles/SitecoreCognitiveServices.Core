using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionQuery
    {
        /// <summary>
        /// Only sessions associated with this data source should be returned
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// Only sessions requested after this date should be returned
        /// </summary>
        public DateTimeOffset? RequestedAfterDate { get; set; }

        /// <summary>
        /// Only sessions requested before this date should be returned
        /// </summary>
        public DateTimeOffset? RequestedBeforeDate { get; set; }

        /// <summary>
        /// Paging info for the response
        /// </summary>
        public PagingInfo Page { get; set; }

        public SessionQuery(string dataSourceName = null, DateTimeOffset? requestedAfterDate = null, DateTimeOffset? requestedBeforeDate = null)
        {
            DataSourceName = dataSourceName;

            if (requestedAfterDate.HasValue)
                RequestedAfterDate = requestedAfterDate;
            
            if (requestedBeforeDate.HasValue)
                RequestedBeforeDate = requestedBeforeDate;
        }
    }
}