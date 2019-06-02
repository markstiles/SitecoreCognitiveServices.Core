using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class ModelSessionRequest : SessionRequest
    {
        /// <summary>
        /// The <see cref="PredictionDomain"/> of the model to be built
        /// </summary>
        public PredictionDomain PredictionDomain { get; set; }

        /// <summary>
        /// Extra parameters to alter how the model is built
        /// </summary>
        public Dictionary<string, string> ExtraParameters { get; set; }

        protected bool? GetExtraParameter(string name)
        {
            return ExtraParameters != null
                && ExtraParameters.TryGetValue(name, out string stringValue)
                && bool.TryParse(stringValue, out bool boolValue)
                ? (bool?)boolValue
                : null;
        }
        protected void SetExtraParameter(string name, bool? value)
        {
            if (ExtraParameters == null)
                ExtraParameters = new Dictionary<string, string>();

            if (value.HasValue)
                ExtraParameters[name] = value.ToString();
        }

        public ModelSessionRequest() { }

        public ModelSessionRequest(string dataSourceName, PredictionDomain domain, string targetColumn = null)
        {
            DataSourceName = dataSourceName;
            if (targetColumn != null)
                TargetColumn = targetColumn;

            PredictionDomain = domain;
        }
    }
}