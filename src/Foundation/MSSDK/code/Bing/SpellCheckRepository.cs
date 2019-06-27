using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.SpellCheck;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing {
    public class SpellCheckRepository : ISpellCheckRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public SpellCheckRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected virtual string GetSpellCheckQuerystring(string text, SpellCheckModeOptions mode, string languageCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?text={text}");

            if (mode != SpellCheckModeOptions.None)
                sb.Append($"&mode={Enum.GetName(typeof(SpellCheckModeOptions), mode).ToLower()}");

            if (!string.IsNullOrEmpty(languageCode))
                sb.Append($"&mkt={languageCode}");
            
            return sb.ToString();
        }

        public virtual SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            var qs = GetSpellCheckQuerystring(text, mode, languageCode);
            
            var response = RepositoryClient.SendGet(ApiKeys.BingSpellCheck, $"{ApiKeys.BingSpellCheckEndpoint}{qs}");

            var obj = JsonConvert.DeserializeObject<SpellCheckResponse>(response);

            return obj;
        }

        public virtual async Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            var qs = GetSpellCheckQuerystring(text, mode, languageCode);
                    
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSpellCheck, $"{ApiKeys.BingSpellCheckEndpoint}{qs}");

            var obj = JsonConvert.DeserializeObject<SpellCheckResponse>(response);

            return obj;
        }
    }
}