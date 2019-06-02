using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class SentimentPhraseService : ISentimentPhraseService
    {
        protected ISentimentPhraseRepository SentimentPhraseRepository;
        protected ILogWrapper Logger;

        public SentimentPhraseService(
            ISentimentPhraseRepository sentimentPhraseRepository,
            ILogWrapper logger)
        {
            SentimentPhraseRepository = sentimentPhraseRepository;
            Logger = logger;
        }
        
        public virtual List<SentimentPhraseItem> GetSentimentPhrases(string configId = null)
        {
            try
            {
                var result = SentimentPhraseRepository.GetSentimentPhrases(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentPhraseRepository.GetSentimentPhrases failed", this, ex);
            }

            return null;
        }

        public virtual List<SentimentPhraseItem> CreateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            try
            {
                var result = SentimentPhraseRepository.CreateSentimentPhrases(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentPhraseRepository.CreateSentimentPhrases failed", this, ex);
            }

            return null;
        }

        public virtual List<SentimentPhraseItem> UpdateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            try
            {
                var result = SentimentPhraseRepository.UpdateSentimentPhrases(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentPhraseRepository.UpdateSentimentPhrases failed", this, ex);
            }

            return null;
        }

        public virtual int RemoveSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            try
            {
                var result = SentimentPhraseRepository.RemoveSentimentPhrases(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentPhraseRepository.RemoveSentimentPhrases failed", this, ex);
            }

            return -1;
        }
    }
}