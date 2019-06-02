using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class ViewDetail : ViewDefinition
    {
        /// <summary>
        /// The data
        /// </summary>
        public List<Dictionary<string, string>> Data { get; set; }
    }
}