using System;
using System.Collections.Generic;
using System.Net;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Http;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources
{
    public class SourceRepository : ISourceRepository
    {
        #region Constructor 

        protected readonly IBigMLRepositoryClient Client;

        public SourceRepository(IBigMLRepositoryClient client)
        {
            Client = client;
        }

        #endregion

        public Source CreateSource(CreateSourceRemoteApiModel model)
        {
            var result = Client.SendPost<Source>("source", model);

            return result;
        }

        public Source CreateSource(CreateSourceDataApiModel model)
        {
            var result = Client.SendPost<Source>("source", model);

            return result;
        }

        public Source CreateSource(CreateSourceSyntheticApiModel model)
        {
            var result = Client.SendPost<Source>("source", model);

            return result;
        }

        public Source GetSource(string sourceId)
        {
            var result = Client.SendGet<Source>($"source/{sourceId}");

            return result;
        }

        public List<Source> GetSources()
        {
            var result = Client.SendGet<List<Source>>("source");

            return result;
        }

        public bool DeleteSource(string sourceId)
        {
            var result = Client.SendDelete($"source/{sourceId}");

            return result == HttpStatusCode.NoContent;
        }
    }
}