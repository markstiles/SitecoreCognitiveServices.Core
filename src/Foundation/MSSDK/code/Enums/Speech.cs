﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Enums {
    public enum Result {
        Accept,
        Reject,
    }

    public enum EnrollmentStatus {
        Enrolling,
        Training,
        Enrolled,
    }

    public enum Confidence {
        Low,
        Normal,
        High,
    }

    public enum GenderOptions
    {
        Female,
        Male
    }

    public enum AudioOutputFormatOptions
    {
        /// <summary>
        /// audio-16khz-128kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-128kbitrate-mono-mp3")]
        Audio16Khz128KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-64kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-64kbitrate-mono-mp3")]
        Audio16Khz64KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-32kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-32kbitrate-mono-mp3")]
        Audio16Khz32KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-16kbps-mono-siren request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-16kbps-mono-siren")]
        Audio16Khz16KbpsMonoSiren,

        /// <summary>
        /// audio-24khz-48kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-24khz-48kbitrate-mono-mp3")]
        Audio24Khz48KBitRateMonoMp3,

        /// <summary>
        /// audio-24khz-96kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-24khz-96kbitrate-mono-mp3")]
        Audio24Khz96KBitRateMonoMp3,

        /// <summary>
        /// audio-24khz-160kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-24khz-160kbitrate-mono-mp3")]
        Audio24Khz160KBitRateMonoMp3,

        /// <summary>
        /// raw-8khz-8bit-mono-mulaw request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-8khz-8bit-mono-mulaw")]
        Raw8Khz8BitMonoMULaw,

        /// <summary>
        /// raw-16khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-16khz-16bit-mono-pcm")]
        Raw16Khz16BitMonoPcm,

        /// <summary>
        /// raw-16khz-16bit-mono-truesilk request output audio format type.
        /// Audio compressed by SILK codec
        /// </summary>
        [EnumMember(Value = "raw-16khz-16bit-mono-truesilk")]
        Raw16Khz16BitMonoTrueSilk,

        /// <summary>
        /// raw-24khz-16bit-mono-truesilk request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-24khz-16bit-mono-truesilk")]
        Raw24Khz16BitMonoTrueSilk,

        /// <summary>
        /// raw-24khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-24khz-16bit-mono-pcm")]
        Raw24Khz16BitMonoPcm,

        /// <summary>
        /// riff-8khz-8bit-mono-mulaw request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-8khz-8bit-mono-mulaw")]
        Riff8Khz8BitMonoMULaw,

        /// <summary>
        /// riff-16khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-16khz-16bit-mono-pcm")]
        Riff16Khz16BitMonoPcm,

        /// <summary>
        /// riff-16khz-16kbps-mono-siren request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-16khz-16kbps-mono-siren")]
        Riff16Khz16KbpsMonoSiren,

        /// <summary>
        /// riff-24khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-24khz-16bit-mono-pcm")]
        Riff24khz16BitMonoPcm,

        /// <summary>
        /// ssml-16khz-16bit-mono-silk request output audio format type.
        /// It is a SSML with audio segment, with audio compressed by SILK codec
        /// </summary>
        [EnumMember(Value = "ssml-16khz-16bit-mono-silk")]
        Ssml16Khz16BitMonoSilk,

        /// <summary>
        /// ssml-16khz-16bit-mono-tts request output audio format type.
        /// It is a SSML with audio segment, and it needs tts engine to play out
        /// </summary>
        [EnumMember(Value = "ssml-16khz-16bit-mono-tts")]
        Ssml16Khz16BitMonoTts,
    }

    public enum ScenarioOptions
    {
        ulm,
        websearch
    }

    public enum SpeechLocaleOptions
    {
        [EnumMember(Value = "ar-EG")]
        arEG,
        [EnumMember(Value = "ca-ES")]
        caES,
        [EnumMember(Value = "de-DE")]
        deDE,
        [EnumMember(Value = "da-DK")]
        daDK,
        [EnumMember(Value = "es-ES")]
        esES,
        [EnumMember(Value = "es-MX")]
        esMX,
        [EnumMember(Value = "en-AU")]
        enAU,
        [EnumMember(Value = "en-CA")]
        enCA,
        [EnumMember(Value = "en-GB")]
        enGB,
        [EnumMember(Value = "en-IN")]
        enIN,
        [EnumMember(Value = "en-NZ")]
        enNZ,
        [EnumMember(Value = "en-US")]
        enUS,
        [EnumMember(Value = "fr-CA")]
        frCA,
        [EnumMember(Value = "fi-FI")]
        fiFI,
        [EnumMember(Value = "fr-FR")]
        frFR,
        [EnumMember(Value = "hi-IN")]
        hiIN,
        [EnumMember(Value = "it-IT")]
        itIT,
        [EnumMember(Value = "ja-JP")]
        jaJP,
        [EnumMember(Value = "ko-KR")]
        koKR,
        [EnumMember(Value = "nb-NO")]
        nbNO,
        [EnumMember(Value = "nl-NL")]
        nlNL,
        [EnumMember(Value = "pl-PL")]
        plPL,
        [EnumMember(Value = "pt-BR")]
        ptBR,
        [EnumMember(Value = "pt-PT")]
        ptPT,
        [EnumMember(Value = "ru-RU")]
        ruRU,
        [EnumMember(Value = "sv-SE")]
        svSE,
        [EnumMember(Value = "zh-CN")]
        zhCN,
        [EnumMember(Value = "zh-HK")]
        zhHK,
        [EnumMember(Value = "zh-TW")]
        zhTW
    };

    public enum SpeechOsOptions
    {
        [EnumMember(Value = "Windows OS")]
        WindowsOS,
        [EnumMember(Value = "Windows Phone OS")]
        WindowsPhoneOS,
        [EnumMember(Value = "XBOX")]
        XBOX,
        [EnumMember(Value = "Android")]
        Android,
        [EnumMember(Value = "iPhone OS")]
        iPhoneOS
    }

    public enum VoiceName
    {
        [EnumMember(Value = "(en-AU, Catherine)")]
        EnAuCatherine,
        [EnumMember(Value = "(en-AU, HayleyRUS)")]
        EnAuHayleyRUS,
        [EnumMember(Value = "(en-CA, Linda)")]
        EnCaLinda,
        [EnumMember(Value = "(en-CA, HeatherRUS)")]
        EnCaHeatherRUS,
        [EnumMember(Value = "(en-GB, Susan, Apollo)")]
        EnGbSusanApollo,
        [EnumMember(Value = "(en-GB, HazelRUS)")]
        EnGbHazelRUS,
        [EnumMember(Value = "(en-GB, George, Apollo)")]
        EnGbGeorgeApollo,
        [EnumMember(Value = "(en-IE, Sean)")]
        EnIeSean,
        [EnumMember(Value = "(en-IN, Heera, Apollo)")]
        EnInHeeraApollo,
        [EnumMember(Value = "(en-IN, PriyaRUS)")]
        EnInPriyaRUS,
        [EnumMember(Value = "(en-IN, Ravi, Apollo)")]
        EnInRaviApollo,
        [EnumMember(Value = "(en-US, ZiraRUS)")]
        EnUsZiraRUS,
        [EnumMember(Value = "(en-US, JessaNeural)")]
        EnUsJessaNeural,
        [EnumMember(Value = "(en-US, GuyNeural)")]
        EnUsGuyNeural,
        [EnumMember(Value = "(en-US, JessaRUS)")]
        EnUsJessaRUS,
        [EnumMember(Value = "(en-US, BenjaminRUS)")]
        EnUsBenjaminRUS,
        [EnumMember(Value = "(de-AT, Michael)")]
        DeAtMichael,
        [EnumMember(Value = "(de-CH, Karsten)")]
        DeChKarsten,
        [EnumMember(Value = "(de-DE, Hedda)")]
        DeDeHedda,
        [EnumMember(Value = "(de-DE, HeddaRUS)")]
        DeDeHeddaRUS,
        [EnumMember(Value = "(de-DE, Stefan, Apollo)")]
        DeDeStefanApollo,
        [EnumMember(Value = "(es-ES, HelenaRUS)")]
        EsEsHelenaRUS,
        [EnumMember(Value = "(es-ES, Laura, Apollo)")]
        EsEsLauraApollo,
        [EnumMember(Value = "(es-ES, Pablo, Apollo)")]
        EsEsPabloApollo,
        [EnumMember(Value = "(es-MX, HildaRUS)")]
        EsMxHildaRUS,
        [EnumMember(Value = "(es-MX, Raul, Apollo)")]
        EsMxRaulApollo,
        [EnumMember(Value = "(fr-CA, Caroline)")]
        FrCaCaroline,
        [EnumMember(Value = "(fr-CA, HarmonieRUS)")]
        FrCaHarmonieRUS,
        [EnumMember(Value = "(fr-CH, Guillaume)")]
        FrChGuillaume,
        [EnumMember(Value = "(fr-FR, Julie, Apollo)")]
        FrFrJulieApollo,
        [EnumMember(Value = "(fr-FR, HortenseRUS)")]
        FrFrHortenseRUS
    }
}
