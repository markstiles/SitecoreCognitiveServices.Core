using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class ModelListing : Query<Model.Filterable, Model.Orderable, Model>
    {
        public ModelListing(Func<string, Task<Listing<Model>>> client)
            : base(client)
        {
        }
    }
}