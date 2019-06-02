using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Account.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface IAccountService
    {
        List<ServiceStatus> GetStatus();
        Subscription GetSubscription();
        List<Statistics> GetStatistics(string configId = null, string interval = null);
        List<SupportedFeatures> GetSupportedFeatures(string language = null);
    }
}