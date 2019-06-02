using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class BatchPredictionListing : Query<BatchPrediction.Filterable, BatchPrediction.Orderable, BatchPrediction>
    {
        public BatchPredictionListing(Func<string, Task<Listing<BatchPrediction>>> client)
            : base(client)
        {
        }
    }
}
