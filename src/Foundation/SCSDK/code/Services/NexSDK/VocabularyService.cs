using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Reflection.Emit;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class VocabularyService : IVocabularyService
    {
        protected readonly IVocabularyRepository VocabularyRepository;
        protected readonly ILogWrapper Logger;
        
        public VocabularyService(
            IVocabularyRepository vocabularyRepository,
            ILogWrapper logger)
        {
            VocabularyRepository = vocabularyRepository;
            Logger = logger;
        }
        
        public async Task<VocabulariesSummary> List(VocabulariesQuery query)
        {
            try
            {
                var result = await VocabularyRepository.List(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VocabularyService.List failed", this, ex);
            }

            return null;
        }

        public async Task<VocabularyResponse> Get(VocabularyWordsQuery query)
        {
            try
            {
                var result = await VocabularyRepository.Get(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VocabularyService.Get failed", this, ex);
            }

            return null;
        }

        public async Task Remove(VocabularyRemoveCriteria criteria)
        {
            try
            {
                VocabularyRepository.Remove(criteria);
            }
            catch (Exception ex)
            {
                Logger.Error("VocabularyService.Remove failed", this, ex);
            }
        }
    }
}