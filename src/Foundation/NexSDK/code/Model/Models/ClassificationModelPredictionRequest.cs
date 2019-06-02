using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model.Models
{
    public class ClassificationModelPredictionRequest : ModelPredictionRequest
    {
        /// <summary>
        /// For classification models, whether or not to include class scores for each possible class (default is false)
        /// </summary>
        [JsonIgnore]
        public bool? IncludeClassScores
        {
            get => GetExtraParameter("includeClassScores");
            set => SetExtraParameter("includeClassScores", value);
        }
    }
}