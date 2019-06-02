using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model.Models
{
    public class ModelSummaryList : Paged<ModelSummary>
    {
        /// <summary>
        /// The models
        /// </summary>
        public List<ModelSummary> Items { get; set; }
    }
}