using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions;
using SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText;
using SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class SpeechToTextService : ISpeechToTextService
    {
        protected ISpeechToTextRepository SpeechToTextRepository;
        protected ILogWrapper Logger;

        public SpeechToTextService(
            ISpeechToTextRepository speechToTextRepository,
            ILogWrapper logger)
        {
            SpeechToTextRepository = speechToTextRepository;
            Logger = logger;
        }
        
        public SpeechModelSet GetModels()
        {
            try
            {
                var result = SpeechToTextRepository.GetModels();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.GetModels failed", this, ex);
            }

            return null;
        }

        public SpeechModel GetModel(string modelName)
        {
            try
            {
                var result = SpeechToTextRepository.GetModel(modelName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.GetModel failed", this, ex);
            }

            return null;
        }

        public Session CreateSession(string modelName)
        {
            try
            {
                var result = SpeechToTextRepository.CreateSession(modelName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.CreateSession failed", this, ex);
            }

            return null;
        }

        public RecognizeStatus GetSessionStatus(Session session)
        {
            try
            {
                var result = SpeechToTextRepository.GetSessionStatus(session);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.GetSessionStatus failed", this, ex);
            }

            return null;
        }

        public RecognizeStatus GetSessionStatus(string sessionId)
        {
            try
            {
                var result = SpeechToTextRepository.GetSessionStatus(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.GetSessionStatus failed", this, ex);
            }

            return null;
        }

        public object DeleteSession(Session session)
        {
            try
            {
                var result = SpeechToTextRepository.DeleteSession(session);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.DeleteSession failed", this, ex);
            }

            return null;
        }

        public object DeleteSession(string sessionId)
        {
            try
            {
                var result = SpeechToTextRepository.DeleteSession(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.DeleteSession failed", this, ex);
            }

            return null;
        }

        public SpeechRecognitionEvent Recognize(string contentType, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "", bool? continuous = null, int? inactivityTimeout = null, string[] keywords = null, double? keywordsThreshold = null, int? maxAlternatives = null, double? wordAlternativesThreshold = null, bool? wordConfidence = null, bool? timestamps = null, bool profanityFilter = false, bool? smartFormatting = null, bool? speakerLabels = null)
        {
            try
            {
                var result = SpeechToTextRepository.Recognize(contentType, audio, transferEncoding, model, customizationId, continuous, inactivityTimeout, keywords, keywordsThreshold, maxAlternatives, wordAlternativesThreshold, wordConfidence, timestamps, profanityFilter, smartFormatting, speakerLabels);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.Recognize failed", this, ex);
            }

            return null;
        }

        public SpeechRecognitionEvent Recognize(string contentType, Metadata metaData, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "")
        {
            try
            {
                var result = SpeechToTextRepository.Recognize(contentType, metaData, audio, transferEncoding, model, customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.Recognize failed", this, ex);
            }

            return null;
        }

        public SpeechRecognitionEvent RecognizeWithSession(string sessionId, string contentType, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "", bool? continuous = null, int? inactivityTimeout = null, string[] keywords = null, double? keywordsThreshold = null, int? maxAlternatives = null, double? wordAlternativesThreshold = null, bool? wordConfidence = null, bool? timestamps = null, bool profanityFilter = false, bool? smartFormatting = null, bool? speakerLabels = null)
        {
            try
            {
                var result = SpeechToTextRepository.RecognizeWithSession(sessionId, contentType, audio, transferEncoding, model, customizationId, continuous, inactivityTimeout, keywords, keywordsThreshold, maxAlternatives, wordAlternativesThreshold, wordConfidence, timestamps, profanityFilter, smartFormatting, speakerLabels);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.RecognizeWithSession failed", this, ex);
            }

            return null;
        }

        public SpeechRecognitionEvent RecognizeWithSession(string sessionId, string contentType, Metadata metaData, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "")
        {
            try
            {
                var result = SpeechToTextRepository.RecognizeWithSession(sessionId, contentType, metaData, audio, transferEncoding, model, customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.RecognizeWithSession failed", this, ex);
            }

            return null;
        }
        
        public List<SpeechRecognitionEvent> ObserveResult(string sessionId, int? sequenceId = (int?)null, bool interimResults = false)
        {
            try
            {
                var result = SpeechToTextRepository.ObserveResult(sessionId, sequenceId, interimResults);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ObserveResult failed", this, ex);
            }

            return null;
        }

        public CustomizationID CreateCustomModel(string model, string baseModelName, string description)
        {
            try
            {
                var result = SpeechToTextRepository.CreateCustomModel(model, baseModelName, description);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.CreateCustomModel failed", this, ex);
            }

            return null;
        }

        public CustomizationID CreateCustomModel(CustomModel options)
        {
            try
            {
                var result = SpeechToTextRepository.CreateCustomModel(options);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.CreateCustomModel failed", this, ex);
            }

            return null;
        }

        public Customizations ListCustomModels(string language = "en-US")
        {
            try
            {
                var result = SpeechToTextRepository.ListCustomModels(language);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ListCustomModels failed", this, ex);
            }

            return null;
        }

        public Customization ListCustomModel(string customizationId)
        {
            try
            {
                var result = SpeechToTextRepository.ListCustomModel(customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ListCustomModel failed", this, ex);
            }

            return null;
        }

        public object TrainCustomModel(string customizationId, string wordTypeToAdd = "all")
        {
            try
            {
                var result = SpeechToTextRepository.TrainCustomModel(customizationId, wordTypeToAdd);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.TrainCustomModel failed", this, ex);
            }

            return null;
        }

        public object ResetCustomModel(string customizationId)
        {
            try
            {
                var result = SpeechToTextRepository.ResetCustomModel(customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ResetCustomModel failed", this, ex);
            }

            return null;
        }

        public object UpgradeCustomModel(string customizationId)
        {
            try
            {
                var result = SpeechToTextRepository.UpgradeCustomModel(customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.UpgradeCustomModel failed", this, ex);
            }

            return null;
        }

        public object DeleteCustomModel(string customizationId)
        {
            try
            {
                var result = SpeechToTextRepository.DeleteCustomModel(customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.DeleteCustomModel failed", this, ex);
            }

            return null;
        }

        public object AddCorpus(string customizationId, string corpusName, bool allowOverwrite, Stream body)
        {
            try
            {
                var result = SpeechToTextRepository.AddCorpus(customizationId, corpusName, allowOverwrite, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.AddCorpus failed", this, ex);
            }

            return null;
        }

        public Corpora ListCorpora(string customizationId)
        {
            try
            {
                var result = SpeechToTextRepository.ListCorpora(customizationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ListCorpora failed", this, ex);
            }

            return null;
        }

        public Corpus GetCorpus(string customizationId, string corpusName)
        {
            try
            {
                var result = SpeechToTextRepository.GetCorpus(customizationId, corpusName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.GetCorpus failed", this, ex);
            }

            return null;
        }

        public object DeleteCorpus(string customizationId, string name)
        {
            try
            {
                var result = SpeechToTextRepository.DeleteCorpus(customizationId, name);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.DeleteCorpus failed", this, ex);
            }

            return null;
        }

        public object AddCustomWords(string customizationId, Words body)
        {
            try
            {
                var result = SpeechToTextRepository.AddCustomWords(customizationId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.AddCustomWords failed", this, ex);
            }

            return null;
        }

        public object AddCustomWord(string customizationId, string wordname, WordDefinition body)
        {
            try
            {
                var result = SpeechToTextRepository.AddCustomWord(customizationId, wordname, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.AddCustomWord failed", this, ex);
            }

            return null;
        }

        public WordsList ListCustomWords(string customizationId, WordType? wordType, Sort? sort)
        {
            try
            {
                var result = SpeechToTextRepository.ListCustomWords(customizationId, wordType, sort);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ListCustomWords failed", this, ex);
            }

            return null;
        }

        public WordData ListCustomWord(string customizationId, string wordname)
        {
            try
            {
                var result = SpeechToTextRepository.ListCustomWord(customizationId, wordname);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.ListCustomWord failed", this, ex);
            }

            return null;
        }

        public object DeleteCustomWord(string customizationId, string wordname)
        {
            try
            {
                var result = SpeechToTextRepository.DeleteCustomWord(customizationId, wordname);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeechToTextService.DeleteCustomWord failed", this, ex);
            }

            return null;
        }
    }
}