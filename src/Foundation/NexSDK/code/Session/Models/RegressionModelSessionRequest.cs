using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class RegressionModelSessionRequest : ModelSessionRequest
    {
        public RegressionModelSessionRequest()
        {
            PredictionDomain = PredictionDomain.Regression;
        }
    }
}