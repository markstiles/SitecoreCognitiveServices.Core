using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer
{
    public class ToneAnalyzerRepository : IToneAnalyzerRepository
    {
        #region Constructor

        protected static readonly string toneUrl = "tone";
        protected static readonly string toneChatUrl = "tone_chat";
        protected static readonly string versionDate = "2017-09-21";
        
        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public ToneAnalyzerRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public ToneAnalysis Tone(ToneInput toneInput, string contentType, bool? sentences = null, List<string> tones = null, string contentLanguage = null, string acceptLanguage = null)
        {
            if (toneInput == null)
                throw new ArgumentNullException(nameof(toneInput));
            if (string.IsNullOrEmpty(contentType))
                throw new ArgumentNullException(nameof(contentType));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null.");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.ToneAnalyzerUsername, ApiKeys.ToneAnalyzerPassword)
                                .PostAsync($"{ApiKeys.ToneAnalyzerEndpoint}{toneUrl}")
                                .WithArgument("version", versionDate)
                                .WithHeader("Content-Type", contentType)
                                .WithHeader("Content-Language", contentLanguage)
                                .WithHeader("Accept-Language", acceptLanguage)
                                .WithArgument("sentences", sentences)
                                .WithArgument("tones", tones != null && tones.Count > 0 ? string.Join(",", tones.ToArray()) : null)
                                .WithBody<ToneInput>(toneInput)
                                .As<ToneAnalysis>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public UtteranceAnalyses ToneChat(ToneChatInput utterances, string acceptLanguage = null)
        {
            if (utterances == null)
                throw new ArgumentNullException(nameof(utterances));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null.");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.ToneAnalyzerUsername, ApiKeys.ToneAnalyzerPassword)
                                .PostAsync($"{ApiKeys.ToneAnalyzerEndpoint}{toneChatUrl}")
                                .WithArgument("version", versionDate)
                                .WithHeader("Accept-Language", acceptLanguage)
                                .WithBody<ToneChatInput>(utterances)
                                .As<UtteranceAnalyses>()
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
