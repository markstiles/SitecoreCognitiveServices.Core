using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.NexSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Keys
{
    public class NexosisApiKeys : INexosisApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISCSDKSettings Settings;

        protected Item KeyItem;

        public NexosisApiKeys(
            ISitecoreDataWrapper dataWrapper,
            ISCSDKSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;

            KeyItem = DataWrapper
                .GetDatabase(Settings.MasterDatabase)
                .GetItem(Settings.NexSDKId);
        }

        #endregion Constructor 

        public virtual string ApiToken => KeyItem[Settings.NexSDK_ApiTokenFieldId];
        public virtual string ClientVersion => KeyItem[Settings.NexSDK_ClientVersionFieldId];
        public virtual string Endpoint => KeyItem[Settings.NexSDK_EndpointFieldId];
    }
}