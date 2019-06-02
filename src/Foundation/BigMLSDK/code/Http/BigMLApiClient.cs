using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Http
{
    public class BigMLApiClient : IBigMLApiClient
    {
        private HttpClient _client;

        public HttpClient InnerClient
        {
            get
            {
                if (_client != null)
                    return _client;

                _client = new HttpClient();

                return _client;
            }
        }
    }
}