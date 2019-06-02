using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer;
using SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class ToneAnalyzerService : IToneAnalyzerService
    {
        protected IToneAnalyzerRepository ToneAnalyzerRepository;
        protected ILogWrapper Logger;

        public ToneAnalyzerService(
            IToneAnalyzerRepository toneAnalyzerRepository,
            ILogWrapper logger)
        {
            ToneAnalyzerRepository = toneAnalyzerRepository;
            Logger = logger;
        }
        
        public ToneAnalysis Tone(ToneInput toneInput, string contentType, bool? sentences = null, List<string> tones = null, string contentLanguage = null, string acceptLanguage = null)
        {
            try
            {
                var result = ToneAnalyzerRepository.Tone(toneInput, contentType, sentences, tones, contentLanguage, acceptLanguage);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ToneAnalyzerService.Tone failed", this, ex);
            }

            return null;
        }

        public UtteranceAnalyses ToneChat(ToneChatInput utterances, string acceptLanguage = null)
        {
            try
            {
                var result = ToneAnalyzerRepository.ToneChat(utterances, acceptLanguage);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ToneAnalyzerService.ToneChat failed", this, ex);
            }

            return null;
        }
    }
}