using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class EnsembleListing : Query<Ensemble.Filterable, Ensemble.Orderable, Ensemble>
    {
        public EnsembleListing(Func<string, Task<Listing<Ensemble>>> client)
            : base(client)
        {
        }
    }
}
