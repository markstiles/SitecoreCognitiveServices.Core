using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.BigMLSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Keys
{
    public class BigMLApiKeys : IBigMLApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISCSDKSettings Settings;

        protected Item KeyItem;

        public BigMLApiKeys(
            ISitecoreDataWrapper dataWrapper,
            ISCSDKSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;

            KeyItem = DataWrapper
                .GetDatabase(Settings.MasterDatabase)
                .GetItem(Settings.IBMSDKId);
        }

        #endregion Constructor 

        public string ApiKey { get; set; }
        public string Username { get; set; }
        public string Endpoint { get; set; }
    }
}