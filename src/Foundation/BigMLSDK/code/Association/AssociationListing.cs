using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class AssociationListing : Query<Association.Filterable, Association.Orderable, Association>
    {
        public AssociationListing(Func<string, Task<Listing<Association>>> client)
            : base(client)
        {
        }
    }
}
