using System;
using System.Collections.Generic;
using System.Net;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Http;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Projects.Models;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        #region Constructor 

        protected readonly IBigMLRepositoryClient Client;

        public ProjectRepository(IBigMLRepositoryClient client)
        {
            Client = client;
        }

        #endregion

        public Project CreateProject(object model)
        {
            var result = Client.SendPost<Project>("project", model);

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