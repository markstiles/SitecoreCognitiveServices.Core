using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.NexSDK
{
    public interface INexosisApiKeys
    {
        /// <summary>
        /// The default URL of the api endpoint.
        /// </summary>
        string Endpoint { get; }

        /// <summary>
        /// The client id and version sent as the User-Agent header
        /// </summary>
        string ClientVersion { get; }

        /// <summary>
        /// The currently configured api key used by this instance of the client.
        /// </summary>
        string ApiToken { get; }
    }
}
