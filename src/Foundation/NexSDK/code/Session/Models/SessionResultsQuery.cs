using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionResultsQuery
    {
        /// <summary>
        /// Optional. The results returned will be from the given prediction interval.
        /// </summary>
        public string PredictionInterval { get; set; }

        /// <summary>
        /// Paging info for the response
        /// </summary>
        public PagingInfo Page { get; set; }
    }
}