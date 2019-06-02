using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class DeepnetListing : Query<Deepnet.Filterable, Deepnet.Orderable, Deepnet>
    {
        public DeepnetListing(Func<string, Task<Listing<Deepnet>>> client)
            : base(client)
        {
        }
    }
}
