﻿using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.EntityLinking;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge
{
    public class EntityLinkingRepository : IEntityLinkingRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public EntityLinkingRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected virtual string GetLinkQuerystring(string selection, int offset) {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(selection))
                sb.Append($"?selection={selection}");
            
            if (offset > 0) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}offset={offset}");
            }
            
            return sb.ToString();
        }

        public virtual EntityLink[] Link(string text, string selection = "", int offset = 0) {

            var qs = GetLinkQuerystring(selection, offset);
            var response = RepositoryClient.SendTextPost(ApiKeys.EntityLinking, $"{ApiKeys.EntityLinkingEndpoint}{qs}", text);

            return JsonConvert.DeserializeObject<EntityLink[]>(response);
        }

        public virtual async Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0) {

            var qs = GetLinkQuerystring(selection, offset);
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.EntityLinking, $"{ApiKeys.EntityLinkingEndpoint}{qs}", text);

            return JsonConvert.DeserializeObject<EntityLink[]>(response);
        }
    }
}
