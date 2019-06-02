using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class ConfigurationService : IConfigurationService
    {
        protected IConfigurationRepository ConfigurationRepository;
        protected ILogWrapper Logger;

        public ConfigurationService(
            IConfigurationRepository configurationRepository,
            ILogWrapper logger)
        {
            ConfigurationRepository = configurationRepository;
            Logger = logger;
        }
        
        public virtual List<ConfigurationDefinition> ListConfigurations()
        {
            try
            {
                var result = ConfigurationRepository.ListConfigurations();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ConfigurationRepository.ListConfigurations failed", this, ex);
            }

            return null;
        }


        /// <summary>
        /// The only required fields are: name, is_primary and language
        /// </summary>
        public virtual int CreateConfigurations(List<ConfigurationDefinition> items)
        {
            try
            {
                var result = ConfigurationRepository.CreateConfigurations(items);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ConfigurationRepository.CreateConfigurations failed", this, ex);
            }

            return -1;
        }


        public virtual int UpdateConfigurations(List<ConfigurationDefinition> items)
        {
            try
            {
                var result = ConfigurationRepository.UpdateConfigurations(items);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ConfigurationRepository.UpdateConfigurations failed", this, ex);
            }

            return -1;
        }

        public virtual int CloneConfiguration(ConfigurationCloneRequest request)
        {
            try
            {
                var result = ConfigurationRepository.CloneConfiguration(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ConfigurationRepository.CloneConfiguration failed", this, ex);
            }

            return -1;
        }

        public virtual int RemoveConfigurations(List<string> itemIds)
        {
            try
            {
                var result = ConfigurationRepository.RemoveConfigurations(itemIds);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ConfigurationRepository.RemoveConfigurations failed", this, ex);
            }

            return -1;
        }
    }
}