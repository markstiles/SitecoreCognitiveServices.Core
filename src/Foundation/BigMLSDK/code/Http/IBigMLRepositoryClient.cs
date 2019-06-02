using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Http
{
    public interface IBigMLRepositoryClient
    {
        T SendGet<T>(string apiPath);
        T SendPost<T>(string apiPath, object parameter);
        T SendPut<T>(string apiPath, object parameter);
        HttpStatusCode SendDelete(string apiPath);
    }
}