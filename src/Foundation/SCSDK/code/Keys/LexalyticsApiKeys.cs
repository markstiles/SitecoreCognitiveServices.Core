using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.LexSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Keys
{
    public class LexalyticsApiKeys : ILexalyticsApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISCSDKSettings Settings;

        protected Item KeyItem;

        public LexalyticsApiKeys(
            ISitecoreDataWrapper dataWrapper,
            ISCSDKSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;

            KeyItem = DataWrapper
                .GetDatabase(Settings.MasterDatabase)
                .GetItem(Settings.LexSDKId);
        }

        #endregion Constructor 
        
        public virtual string ApiVersion => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string AppName => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string AuthHost => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string AuthAppKey => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string ConsumerKey => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string ConsumerSecret => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string Format => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string Host => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string Password => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual bool UseCompression => ((CheckboxField)KeyItem.Fields[Settings.LexSDK_ApiVersionFieldId]).Checked;
        public virtual string Username => KeyItem[Settings.LexSDK_ApiVersionFieldId];
        public virtual string WrapperName => KeyItem[Settings.LexSDK_ApiVersionFieldId];
    }
}