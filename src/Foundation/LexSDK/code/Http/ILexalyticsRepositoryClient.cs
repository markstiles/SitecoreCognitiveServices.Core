using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http
{
    public interface ILexalyticsRepositoryClient
    {
        string BuildUrl(ILexalyticsApiKeys apiKeys, string path, string configId = "");
        T Get<T>(string url);
        T GetBinary<T>(string url);
        T Post<T>(string url, string data);
        int PostStatus(string url, string data);
        T Put<T>(string url, string data);
        int PutStatus(string url, string data);
        int Delete(string url, string data);
    }
}
