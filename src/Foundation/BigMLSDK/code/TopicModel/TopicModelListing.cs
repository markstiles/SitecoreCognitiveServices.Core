using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class TopicModelListing : Query<TopicModel.Filterable, TopicModel.Orderable, TopicModel>
    {
        public TopicModelListing(Func<string, Task<Listing<TopicModel>>> client)
            : base(client)
        {
        }
    }
}