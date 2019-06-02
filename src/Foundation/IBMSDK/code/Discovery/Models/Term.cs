using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Term
    {
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Count { get; private set; }
    }
}
