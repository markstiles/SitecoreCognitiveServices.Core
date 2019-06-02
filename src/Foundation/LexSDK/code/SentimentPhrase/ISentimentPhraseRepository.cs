using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase
{
    public interface ISentimentPhraseRepository
    {
        List<SentimentPhraseItem> GetSentimentPhrases(string configId = null);
        List<SentimentPhraseItem> CreateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
        List<SentimentPhraseItem> UpdateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
        int RemoveSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
    }
}