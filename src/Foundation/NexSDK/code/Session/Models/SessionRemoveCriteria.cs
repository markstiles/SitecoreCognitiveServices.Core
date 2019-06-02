using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Session.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionRemoveCriteria
    {
        /// <summary>
        /// The sessions removed should be only those based on this DataSource
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// Only sessions of this type should be removed
        /// </summary>
        public SessionType? Type { get; set; }

        /// <summary>
        /// Only sessions requested after this date should be removed
        /// </summary>
        public DateTimeOffset? RequestedAfterDate { get; set; }

        /// <summary>
        /// Only sessions requested before this date should be removed
        /// </summary>
        public DateTimeOffset? RequestedBeforeDate { get; set; }

    }
}