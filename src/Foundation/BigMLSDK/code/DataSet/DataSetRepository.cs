using SitecoreCognitiveServices.Foundation.BigMLSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.DataSet
{
    public class DataSetRepository : IDataSetRepository
    {
        #region Constructor 

        protected readonly IBigMLRepositoryClient Client;

        public DataSetRepository(IBigMLRepositoryClient client)
        {
            Client = client;
        }

        #endregion

        //public Project CreateProject(object model)
        //{
        //    var result = Client.SendPost<Project>("project", model);

        //    return result;
        //}

    }
}