using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models
{
    public class VocabulariesSummary : Paged<VocabularySummary>
    {

        /// <summary>
        /// The Vocabularies
        /// </summary>
        public List<VocabularySummary> Items { get; set; } = new List<VocabularySummary>();
    }
}