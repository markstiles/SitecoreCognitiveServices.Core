using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public abstract class Resource
    {
        /// <summary>
        /// Links to related resources
        /// </summary>
        public List<Link> Links { get; set; }
    }
}