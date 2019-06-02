using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model.Models
{
    public class ModelPredictionResult : ModelSummary
    {
        public List<Dictionary<string, string>> Data { get; set; } = new List<Dictionary<string, string>>();

        public List<StatusMessage> Messages { get; set; } = new List<StatusMessage>();
    }
}
