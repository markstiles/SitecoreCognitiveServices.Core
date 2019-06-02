using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class SampleListing : Query<Sample.Filterable, Sample.Orderable, Sample>
    {
        public SampleListing(Func<string, Task<Listing<Sample>>> client)
            : base(client)
        {
        }
    }
}
