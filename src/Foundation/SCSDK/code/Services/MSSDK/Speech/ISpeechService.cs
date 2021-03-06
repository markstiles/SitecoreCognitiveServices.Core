﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.Speech;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech {
    public interface ISpeechService {
        SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, SpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Stream TextToSpeech(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        Task<Stream> TextToSpeechAsync(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        bool TextToFile(string text, string filePath, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        string GetSpeechToken();
        List<string> SplitToLength(string input, int phraseSize);
    }
}