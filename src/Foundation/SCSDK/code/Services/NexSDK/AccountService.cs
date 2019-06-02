using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class AccountService : IAccountService
    {
        protected readonly IAccountRepository AccountRepository;
        protected readonly ILogWrapper Logger;
        
        public AccountService(
            IAccountRepository accountRepository,
            ILogWrapper logger)
        {
            AccountRepository = accountRepository;
            Logger = logger;
        }

        public virtual Task<AccountBalance> GetAccountBalance()
        {
            try
            {
                var result = AccountRepository.GetAccountBalance();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetAccountBalance failed", this, ex);
            }

            return null;
        }
    }
}