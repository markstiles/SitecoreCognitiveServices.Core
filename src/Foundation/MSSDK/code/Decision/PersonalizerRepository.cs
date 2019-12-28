using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision
{
    public class PersonalizerRepository : IPersonalizerRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public PersonalizerRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        #region Post

        public RankResponse Rank(RankRequest request)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}rank", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<RankResponse>(response);
        }

        #endregion Post

        #region Delete


        #endregion Delete

        #region Update


        #endregion Update

        #region Get


        #endregion Get
    }
}