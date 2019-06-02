using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class AnomalyListing : Query<Anomaly.Filterable, Anomaly.Orderable, Anomaly>
    {
        public AnomalyListing(Func<string, Task<Listing<Anomaly>>> client)
            : base(client)
        {
        }
    }
}
