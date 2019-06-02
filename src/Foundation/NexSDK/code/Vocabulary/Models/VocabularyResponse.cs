using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models
{
    public class VocabularyResponse : Paged<Word>
    {
        public Guid Id { get; set; }
        
        public List<Word> Items { get; set; }
    }
}