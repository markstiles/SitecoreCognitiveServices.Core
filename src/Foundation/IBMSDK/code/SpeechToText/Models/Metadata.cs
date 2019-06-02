using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Metadata
    {
        [JsonProperty("part_content_type")]
        public string PartContentType { get; set; }
        [JsonProperty("data_parts_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? DataPartsCount { get; set; }
        [JsonProperty("sequence_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? SequenceId { get; set; }
        [JsonProperty("continuous", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Continuous { get; set; }
        [JsonProperty("inactivity_timeout", NullValueHandling = NullValueHandling.Ignore)]
        public double? InactivityTimeout { get; set; }
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keywords { get; set; }
        [JsonProperty("keywords_threshold", NullValueHandling = NullValueHandling.Ignore)]
        public double? KeywordsThreshold { get; set; }
        [JsonProperty("max_alternatives", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAlternatives { get; set; }
        [JsonProperty("word_alternatives_threshold", NullValueHandling = NullValueHandling.Ignore)]
        public double? WordAlternativesThreshold { get; set; }
        [JsonProperty("word_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WordConfidence { get; set; }
        [JsonProperty("timestamps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Timestamps { get; set; }
        [JsonProperty("profanity_filter", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProfanityFilter { get; set; }
        [JsonProperty("smart_formatting", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmartFormatting { get; set; }
        [JsonProperty("speaker_labels", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SpeakerLabels { get; set; }
    }
}