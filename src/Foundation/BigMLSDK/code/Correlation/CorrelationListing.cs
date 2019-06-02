using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class CorrelationListing : Query<Correlation.Filterable, Correlation.Orderable, Correlation>
    {
        public CorrelationListing(Func<string, Task<Listing<Correlation>>> client)
            : base(client)
        {
        }
    }
}
