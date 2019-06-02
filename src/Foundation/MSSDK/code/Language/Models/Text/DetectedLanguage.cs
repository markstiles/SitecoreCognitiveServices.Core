﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text {
    public class DetectedLanguage {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iso6391Name")]
        public string Iso639Name { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }
    }
}
