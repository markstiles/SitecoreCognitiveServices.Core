using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models
{
    public class ChampionQueryOptions
    {
        /// <summary>
        /// The results returned will be from the given prediction interval
        /// </summary>
        public string PredictionInterval { get; set; }

        /// <summary>
        /// Paging info for the response
        /// </summary>
        public PagingInfo Page { get; set; }
    }
}