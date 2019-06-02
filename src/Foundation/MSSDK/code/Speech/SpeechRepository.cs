﻿using System;
using System.Threading.Tasks;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.Speech;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Speech
{
    public class SpeechRepository : ISpeechRepository
    {
        protected static readonly string contentType = "audio/wav; samplerate=16000";
        
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public SpeechRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repositoryClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        protected virtual string GetSpeechToTextUrl(ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest, int profanitycheck)
        {
            return $"{ApiKeys.SpeechEndpoint}recognize?version=3.0&scenarios={scenario}&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5&requestid={Guid.NewGuid()}&format=json&locale={locale}&device.os={os}&instanceid={fromDeviceId}&maxnbest={maxnbest}&result.profanitymarkup={profanitycheck}";
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            string url = GetSpeechToTextUrl(scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
            string token = RepositoryClient.SendSpeechTokenRequest(ApiKeys.SpeechTokenEndpoint, ApiKeys.Speech);
            byte[] data = RepositoryClient.GetByteArray(audioStream);

            var response = RepositoryClient.Send(ApiKeys.Speech, url, data, contentType, "POST", token, true, "speech.platform.bing.com");

            return JsonConvert.DeserializeObject<SpeechToTextResponse>(response);
        }

        /// <summary>
        /// This transcribes voice queries
        /// </summary>
        /// <param name="audioStream">Audio stream</param>
        /// <param name="scenario">The context for performing a recognition.</param>
        /// <param name="locale">Language code of the audio content in IETF RFC 5646. Case does not matter. </param>
        /// <param name="os">Operating system the client is running on. This is an open field but we encourage clients to use it consistently across devices and applications.</param>
        /// <param name="fromDeviceId">A globally unique device identifier of the device making the request.</param>
        /// <param name="maxnbest">Maximum number of results the voice application API should return. The default is 1. The maximum is 5. Example: maxnbest=3</param>
        /// <param name="profanitycheck">Scan the result text for words included in an offensive word list. If found, the word will be delimited by bad word tag. Example: result.profanity=1 (0 means off, 1 means on, default is 1.)</param>
        public virtual async Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1) {

            string url = GetSpeechToTextUrl(scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
            string token = GetSpeechToken();
            byte[] data = RepositoryClient.GetByteArray(audioStream);

            var response = await RepositoryClient.SendAsync(ApiKeys.Speech, url, data, contentType, "POST", token, true, "speech.platform.bing.com");

            return JsonConvert.DeserializeObject<SpeechToTextResponse>(response);
        }

        public virtual Stream TextToSpeech(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat) {
            var response = Task.Run(async() => await RepositoryClient.GetAudioStreamAsync(
                ApiKeys.SpeechEndpoint,
                text,
                locale,
                voiceName,
                voiceType,
                outputFormat,
                GetSpeechToken())).Result;

            return response;
        }

        public virtual async Task<Stream> TextToSpeechAsync(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            var response = await RepositoryClient.GetAudioStreamAsync(
                ApiKeys.SpeechEndpoint,
                text, 
                locale, 
                voiceName, 
                voiceType, 
                outputFormat,
                GetSpeechToken());
            
            return response;
        }

        public virtual string GetSpeechToken()
        {
            return RepositoryClient.SendSpeechTokenRequest(ApiKeys.SpeechTokenEndpoint, ApiKeys.Speech);
        }
    }
}
