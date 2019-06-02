using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing
{
    public class AutoSuggestRepository : IAutoSuggestRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public AutoSuggestRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual AutoSuggestResponse GetSuggestions(string text)
        {
            var response = RepositoryClient.SendGet(ApiKeys.BingAutosuggest, $"{ApiKeys.BingAutosuggestEndpoint}?q={text}");

            return JsonConvert.DeserializeObject<AutoSuggestResponse>(response);
        }

        public virtual async Task<AutoSuggestResponse> GetSuggestionsAsync(string text)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingAutosuggest, $"{ApiKeys.BingAutosuggestEndpoint}?q={text}");

            return JsonConvert.DeserializeObject<AutoSuggestResponse>(response);
        }
    }
}