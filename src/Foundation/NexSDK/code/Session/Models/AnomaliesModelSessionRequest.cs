using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class AnomaliesModelSessionRequest : ModelSessionRequest
    {
        public AnomaliesModelSessionRequest()
        {
            PredictionDomain = PredictionDomain.Anomalies;
        }

        /// <summary>
        /// For anomaly detection models, whether or not the source dataset contains anomalies (default is true)
        /// </summary>
        [JsonIgnore]
        public bool? ContainsAnomalies
        {
            get => GetExtraParameter("containsAnomalies");
            set => SetExtraParameter("containsAnomalies", value);
        }
    }
}