using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Blacklist.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface IBlacklistService
    {
        List<BlacklistItem> ListBlacklist(string configId = null);
        int CreateBlacklistItem(List<string> items, string configId = null);
        int UpdateBlacklistItem(List<string> items, string configId = null);
        int DeleteBlacklistItem(List<string> items, string configId = null);
    }
}