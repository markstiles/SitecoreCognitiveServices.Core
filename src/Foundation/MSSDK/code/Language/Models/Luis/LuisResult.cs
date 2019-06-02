using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis
{
    public class LuisResult
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "topScoringIntent")]
        public IntentRecommendation TopScoringIntent { get; set; }

        [JsonProperty(PropertyName = "intents")]
        public IList<IntentRecommendation> Intents { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public IList<EntityRecommendation> Entities { get; set; }

        [JsonProperty(PropertyName = "sentimentAnalysis")]
        public SentimentAnalysis SentimentAnalysis { get; set; }

        [JsonProperty(PropertyName = "compositeEntities")]
        public IList<CompositeEntity> CompositeEntities { get; set; }

        [JsonProperty(PropertyName = "dialog")]
        public DialogResponse Dialog { get; set; }

        [JsonProperty(PropertyName = "alteredQuery")]
        public string AlteredQuery { get; set; }

        public LuisResult()
        {
        }

        public LuisResult(string query, IList<EntityRecommendation> entities, IntentRecommendation topScoringIntent = null, IList<IntentRecommendation> intents = null, IList<CompositeEntity> compositeEntities = null, DialogResponse dialog = null, string alteredQuery = null, SentimentAnalysis sentimentAnalysis = null)
        {
            Query = query;
            TopScoringIntent = topScoringIntent;
            Intents = intents;
            Entities = entities;
            CompositeEntities = compositeEntities;
            Dialog = dialog;
            AlteredQuery = alteredQuery;
            SentimentAnalysis = sentimentAnalysis;
        }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// 
        /// </summary>
        public virtual void Validate()
        {
            if (Query == null)
                throw new Exception("Query Cannot Be Null");
            if (Entities == null)
                throw new Exception("Entities Cannot Be Null");

            if (Entities != null)
            {
                foreach (EntityRecommendation entityRecommendation in Entities)
                {
                    entityRecommendation.Validate();
                }
            }
            if (CompositeEntities == null)
                return;

            foreach (CompositeEntity compositeEntity in CompositeEntities)
            {
                compositeEntity?.Validate();
            }
        }
    }
}