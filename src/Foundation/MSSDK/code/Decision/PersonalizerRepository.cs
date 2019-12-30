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

        public ClientConfiguration GetClientConfiguration()
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/client", string.Empty);

            return JsonConvert.DeserializeObject<ClientConfiguration>(response);
        }

        public void RewardTopRankedAction(string eventId)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}events/{eventId}/reward", string.Empty);
        }

        public void ActivateEvent(string eventId)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}events/{eventId}/activate", string.Empty);
        }

        public Evaluation SubmitNewEvaluation(EvaluationRequest request)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}evaluations", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Evaluation>(response);
        }

        #endregion Post

        #region Delete

        public Policy DeleteCurrentPolicy()
        {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/policy");

            return JsonConvert.DeserializeObject<Policy>(response);
        }

        public void DeleteEvaluation(string evaluationId)
        {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}evaluations/{evaluationId}");
        }

        public void DeleteLogs()
        {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}logs");
        }

        public void DeleteModel()
        {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}model");
        }

        #endregion Delete

        #region Update

        public Policy UpdatePolicyConfiguration(Policy policy)
        {
            var response = RepositoryClient.SendJsonPut(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/policy", JsonConvert.SerializeObject(policy));

            return JsonConvert.DeserializeObject<Policy>(response);
        }

        public Service UpdateServiceConfiguration(Service config)
        {
            var response = RepositoryClient.SendJsonPut(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/service", JsonConvert.SerializeObject(config));

            return JsonConvert.DeserializeObject<Service>(response);
        }

        #endregion Update

        #region Get

        public byte[] GetCurrentModel()
        {
            var response = RepositoryClient.SendForBytes(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}model", null, "application/octet-stream", "GET");

            return response;
        }

        public ModelProperties GetModelProperties()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}model/properties");

            return JsonConvert.DeserializeObject<ModelProperties>(response);
        }

        public Evaluation GetEvaluation(string evaluationId)
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}evaluations/{evaluationId}");

            return JsonConvert.DeserializeObject<Evaluation>(response);
        }

        public Policy GetPolicyConfiguration()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/policy");

            return JsonConvert.DeserializeObject<Policy>(response);
        }

        public Service GetServiceConfiguration()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}configurations/service");

            return JsonConvert.DeserializeObject<Service>(response);
        }

        public LogsProperties GetLogsProperties()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}logs/properties");

            return JsonConvert.DeserializeObject<LogsProperties>(response);
        }

        public List<Evaluation> GetEvaluations()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}evaluations");

            return JsonConvert.DeserializeObject<List<Evaluation>>(response);
        }
        
        public Status GetStatus()
        {
            var response = RepositoryClient.SendGet(ApiKeys.Personalizer, $"{ApiKeys.PersonalizerEndpoint}status");

            return JsonConvert.DeserializeObject<Status>(response);
        }

        #endregion Get
    }
}