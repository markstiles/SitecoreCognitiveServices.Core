using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class LogisticRegressionListing : Query<LogisticRegression.Filterable, LogisticRegression.Orderable, LogisticRegression>
    {
        public LogisticRegressionListing(Func<string, Task<Listing<LogisticRegression>>> client)
            : base(client)
        {
        }
    }
}
