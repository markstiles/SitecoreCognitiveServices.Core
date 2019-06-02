using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Account;
using SitecoreCognitiveServices.Foundation.LexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class AccountService : IAccountService
    {
        protected IAccountRepository AccountRepository;
        protected ILogWrapper Logger;

        public AccountService(
            IAccountRepository accountRepository,
            ILogWrapper logger)
        {
            AccountRepository = accountRepository;
            Logger = logger;
        }
        
        public virtual List<ServiceStatus> GetStatus()
        {
            try
            {
                var result = AccountRepository.GetStatus();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetStatus failed", this, ex);
            }

            return null;
        }

        public virtual Subscription GetSubscription()
        {
            try
            {
                var result = AccountRepository.GetSubscription();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetSubscription failed", this, ex);
            }

            return null;
        }

        public virtual List<Statistics> GetStatistics(string configId = null, string interval = null)
        {
            try
            {
                var result = AccountRepository.GetStatistics(configId, interval);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetStatistics failed", this, ex);
            }

            return null;
        }

        public virtual List<SupportedFeatures> GetSupportedFeatures(string language = null)
        {
            try
            {
                var result = AccountRepository.GetSupportedFeatures(language);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetDocument failed", this, ex);
            }

            return null;
        }
    }
}