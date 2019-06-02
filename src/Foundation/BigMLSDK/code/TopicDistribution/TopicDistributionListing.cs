using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class TopicDistributionListing : Query<TopicDistribution.Filterable, TopicDistribution.Orderable, TopicDistribution>
    {
        public TopicDistributionListing(Func<string, Task<Listing<TopicDistribution>>> client)
            : base(client)
        {
        }
    }
}