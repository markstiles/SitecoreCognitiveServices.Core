using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class TopicModel
    {
        public class Arguments : Arguments<TopicModel>
        {
            public Arguments()
            {

            }

            /// <summary>
            /// A valid dataset/id.
            /// </summary>
            public string DataSet
            {
                get;
                set;
            }

            public override JObject ToJson()
            {
                dynamic json = base.ToJson();

                if (!string.IsNullOrWhiteSpace(DataSet))
                {
                    json.dataset = DataSet;
                }

                return json;
            }
        }
    }
}