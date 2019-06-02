using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Account
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly INexosisApiKeys ApiKeys;
        protected readonly INexosisClient Client;
        
        public AccountRepository(INexosisApiKeys apiKeys, INexosisClient client)
        {
            ApiKeys = apiKeys;
            Client = client;
        }

        public async Task<AccountBalance> GetAccountBalance()
        {
            return await Client.Get<AccountBalance>($"{ApiKeys.Endpoint}data", ApiKeys.ApiToken);
        }
    }
}
