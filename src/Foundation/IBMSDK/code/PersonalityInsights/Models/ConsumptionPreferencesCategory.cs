using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class ConsumptionPreferencesCategory
    {
        [JsonProperty("consumption_preference_category_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsumptionPreferenceCategoryId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("consumption_preferences", NullValueHandling = NullValueHandling.Ignore)]
        public List<ConsumptionPreferences> ConsumptionPreferences { get; set; }
    }
}
