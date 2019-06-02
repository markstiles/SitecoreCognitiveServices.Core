using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.WebSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing
{
    public class WebSearchRepository : IWebSearchRepository
    {
        public static readonly string webSearchUrl = "search";

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public WebSearchRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected virtual string GetWebSearchQuerystring(int countOffset, string languageCode, SafeSearchOptions safeSearch)
        {
            StringBuilder sb = new StringBuilder();

            if (countOffset > 0)
                sb.Append($"&countoffset={countOffset}");

            if (!string.IsNullOrEmpty(languageCode))
                sb.Append($"&mkt={languageCode}");

            if (safeSearch != SafeSearchOptions.Off) 
                sb.Append($"&safeSearch={Enum.GetName(typeof(SafeSearchOptions), safeSearch)}");
            
            return sb.ToString();
        }

        public virtual WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            var qs = GetWebSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, $"{ApiKeys.BingSearchEndpoint}{webSearchUrl}?q={text}{qs}");

            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }

        public virtual async Task<WebSearchResponse> WebSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            var qs = GetWebSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, $"{ApiKeys.BingSearchEndpoint}{webSearchUrl}?q={text}{qs}");
            
            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }
    }
}
 