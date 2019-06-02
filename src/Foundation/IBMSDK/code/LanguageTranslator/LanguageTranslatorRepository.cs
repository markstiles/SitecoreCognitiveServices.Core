using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Extensions;
using SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator
{
    public class LanguageTranslatorRepository : ILanguageTranslatorRepository
    {
        #region Constructor

        protected static readonly string translateUrl = "translate";
        protected static readonly string identifyUrl = "identify";
        protected static readonly string languagesUrl = "identifiable_languages";
        protected static readonly string modelsUrl = "models";

        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public LanguageTranslatorRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public TranslationResult Translate(TranslateRequest body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .PostAsync($"{ApiKeys.LanguageTranslatorEndpoint}{translateUrl}")
                                .WithBody<TranslateRequest>(body)
                                .As<TranslationResult>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public IdentifiedLanguages Identify(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .PostAsync($"{ApiKeys.LanguageTranslatorEndpoint}{identifyUrl}")
                                .WithBodyContent(new StringContent(text, Encoding.UTF8, HttpMediaType.TEXT_PLAIN))
                                .As<IdentifiedLanguages>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public IdentifiableLanguages ListIdentifiableLanguages()
        {
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .GetAsync($"{ApiKeys.LanguageTranslatorEndpoint}{languagesUrl}")
                                .As<IdentifiableLanguages>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TranslationModel CreateModel(string baseModelId, string name = null, System.IO.Stream forcedGlossary = null, System.IO.Stream parallelCorpus = null, Stream monolingualCorpus = null)
        {
            if (string.IsNullOrEmpty(baseModelId))
                throw new ArgumentNullException(nameof(baseModelId));
            
            try
            {
                var formData = new MultipartFormDataContent();

                if (forcedGlossary != null)
                {
                    var forcedGlossaryContent = new ByteArrayContent(forcedGlossary.ReadAllBytes());
                    MediaTypeHeaderValue contentType;
                    MediaTypeHeaderValue.TryParse("application/octet-stream", out contentType);
                    forcedGlossaryContent.Headers.ContentType = contentType;
                    formData.Add(forcedGlossaryContent, "forced_glossary", "filename");
                }

                if (parallelCorpus != null)
                {
                    var parallelCorpusContent = new ByteArrayContent(parallelCorpus.ReadAllBytes());
                    MediaTypeHeaderValue contentType;
                    MediaTypeHeaderValue.TryParse("application/octet-stream", out contentType);
                    parallelCorpusContent.Headers.ContentType = contentType;
                    formData.Add(parallelCorpusContent, "parallel_corpus", "filename");
                }

                if (monolingualCorpus != null)
                {
                    var monolingualCorpusContent = new ByteArrayContent(monolingualCorpus.ReadAllBytes());
                    MediaTypeHeaderValue contentType;
                    MediaTypeHeaderValue.TryParse("text/plain", out contentType);
                    monolingualCorpusContent.Headers.ContentType = contentType;
                    formData.Add(monolingualCorpusContent, "monolingual_corpus", "filename");
                }

                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .PostAsync($"{ApiKeys.LanguageTranslatorEndpoint}{modelsUrl}")
                                .WithArgument("base_model_id", baseModelId)
                                .WithArgument("name", name)
                                .WithBodyContent(formData)
                                .As<TranslationModel>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DeleteModelResult DeleteModel(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentNullException(nameof(modelId));
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .DeleteAsync($"{ApiKeys.LanguageTranslatorEndpoint}{modelsUrl}/{modelId}")
                                .As<DeleteModelResult>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TranslationModel GetModel(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentNullException(nameof(modelId));
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .GetAsync($"{ApiKeys.LanguageTranslatorEndpoint}{modelsUrl}/{modelId}")
                                .As<TranslationModel>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TranslationModels ListModels(string source = null, string target = null, bool? defaultModels = null)
        {
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.LanguageTranslatorUsername, ApiKeys.LanguageTranslatorPassword)
                                .GetAsync($"{ApiKeys.LanguageTranslatorEndpoint}{modelsUrl}")
                                .WithArgument("source", source)
                                .WithArgument("target", target)
                                .WithArgument("default", defaultModels)
                                .As<TranslationModels>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
    }
}
