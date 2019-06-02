using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Http
{
    public interface IBigMLApiClient
    {
        HttpClient InnerClient { get; }
    }
}