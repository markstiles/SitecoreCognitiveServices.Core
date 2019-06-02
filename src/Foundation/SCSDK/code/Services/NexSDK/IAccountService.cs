using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public interface IAccountService
    {
        Task<AccountBalance> GetAccountBalance();
    }
}