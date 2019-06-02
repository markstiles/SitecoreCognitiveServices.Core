using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Blacklist;
using SitecoreCognitiveServices.Foundation.LexSDK.Blacklist.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class BlacklistService : IBlacklistService
    {
        protected IBlacklistRepository BlacklistRepository;
        protected ILogWrapper Logger;

        public BlacklistService(
            IBlacklistRepository blacklistRepository,
            ILogWrapper logger)
        {
            BlacklistRepository = blacklistRepository;
            Logger = logger;
        }

        public virtual List<BlacklistItem> ListBlacklist(string configId = null)
        {
            try
            {
                var result = BlacklistRepository.ListBlacklist(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("BlacklistService.ListBlacklist failed", this, ex);
            }

            return null;
        }

        public virtual int CreateBlacklistItem(List<string> items, string configId = null)
        {
            try
            {
                var result = BlacklistRepository.CreateBlacklistItem(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("BlacklistService.CreateBlacklistItem failed", this, ex);
            }

            return -1;
        }

        public virtual int UpdateBlacklistItem(List<string> items, string configId = null)
        {
            try
            {
                var result = BlacklistRepository.UpdateBlacklistItem(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("BlacklistService.UpdateBlacklistItem failed", this, ex);
            }

            return -1;
        }

        public virtual int DeleteBlacklistItem(List<string> items, string configId = null)
        {
            try
            {
                var result = BlacklistRepository.DeleteBlacklistItem(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("BlacklistService.DeleteBlacklistItem failed", this, ex);
            }

            return -1;
        }
    }
}