using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Anomaly
    {
        public class Arguments : Arguments<Anomaly>
        {
            public Arguments()
            {
                ExcludedFields = new List<string>();
            }

            /// <summary>
            /// A valid dataset/id.
            /// </summary>
            public string DataSet
            {
                get;
                set;
            }

            /// <summary>
            /// A list of strings that specifies the fields that won't be
            /// included in the anomaly detector
            /// </summary>
            public List<string> ExcludedFields
            {
                get;
                set;
            }

            public override JObject ToJson()
            {
                JObject json = base.ToJson();

                if(!string.IsNullOrWhiteSpace(DataSet)) json["dataset"] = DataSet;
                if (ExcludedFields.Count > 0)
                {
                    var excluded_fields = new JArray();
                    foreach (var excludedField in ExcludedFields)
                    {
                        excluded_fields.Add(excludedField);
                    }
                    json["excluded_fields"] = excluded_fields;
                }
                return json;
            }
        }
    }
}