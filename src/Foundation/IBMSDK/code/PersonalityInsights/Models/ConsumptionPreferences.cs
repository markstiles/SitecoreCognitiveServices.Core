using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class ConsumptionPreferences
    {
        [JsonProperty("consumption_preference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsumptionPreferenceId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public double? Score { get; set; }
    }
}
