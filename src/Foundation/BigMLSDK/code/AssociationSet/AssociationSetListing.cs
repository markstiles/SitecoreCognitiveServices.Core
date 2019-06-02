using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class AssociationSetListing : Query<AssociationSet.Filterable, AssociationSet.Orderable, AssociationSet>
    {
        public AssociationSetListing(Func<string, Task<Listing<AssociationSet>>> client)
            : base(client)
        {
        }
    }
}
