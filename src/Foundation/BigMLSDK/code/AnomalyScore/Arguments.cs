using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class AnomalyScore
    {
        public class Arguments : Arguments<AnomalyScore>
        {
            public Arguments()
            {
                InputData = new Dictionary<string, object>();
            }

            /// <summary>
            /// A valid anomaly/id.
            /// </summary>
            public string Anomaly
            {
                get;
                set;
            }

            /// <summary>
            /// A group of values in a dictionary: "fieldId": value
            /// </summary>
            public IDictionary<string, object> InputData
            {
                get;
                set;
            }

            public override JObject ToJson()
            {
                dynamic json = base.ToJson();

                if(!string.IsNullOrWhiteSpace(Anomaly)) json.anomaly = Anomaly;
                if (InputData.Count > 0)
                {
                    var input_data = new JObject();
                    foreach (var kv in InputData)
                    {
                        JToken value = (JToken) kv.Value;
                        input_data[kv.Key] = value;
                    }
                    json.input_data = input_data;
                }
                return json;
            }
        }
    }
}