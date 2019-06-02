using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface ISentimentPhraseService
    {
        List<SentimentPhraseItem> GetSentimentPhrases(string configId = null);
        List<SentimentPhraseItem> CreateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
        List<SentimentPhraseItem> UpdateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
        int RemoveSentimentPhrases(List<SentimentPhraseItem> items, string configId = null);
    }
}