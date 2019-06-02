﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models
{
    public class Voice
    {
        private const string MALE = "male";
        private const string FEMALE = "female";

        public static readonly Voice DE_DIETER = new Voice("de-DE_DieterVoice", MALE, "de-DE");
        public static readonly Voice DE_BIRGIT = new Voice("de-DE_BirgitVoice", FEMALE, "de-DE");
        public static readonly Voice EN_ALLISON = new Voice("en-US_AllisonVoice", FEMALE, "en-US");
        public static readonly Voice EN_LISA = new Voice("en-US_LisaVoice", FEMALE, "en-US");
        public static readonly Voice EN_MICHAEL = new Voice("en-US_MichaelVoice", MALE, "en-US");
        public static readonly Voice ES_ENRIQUE = new Voice("es-ES_EnriqueVoice", MALE, "es-ES");
        public static readonly Voice ES_LAURA = new Voice("es-ES_LauraVoice", FEMALE, "es-US");
        public static readonly Voice ES_SOFIA = new Voice("es-US_SofiaVoice", FEMALE, "es-US");
        public static readonly Voice FR_RENEE = new Voice("fr-FR_ReneeVoice", FEMALE, "fr-FR");
        public static readonly Voice GB_KATE = new Voice("en-GB_KateVoice", FEMALE, "en-GB");
        public static readonly Voice IT_FRANCESCA = new Voice("it-IT_FrancescaVoice", FEMALE, "it-IT");
        public static readonly Voice JA_EMI = new Voice("ja-JP_EmiVoice", FEMALE, "ja-JP");
        public static readonly Voice PT_ISABELA = new Voice("pt-BR_IsabelaVoice", FEMALE, "pt-BR");


        [JsonProperty("customizable")]
        public bool Customizable { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        public Voice() { }

        public Voice(string name, string gender, string language)
        {
            this.Name = name;
            this.Gender = gender;
            this.Language = language;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    internal class Voices
    {
        [JsonProperty("voices")]
        internal List<Voice> VoiceList { get; set; }
    }
}
