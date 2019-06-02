using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class ViewDefinitionList : Paged<ViewDefinition>
    {
        /// <summary>
        /// The views
        /// </summary>
        public List<ViewDefinition> Items { get; set; }
    }
}