using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class ForecastListing : Query<Forecast.Filterable, Forecast.Orderable, Forecast>
    {
        public ForecastListing(Func<string, Task<Listing<Forecast>>> client)
            : base(client)
        {
        }
    }
}