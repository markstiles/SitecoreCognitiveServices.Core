using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class ClientConfiguration
    {
        public string applicationID { get; set; }
        public string eventHubInteractionConnectionString { get; set; }
        public string eventHubObservationConnectionString { get; set; }
        public string modelBlobUri { get; set; }
        public float initialExplorationEpsilon { get; set; }
    }
}