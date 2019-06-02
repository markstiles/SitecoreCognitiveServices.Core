using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class ClassificationModelSessionRequest : ModelSessionRequest
    {
        public ClassificationModelSessionRequest()
        {
            PredictionDomain = PredictionDomain.Classification;
        }

        /// <summary>
        /// For classification models, whether or not to balance classes during model building (default is true)
        /// </summary>
        [JsonIgnore]
        public bool? Balance
        {
            get => GetExtraParameter("balance");
            set => SetExtraParameter("balance", value);
        }
    }
}