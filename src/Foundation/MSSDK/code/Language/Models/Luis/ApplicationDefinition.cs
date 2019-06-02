﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ApplicationDefinition {
        [JsonProperty(PropertyName = "luis_schema_version")]
        public string LuisSchemaVersion { get; set; }
        public string Name { get; set; }
        public string VersionId { get; set; }
        public string Desc { get; set; }
        public string Culture { get; set; }
        public ApplicationIntent[] Intents { get; set; }
        public ApplicationEntity[] Entities { get; set; }
        public object[] Composites { get; set; }
        public object[] ClosedLists { get; set; }
        [JsonProperty(PropertyName = "bing_entities")]
        public string[] BingEntities { get; set; }
        public object[] Actions { get; set; }
        [JsonProperty(PropertyName = "model_features")]
        public ModelFeature[] ModelFeatures { get; set; }
        [JsonProperty(PropertyName = "regex_features")]
        public object[] RegexFeatures { get; set; }
        public Utterance[] Utterances { get; set; }
    }
}