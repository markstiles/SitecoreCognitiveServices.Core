using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Speech;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech
{
    public class SpeechService : ISpeechService {

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ISpeechRepository SpeechRepository;
        protected readonly ILogWrapper Logger;

        public SpeechService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ISpeechRepository speechRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            SpeechRepository = speechRepository;
            Logger = logger;
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.SpeechToText",
                ApiKeys.SpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.SpeechToText(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
                    return result;
                },
                null);
        }

        public virtual Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario,
            SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.SpeechToTextAsync",
                ApiKeys.SpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.SpeechToTextAsync(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
                    return result;
                },
                null);
        }


        public virtual Stream TextToSpeech(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.TextToSpeech",
                ApiKeys.SpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.TextToSpeech(text, locale, voiceName, voiceType, outputFormat);
                    return result;
                },
                null);
        }

        public virtual Task<Stream> TextToSpeechAsync(string text, SpeechLocaleOptions locale, VoiceName voiceName,
            GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.TextToSpeechAsync",
                ApiKeys.SpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.TextToSpeechAsync(text, locale, voiceName, voiceType, outputFormat);
                    return result;
                },
                null);
        }

        public virtual bool TextToFile(string text, string filePath, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            if (File.Exists(filePath))
                return true;

            //can only send 1000 characters at a time
            //speech xml request = 178 characters
            var textLimit = 822;

            var textParts = (text.Length > textLimit)
                ? SplitToLength(text, textLimit)
                : new List<string> { text };
            
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                foreach (var t in textParts)
                {
                    using (var dataStream = TextToSpeech(t, locale, voiceName, voiceType, outputFormat))
                    {
                        dataStream.CopyTo(fileStream);
                    }
                }
                fileStream.Close();
            }

            return true;
        }

        public virtual string GetSpeechToken()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.GetSpeechToken",
                ApiKeys.SpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.GetSpeechToken();
                    return result;
                },
                null);
        }

        #region Helper Methods
        
        public List<string> SplitToLength(string input, int phraseSize)
        {
            var phraseList = new List<string>();
            if (string.IsNullOrEmpty(input) || phraseSize < 1)
                return phraseList;

            var words = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            foreach (var w in words)
            {
                if (sb.Length + w.Length > phraseSize)
                {
                    phraseList.Add(sb.ToString());
                    sb.Clear();

                    sb.Append(w);
                }
                else
                {
                    sb.Append($" {w}");
                }
            }
            if (sb.Length > 0) // make sure any remaining text is added before returning
                phraseList.Add(sb.ToString());

            return phraseList;
        }

        #endregion
    }
}