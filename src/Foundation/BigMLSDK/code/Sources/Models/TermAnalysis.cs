using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class TermAnalysis
    {
        public string bigrams { get; set; }
        public bool case_sensitive { get; set; }
        public bool enabled { get; set; }
        public string[] excluded_terms { get; set; }
        public string language { get; set; }
        public int ngrams { get; set; }
        public bool stem_words { get; set; }
        /// <summary>
        /// light, normal or aggressive
        /// </summary>
        public string stopword_diligence { get; set; }
        /// <summary>
        /// none (remove no stopwords), selected_language (remove stopwords from the provided language), and all_languages (remove stopwords from all languages)
        /// </summary>
        public string stopword_removal { get; set; }
        /// <summary>
        /// non_dictionary: Filters all terms that are not dictionary words in the provided language.
        /// non_language_characters: Filters any term containing a character not from the Unicode blocks common for words in the provided language.
        /// For example, if the language is ru(Russian), all terms containing non-Cyrillic characters will be filtered out. 
        /// Non-language characters always includes numeric digits, regardless of language. 
        /// numeric_digits: Filters any term that contains a numeric digit in [0 - 9].
        /// html_keywords: Filters JavaScript/HTML keywords commonly seen in HTML documents. 
        /// single_tokens: Filters terms that contain only a single token (e.g., only pass full terms). 
        /// For this to return a non-empty set of terms, you must specify token_mode as either all or full_terms_only.
        /// </summary>
        public string[] term_filters { get; set; }
        public object[] term_regexps { get; set; }
        public string token_mode { get; set; }
        public bool use_stopwords { get; set; }
    }
}