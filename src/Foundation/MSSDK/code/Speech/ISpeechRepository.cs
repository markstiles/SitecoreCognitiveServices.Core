using System;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.Speech;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Speech {
    public interface ISpeechRepository {
        SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Stream TextToSpeech(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        Task<Stream> TextToSpeechAsync(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        string GetSpeechToken();
    }
}