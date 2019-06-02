using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class ConfigurationListing : Query<Configuration.Filterable, Configuration.Orderable, Configuration>
    {
        public ConfigurationListing(Func<string, Task<Listing<Configuration>>> client)
            : base(client)
        {
        }
    }
}
