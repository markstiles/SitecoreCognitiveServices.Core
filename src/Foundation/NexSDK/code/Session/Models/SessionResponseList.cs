using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionResponseList : Paged<SessionResponse>
    {
        /// <summary>
        /// The sessions
        /// </summary>
        public List<SessionResponse> Items { get; set; }
    }
}