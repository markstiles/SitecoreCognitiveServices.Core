using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class BatchAnomalyScoreListing : Query<BatchAnomalyScore.Filterable, BatchAnomalyScore.Orderable, BatchAnomalyScore>
    {
        public BatchAnomalyScoreListing(Func<string, Task<Listing<BatchAnomalyScore>>> client)
            : base(client)
        {
        }
    }
}
