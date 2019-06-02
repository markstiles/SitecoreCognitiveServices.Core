using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class FusionListing : Query<Fusion.Filterable, Fusion.Orderable, Fusion>
    {
        public FusionListing(Func<string, Task<Listing<Fusion>>> client)
            : base(client)
        {
        }
    }
}
