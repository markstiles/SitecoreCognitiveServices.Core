using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface IConfigurationService
    {
        List<ConfigurationDefinition> ListConfigurations();

        /// <summary>
        /// The only required fields are: name, is_primary and language
        /// </summary>
        int CreateConfigurations(List<ConfigurationDefinition> items);

        int UpdateConfigurations(List<ConfigurationDefinition> items);
        int CloneConfiguration(ConfigurationCloneRequest request);
        int RemoveConfigurations(List<string> itemIds);
    }
}