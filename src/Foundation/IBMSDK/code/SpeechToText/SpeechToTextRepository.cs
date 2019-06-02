using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Extensions;
using SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText
{
    public class SpeechToTextRepository : ISpeechToTextRepository
    {
        #region Constructor

        public static readonly string modelsUrl = "models";
        public static readonly string sessionsUrl = "sessions/";
        public static readonly string recognizeUrl = "recognize/";
        public static readonly string observeUrl = "/observe_result";
        public static readonly string customizationsUrl = "customizations";

        public static readonly string defaultModelName = "en-US_BroadbandModel";

        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public SpeechToTextRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion

        public SpeechModelSet GetModels()
        {
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                            .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{modelsUrl}")
                            .As<SpeechModelSet>()
                            .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public SpeechModel GetModel(string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
                throw new ArgumentNullException("modelName can not be null or empty");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                        .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{modelsUrl}/{modelName}")
                        .As<SpeechModel>()
                        .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public Session CreateSession(string modelName)
        {
            try
            {
                if (string.IsNullOrEmpty(modelName))
                    modelName = defaultModelName;

                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{sessionsUrl}")
                               .WithArgument("model", modelName)
                               .WithHeader("accept", HttpMediaType.APPLICATION_JSON)
                               .As<Session>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public RecognizeStatus GetSessionStatus(Session session)
        {
            var result = GetSessionStatus(session.SessionId);

            return result;
        }

        public RecognizeStatus GetSessionStatus(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException("session id can not be null or empty");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{sessionsUrl}{sessionId}/{recognizeUrl}")
                               .WithHeader("Cookie", sessionId)
                               .WithHeader("accept", HttpMediaType.APPLICATION_JSON)
                               .As<RecognizeStatus>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object DeleteSession(Session session)
        {
            var result = DeleteSession(session.SessionId);

            return result;
        }

        public object DeleteSession(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException("session id can not be null or empty");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .DeleteAsync(string.Format("{0}{1}/{2}", ApiKeys.SpeechToTextEndpoint, sessionsUrl, sessionId))
                               .AsMessage()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public SpeechRecognitionEvent Recognize(string contentType, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "", bool? continuous = null, int? inactivityTimeout = null, string[] keywords = null, double? keywordsThreshold = null, int? maxAlternatives = null, double? wordAlternativesThreshold = null, bool? wordConfidence = null, bool? timestamps = null, bool profanityFilter = false, bool? smartFormatting = null, bool? speakerLabels = null)
        {
            if (audio == null)
                throw new ArgumentNullException($"{nameof(audio)}");

            var result = Recognize(sessionId: string.Empty,
                               contentType: contentType,
                               transferEncoding: transferEncoding,
                               metaData: null,
                               audio: audio,
                               customizationId: customizationId,
                               continuous: continuous,
                               keywords: keywords,
                               keywordsThreshold: keywordsThreshold,
                               wordAlternativesThreshold: wordAlternativesThreshold,
                               wordConfidence: wordConfidence,
                               timestamps: timestamps,
                               smartFormatting: smartFormatting,
                               speakerLabels: speakerLabels,
                               profanityFilter: profanityFilter,
                               maxAlternatives: maxAlternatives,
                               inactivityTimeout: inactivityTimeout,
                               model: model);

            return result;
        }

        public SpeechRecognitionEvent Recognize(string contentType, Metadata metaData, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "")
        {
            if (metaData == null)
                throw new ArgumentNullException($"{nameof(metaData)}");
            if (audio == null)
                throw new ArgumentNullException($"{nameof(audio)}");

            var result = Recognize(sessionId: string.Empty,
                               contentType: contentType,
                               transferEncoding: transferEncoding,
                               metaData: metaData,
                               audio: audio,
                               customizationId: customizationId,
                               model: model);

            return result;
        }

        public SpeechRecognitionEvent RecognizeWithSession(string sessionId, string contentType, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "", bool? continuous = null, int? inactivityTimeout = null, string[] keywords = null, double? keywordsThreshold = null, int? maxAlternatives = null, double? wordAlternativesThreshold = null, bool? wordConfidence = null, bool? timestamps = null, bool profanityFilter = false, bool? smartFormatting = null, bool? speakerLabels = null)
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException($"{nameof(sessionId)}");
            if (audio == null)
                throw new ArgumentNullException($"{nameof(audio)}");

            var result = Recognize(sessionId,
                               contentType: contentType,
                               transferEncoding: transferEncoding,
                               metaData: null,
                               audio: audio,
                               customizationId: customizationId,
                               continuous: continuous,
                               keywords: keywords,
                               keywordsThreshold: keywordsThreshold,
                               wordAlternativesThreshold: wordAlternativesThreshold,
                               wordConfidence: wordConfidence,
                               timestamps: timestamps,
                               smartFormatting: smartFormatting,
                               speakerLabels: speakerLabels,
                               profanityFilter: profanityFilter,
                               maxAlternatives: maxAlternatives,
                               inactivityTimeout: inactivityTimeout,
                               model: model);

            return result;
        }

        public SpeechRecognitionEvent RecognizeWithSession(string sessionId, string contentType, Metadata metaData, Stream audio, string transferEncoding = "", string model = "en-US_BroadbandModel", string customizationId = "")
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException($"{nameof(sessionId)}");
            if (metaData == null)
                throw new ArgumentNullException($"{nameof(metaData)}");
            if (audio == null)
                throw new ArgumentNullException($"{nameof(audio)}");

            var result = Recognize(sessionId,
                               contentType: contentType,
                               transferEncoding: transferEncoding,
                               metaData: metaData,
                               audio: audio,
                               customizationId: customizationId,
                               model: model);

            return result;
        }

        private SpeechRecognitionEvent Recognize(string sessionId, string contentType, Metadata metaData, Stream audio, string transferEncoding = "", string model = "", string customizationId = "", bool? continuous = null, int? inactivityTimeout = null, string[] keywords = null, double? keywordsThreshold = null, int? maxAlternatives = null, double? wordAlternativesThreshold = null, bool? wordConfidence = null, bool? timestamps = null, bool profanityFilter = false, bool? smartFormatting = null, bool? speakerLabels = null)
        {
            if (string.IsNullOrEmpty(contentType))
                throw new ArgumentNullException($"{nameof(contentType)}");
            
            try
            {
                string urlService = string.Empty;
                IRequest request = null;

                if (string.IsNullOrEmpty(sessionId))
                {
                    request =
                        RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{recognizeUrl}");
                }
                else
                {
                    request =
                        RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                                   .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{sessionsUrl}{sessionId}/{recognizeUrl}")
                                   .WithHeader("Cookie", sessionId);
                }

                if (!string.IsNullOrEmpty(transferEncoding))
                    request.WithHeader("Transfer-Encoding", transferEncoding);

                if (metaData == null)
                {
                    // if a session exists, the model should not be sent
                    if (string.IsNullOrEmpty(sessionId))
                        request.WithArgument("model", model);

                    if (!string.IsNullOrEmpty(customizationId))
                        request.WithArgument("customization_id", customizationId);

                    if (continuous.HasValue)
                        request.WithArgument("continuous", continuous.Value);

                    if (inactivityTimeout.HasValue && inactivityTimeout.Value > 0)
                        request.WithArgument("inactivity_timeout", inactivityTimeout.Value);

                    if (keywords != null && keywords.Length > 0)
                        request.WithArgument("keywords", keywords);

                    if (keywordsThreshold.HasValue && keywordsThreshold.Value > 0)
                        request.WithArgument("keywords_threshold", keywordsThreshold.Value);

                    if (maxAlternatives.HasValue && maxAlternatives.Value > 0)
                        request.WithArgument("max_alternatives", maxAlternatives.Value);

                    if (wordAlternativesThreshold.HasValue && wordAlternativesThreshold.Value > 0)
                        request.WithArgument("word_alternatives_threshold", wordAlternativesThreshold.Value);

                    if (wordConfidence.HasValue)
                        request.WithArgument("word_confidence", wordConfidence.Value);

                    if (timestamps.HasValue)
                        request.WithArgument("timestamps", timestamps.Value);

                    if (profanityFilter)
                        request.WithArgument("profanity_filter", profanityFilter);

                    if (smartFormatting.HasValue)
                        request.WithArgument("smart_formatting", smartFormatting.Value);

                    if (speakerLabels.HasValue)
                        request.WithArgument("speaker_labels", speakerLabels.Value);

                    StreamContent bodyContent = new StreamContent(audio);
                    bodyContent.Headers.Add("Content-Type", contentType);

                    request.WithBodyContent(bodyContent);
                }
                else
                {
                    var json = JsonConvert.SerializeObject(metaData);

                    StringContent metadata = new StringContent(json);
                    metadata.Headers.ContentType = MediaTypeHeaderValue.Parse(HttpMediaType.APPLICATION_JSON);

                    var audioContent = new ByteArrayContent((audio as Stream).ReadAllBytes());
                    audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

                    MultipartFormDataContent formData = new MultipartFormDataContent();

                    // if a session exists, the model should not be sent
                    if (string.IsNullOrEmpty(sessionId))
                        request.WithArgument("model", model);

                    formData.Add(metadata, "metadata");
                    formData.Add(audioContent, "upload");

                    request.WithBodyContent(formData);
                }

                var result =
                    request.As<SpeechRecognitionEvent>()
                           .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public List<SpeechRecognitionEvent> ObserveResult(string sessionId, int? sequenceId = (int?)null, bool interimResults = false)
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException("SessionId can not be null or empty");

            try
            {
                var request = RepositoryClient
                    .WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                    .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{sessionsUrl}{sessionId}{observeUrl}");

                if (sequenceId.HasValue)
                    request.WithArgument("sequence_id", sequenceId);

                if (interimResults)
                    request.WithArgument("interim_results", interimResults);

                var strResult =
                    request.AsString()
                           .Result;
                var serializer = new JsonSerializer();

                using (var jsonReader = new JsonTextReader(new StringReader(strResult)))
                {
                    jsonReader.SupportMultipleContent = true;
                    var result = new List<SpeechRecognitionEvent>();

                    while (jsonReader.Read())
                    {
                        var speechRecognitionEvent = serializer.Deserialize<SpeechRecognitionEvent>(jsonReader);
                        result.Add(speechRecognitionEvent);
                    }

                    return result;
                }
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public CustomizationID CreateCustomModel(string model, string baseModelName, string description)
        {
            return CreateCustomModel(new CustomModel()
            {
                Name = model,
                BaseModelName = baseModelName,
                Description = description
            });
        }

        public CustomizationID CreateCustomModel(CustomModel options)
        {
            if (string.IsNullOrEmpty(options.Name))
                throw new ArgumentNullException(nameof(options.Name));

            if (string.IsNullOrEmpty(options.BaseModelName))
                throw new ArgumentNullException(nameof(options.BaseModelName));

            try
            {
                var json =
                    JObject.FromObject(options);

                var result =
                    RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}")
                               .WithBody<JObject>(json, MediaTypeHeaderValue.Parse(HttpMediaType.APPLICATION_JSON))
                               .As<CustomizationID>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public Customizations ListCustomModels(string language = "en-US")
        {
            if (string.IsNullOrEmpty(language))
                throw new ArgumentNullException($"{nameof(language)}");

            try
            {
                var result =
                    RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}")
                               .WithArgument("language", language)
                               .As<Customizations>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public Customization ListCustomModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                              .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}")
                              .As<Customization>()
                              .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object TrainCustomModel(string customizationId, string wordTypeToAdd = "all")
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                              .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/train")
                              .WithArgument("word_type_to_add", wordTypeToAdd)
                              .AsString();

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object ResetCustomModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                              .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/reset")
                              .AsString();

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object UpgradeCustomModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                              .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/upgrade_model")
                              .AsString();

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object DeleteCustomModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                              .DeleteAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}")
                              .AsString();

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object AddCorpus(string customizationId, string corpusName, bool allowOverwrite, Stream body)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(corpusName))
                throw new ArgumentNullException($"{nameof(corpusName)}");
            if (corpusName.ToLower().Equals("user"))
                throw new ArgumentException($"The {nameof(corpusName)} can not be the string 'user'");
            if (corpusName.Any(Char.IsWhiteSpace))
                throw new ArgumentException($"The {nameof(corpusName)} cannot contain spaces");
            if (body == null)
                throw new ArgumentNullException($"The {nameof(body)} is required");
            
            try
            {
                var formData = new MultipartFormDataContent();

                var forcedGlossaryContent = new ByteArrayContent((body as Stream).ReadAllBytes());
                forcedGlossaryContent.Headers.ContentType = MediaTypeHeaderValue.Parse(HttpMediaType.TEXT);
                formData.Add(forcedGlossaryContent, "body");

                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                                  .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/corpora/{corpusName}")
                                  .WithArgument("allow_overwrite ", allowOverwrite)
                                  .WithBodyContent(formData)
                                  .AsString()
                                  .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public Corpora ListCorpora(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/corpora")
                               .As<Corpora>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public Corpus GetCorpus(string customizationId, string corpusName)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(corpusName))
                throw new ArgumentNullException($"{nameof(corpusName)}");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/corpora/{corpusName}")
                               .As<Corpus>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object DeleteCorpus(string customizationId, string name)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"{nameof(name)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .DeleteAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/corpora/{name}")
                               .AsString()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object AddCustomWords(string customizationId, Words body)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (body == null)
                throw new ArgumentNullException($"{nameof(body)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .PostAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/words")
                               .WithBody<Words>(body)
                               .AsString()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object AddCustomWord(string customizationId, string wordname, WordDefinition body)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(wordname))
                throw new ArgumentNullException($"{nameof(wordname)}");
            if (body == null)
                throw new ArgumentNullException($"{nameof(body)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .PutAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/words/{wordname}")
                               .WithBody<WordDefinition>(body)
                               .AsString()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public WordsList ListCustomWords(string customizationId, WordType? wordType, Sort? sort)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            
            try
            {

                var request = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/words");

                if (wordType.HasValue)
                {
                    request.WithArgument("word_type", wordType.Value.ToString().ToLower());
                }

                if (sort.HasValue)
                {
                    switch (sort.Value)
                    {
                        case Sort.AscendingAlphabetical:
                            request.WithArgument("sort", "+alphabetical");
                            break;
                        case Sort.DescendingAlphabetical:
                            request.WithArgument("sort", "-alphabetical");
                            break;
                        case Sort.AscendingCount:
                            request.WithArgument("sort", "+count");
                            break;
                        case Sort.DescendingCount:
                            request.WithArgument("sort", "-count");
                            break;
                    }
                }

                var result = request.As<WordsList>()
                           .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public WordData ListCustomWord(string customizationId, string wordname)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(wordname))
                throw new ArgumentNullException($"{nameof(wordname)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                               .GetAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/words/{wordname}")
                               .As<WordData>()
                               .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }

        public object DeleteCustomWord(string customizationId, string wordname)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException($"{nameof(customizationId)}");
            if (string.IsNullOrEmpty(wordname))
                throw new ArgumentNullException($"{nameof(wordname)}");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.SpeechToTextUsername, ApiKeys.SpeechToTextPassword)
                           .DeleteAsync($"{ApiKeys.SpeechToTextEndpoint}{customizationsUrl}/{customizationId}/words/{wordname}");
                
                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException as ServiceResponseException;
            }
        }
    }
}