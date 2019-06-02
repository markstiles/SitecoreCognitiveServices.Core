using System;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public abstract class ReturnsQuotas
    {
        [JsonIgnore]
        public Quota DataSetCount { get; set; }

        [JsonIgnore]
        public Quota PredictionCount { get; set; }

        [JsonIgnore]
        public Quota SessionCount { get; set; }

        public void AssignQuotas(HttpResponseHeaders headers)
        {            
            DataSetCount = new Quota("nexosis-account-datasetcount", headers);
            PredictionCount = new Quota("nexosis-account-predictioncount", headers);
            SessionCount = new Quota("nexosis-account-sessioncount", headers);
        }
    }
}