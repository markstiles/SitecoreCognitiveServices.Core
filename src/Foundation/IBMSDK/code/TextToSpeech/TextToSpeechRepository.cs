using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech
{
    public class TextToSpeechRepository : ITextToSpeechRepository
    {
        #region Constructor
        
        protected static readonly string voicesUrl = "voices/";
        protected static readonly string synthesizeUrl = "synthesize";
        protected static readonly string pronunciationUrl = "pronunciation";
        protected static readonly string customizationsUrl = "customizations/";
        protected static readonly string wordsUrl = "/words/";
        
        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public TextToSpeechRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public List<Voice> GetVoices()
        {
            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{voicesUrl}")
                          .As<Voices>()
                          .Result.VoiceList;

            return result;
        }

        public Voice GetVoice(string voiceName)
        {
            if (string.IsNullOrEmpty(voiceName))
                throw new ArgumentNullException("Parameter 'voiceName' must be provided");

            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{voicesUrl}{voiceName}")
                          .As<Voice>()
                          .Result;

            return result;
        }

        public Pronunciation GetPronunciation(string text)
        {
            var result = GetPronunciation(text, null, null);

            return result;
        }

        public Pronunciation GetPronunciation(string text, Voice voice)
        {
            var result = GetPronunciation(text, voice, null);

            return result;
        }

        public Pronunciation GetPronunciation(string text, Voice voice = null, Phoneme phoneme = null)
        {
            var result = getPronunciation(text, voice, phoneme);

            return result;
        }

        private Pronunciation getPronunciation(string text, Voice voice, Phoneme phoneme)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("Parameter 'text' must be provided");

            var builder = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{pronunciationUrl}")
                          .WithArgument("text", text);

            if (voice != null)
                builder.WithArgument("voice", voice.Name);

            if (phoneme != null)
                builder.WithArgument("format", phoneme.Value);

            return builder.As<Pronunciation>().Result;
        }

        public Stream Synthesize(string text, Voice voice)
        {
            var result = synthesize(text, voice, AudioType.OGG);

            return result;
        }

        public Stream Synthesize(string text, Voice voice, AudioType audioType)
        {
            var result = synthesize(text, voice, audioType);

            return result;
        }

        private Stream synthesize(string text, Voice voice, AudioType audioType)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("Parameter 'text' must be provided");
            if (voice == null)
                throw new ArgumentNullException("Parameter 'voice' must be provided");
            if (audioType == null)
                throw new ArgumentNullException("Parameter 'audioType' must be provided");

            var builder = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{synthesizeUrl}")
                          .WithArgument("text", text)
                          .WithArgument("voice", voice.Name)
                          .WithArgument("accept", audioType.Value);

            return new MemoryStream(builder.AsByteArray().Result);
        }

        public List<CustomVoiceModel> GetCustomVoiceModels()
        {
            var result = GetCustomVoiceModels(null);

            return result;
        }

        public List<CustomVoiceModel> GetCustomVoiceModels(string language)
        {
            var ret = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}");

            if (!string.IsNullOrEmpty(language))
                ret.WithArgument("language", language);

            var result = ret
                .As<CustomVoiceModels>()
                .Result
                .CustomVoiceList;

            return result;
        }

        public CustomVoiceModel GetCustomVoiceModel(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentNullException("ModelId must not be empty");

            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{modelId}")
                          .As<CustomVoiceModel>()
                          .Result;

            return result;
        }

        public CustomVoiceModel SaveCustomVoiceModel(CustomVoiceModel model)
        {
            var result = (string.IsNullOrEmpty(model.Id))
                ? saveNewCustomVoiceModel(model)
                : updateCustomVoiceModel(model);

            return result;
        }

        public CustomVoiceModel updateCustomVoiceModel(CustomVoiceModel model)
        {
            CustomVoiceModelUpdate updateModel = new CustomVoiceModelUpdate()
            {
                Name = model.Name,
                Description = model.Description,
                Words = model.Words ?? new List<CustomWordTranslation>()
            };

            string s = JsonConvert.SerializeObject(updateModel);
            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                    .PostAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{model.Id}", updateModel)
                    .WithBody<CustomVoiceModelUpdate>(updateModel)
                    .AsMessage();

            return model;
        }

        private CustomVoiceModel saveNewCustomVoiceModel(CustomVoiceModel model)
        {
            CustomVoiceModelCreate createModel = new CustomVoiceModelCreate()
            {
                Name = model.Name,
                Description = model.Description,
                Language = model.Language
            };

            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                    .PostAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}")
                    .WithBody<CustomVoiceModelCreate>(createModel)
                    .As<CustomVoiceModel>()
                    .Result;

            model.Id = result.Id;

            return model;
        }

        public void DeleteCustomVoiceModel(CustomVoiceModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
                throw new ArgumentNullException("Model id must not be empty");

            DeleteCustomVoiceModel(model.Id);
        }

        public void DeleteCustomVoiceModel(string modelID)
        {
            if (string.IsNullOrEmpty(modelID))
                throw new ArgumentNullException("Model id must not be empty");

            RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .DeleteAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{modelID}")
                          .AsMessage();
        }

        public List<CustomWordTranslation> GetWords(CustomVoiceModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
                throw new ArgumentNullException("Model id must not be empty");

            var result = GetWords(model.Id);

            return result;
        }

        public List<CustomWordTranslation> GetWords(string modelID)
        {
            if (string.IsNullOrEmpty(modelID))
                throw new ArgumentNullException("Model id must not be empty");

            var result = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                          .GetAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{modelID}{wordsUrl}")
                          .As<CustomWordTranslations>()
                          .Result.Words;

            return result;
        }

        public void SaveWords(CustomVoiceModel model, params CustomWordTranslation[] translations)
        {
            if (string.IsNullOrEmpty(model.Id))
                throw new ArgumentNullException("Model id must not be empty");
            if (translations.Length ==0)
                throw new Exception("Must have at least one word to save");

            SaveWords(model.Id, translations);
        }

        public void SaveWords(string modelID, params CustomWordTranslation[] translations)
        {
            if (string.IsNullOrEmpty(modelID))
                throw new ArgumentNullException("Model id must not be empty");
            if (translations.Length == 0)
                throw new Exception("Must have at least one word to save");

            CustomWordTranslations customWordTranslations = new CustomWordTranslations()
            {
                Words = translations.ToList()
            };

            var x = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
                      .PostAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{modelID}{wordsUrl}")
                      .WithBody<CustomWordTranslations>(customWordTranslations)
                      .AsMessage().Result;
        }

        public void DeleteWord(CustomVoiceModel model, CustomWordTranslation translation)
        {
            if (string.IsNullOrEmpty(model.Id))
                throw new ArgumentNullException("Model id must not be empty");
            if (string.IsNullOrEmpty(translation.Word))
                throw new ArgumentNullException("Word must not be empty");

            DeleteWord(model.Id, translation.Word);
        }

        public void DeleteWord(string modelID, CustomWordTranslation translation)
        {
            if (string.IsNullOrEmpty(modelID))
                throw new ArgumentNullException("Model id must not be empty");
            if (string.IsNullOrEmpty(translation.Word))
                throw new ArgumentNullException("Word must not be empty");

            DeleteWord(modelID, translation.Word);
        }

        public void DeleteWord(CustomVoiceModel model, string word)
        {
            if (string.IsNullOrEmpty(model.Id))
                throw new ArgumentNullException("Model id must not be empty");
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException("Word must not be empty");

            DeleteWord(model.Id, word);
        }

        public void DeleteWord(string modelID, string word)
        {
            if (string.IsNullOrEmpty(modelID))
                throw new ArgumentNullException("Model id must not be empty");
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException("Word must not be empty");

            var r = RepositoryClient.WithAuthentication(ApiKeys.TextToSpeechUsername, ApiKeys.TextToSpeechPassword)
              .DeleteAsync($"{ApiKeys.TextToSpeechEndpoint}{customizationsUrl}{modelID}{wordsUrl}{word}")
              .AsMessage()
              .Result;
        }
    }
}
