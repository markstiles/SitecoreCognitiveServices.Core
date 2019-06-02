using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Account
{
    /// <summary>
    /// The primary interface to the Nexosis API.
    /// </summary>
    public interface IAccountRepository
    {
        Task<AccountBalance> GetAccountBalance();
    }
}
