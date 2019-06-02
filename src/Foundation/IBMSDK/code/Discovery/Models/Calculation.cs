using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Calculation
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public virtual double? Value { get; private set; }
    }
}
