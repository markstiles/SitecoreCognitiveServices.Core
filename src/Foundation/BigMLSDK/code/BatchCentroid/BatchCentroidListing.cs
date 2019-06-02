using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class BatchCentroidListing : Query<BatchCentroid.Filterable, BatchCentroid.Orderable, BatchCentroid>
    {
        public BatchCentroidListing(Func<string, Task<Listing<BatchCentroid>>> client)
            : base(client)
        {
        }
    }
}
