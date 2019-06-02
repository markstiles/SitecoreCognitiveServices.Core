using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK
{
    public interface ILexalyticsApiKeys
    {
        string ApiVersion { get; }
        string AppName { get; }
        string AuthHost { get; }
        string AuthAppKey { get; }
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        string Format { get; }
        string Host { get; }
        string Password { get; }
        bool UseCompression { get; }
        string Username { get; }
        string WrapperName { get; }
    }
}