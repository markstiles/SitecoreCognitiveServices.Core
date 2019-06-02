using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech;
using SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class TextToSpeechService : ITextToSpeechService
    {
        protected ITextToSpeechRepository TextToSpeechRepository;
        protected ILogWrapper Logger;

        public TextToSpeechService(
            ITextToSpeechRepository textToSpeechRepository,
            ILogWrapper logger)
        {
            TextToSpeechRepository = textToSpeechRepository;
            Logger = logger;
        }
        
        public List<Voice> GetVoices()
        {
            try
            {
                var result = TextToSpeechRepository.GetVoices();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetVoices failed", this, ex);
            }

            return null;
        }

        public Voice GetVoice(string voiceName)
        {
            try
            {
                var result = TextToSpeechRepository.GetVoice(voiceName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetVoice failed", this, ex);
            }

            return null;
        }

        public Pronunciation GetPronunciation(string text)
        {
            try
            {
                var result = TextToSpeechRepository.GetPronunciation(text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetPronunciation failed", this, ex);
            }

            return null;
        }

        public Pronunciation GetPronunciation(string text, Voice voice)
        {
            try
            {
                var result = TextToSpeechRepository.GetPronunciation(text, voice);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetPronunciation failed", this, ex);
            }

            return null;
        }

        public Pronunciation GetPronunciation(string text, Voice voice = null, Phoneme phoneme = null)
        {
            try
            {
                var result = TextToSpeechRepository.GetPronunciation(text, voice, phoneme);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetPronunciation failed", this, ex);
            }

            return null;
        }

        public Stream Synthesize(string text, Voice voice)
        {
            try
            {
                var result = TextToSpeechRepository.Synthesize(text, voice);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.Synthesize failed", this, ex);
            }

            return null;
        }

        public Stream Synthesize(string text, Voice voice, AudioType audioType)
        {
            try
            {
                var result = TextToSpeechRepository.Synthesize(text, voice, audioType);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.Synthesize failed", this, ex);
            }

            return null;
        }
        
        public List<CustomVoiceModel> GetCustomVoiceModels()
        {
            try
            {
                var result = TextToSpeechRepository.GetCustomVoiceModels();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetCustomVoiceModels failed", this, ex);
            }

            return null;
        }

        public List<CustomVoiceModel> GetCustomVoiceModels(string language)
        {
            try
            {
                var result = TextToSpeechRepository.GetCustomVoiceModels(language);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetCustomVoiceModels failed", this, ex);
            }

            return null;
        }

        public CustomVoiceModel GetCustomVoiceModel(string modelId)
        {
            try
            {
                var result = TextToSpeechRepository.GetCustomVoiceModel(modelId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetCustomVoiceModel failed", this, ex);
            }

            return null;
        }

        public CustomVoiceModel SaveCustomVoiceModel(CustomVoiceModel model)
        {
            try
            {
                var result = TextToSpeechRepository.SaveCustomVoiceModel(model);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.SaveCustomVoiceModel failed", this, ex);
            }

            return null;
        }
        
        public void DeleteCustomVoiceModel(CustomVoiceModel model)
        {
            try
            {
                TextToSpeechRepository.DeleteCustomVoiceModel(model);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteCustomVoiceModel failed", this, ex);
            }
        }

        public void DeleteCustomVoiceModel(string modelID)
        {
            try
            {
                TextToSpeechRepository.DeleteCustomVoiceModel(modelID);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteCustomVoiceModel failed", this, ex);
            }
        }

        public List<CustomWordTranslation> GetWords(CustomVoiceModel model)
        {
            try
            {
                var result = TextToSpeechRepository.GetWords(model);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetWords failed", this, ex);
            }

            return null;
        }

        public List<CustomWordTranslation> GetWords(string modelID)
        {
            try
            {
                var result = TextToSpeechRepository.GetWords(modelID);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetWords failed", this, ex);
            }

            return null;
        }

        public void SaveWords(CustomVoiceModel model, params CustomWordTranslation[] translations)
        {
            try
            {
                TextToSpeechRepository.SaveWords(model, translations);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.GetVoices failed", this, ex);
            }
        }

        public void SaveWords(string modelID, params CustomWordTranslation[] translations)
        {
            try
            {
                TextToSpeechRepository.SaveWords(modelID, translations);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.SaveWords failed", this, ex);
            }
        }

        public void DeleteWord(CustomVoiceModel model, CustomWordTranslation translation)
        {
            try
            {
                TextToSpeechRepository.DeleteWord(model, translation);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteWord failed", this, ex);
            }
        }

        public void DeleteWord(string modelID, CustomWordTranslation translation)
        {
            try
            {
                TextToSpeechRepository.DeleteWord(modelID, translation);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteWord failed", this, ex);
            }
        }

        public void DeleteWord(CustomVoiceModel model, string word)
        {
            try
            {
                TextToSpeechRepository.DeleteWord(model, word);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteWord failed", this, ex);
            }
        }

        public void DeleteWord(string modelID, string word)
        {
            try
            {
                TextToSpeechRepository.DeleteWord(modelID, word);
            }
            catch (Exception ex)
            {
                Logger.Error("TextToSpeechService.DeleteWord failed", this, ex);
            }
        }
    }
}