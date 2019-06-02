using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class ExecutionListing : Query<Execution.Filterable, Execution.Orderable, Execution>
    {
        public ExecutionListing(Func<string, Task<Listing<Execution>>> client): base(client)
        {
        }
    }
}