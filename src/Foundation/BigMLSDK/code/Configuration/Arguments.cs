using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Configuration
    {
        public class Arguments : Arguments<Configuration>
        {
            public Arguments()
            {

            }

            public override JObject ToJson()
            {
                dynamic json = base.ToJson();

                return json;
            }
        }
    }
}