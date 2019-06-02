using System;
using System.Collections.Generic;
using System.Configuration;
using NSubstitute;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Tests
{
    public class BaseTestFixture
    {
        public INexosisApiKeys GetKeys()
        {
            INexosisApiKeys _keys = Substitute.For<INexosisApiKeys>();
                
            _keys.ApiToken.Returns(ConfigurationManager.AppSettings.Get("NexSDK.ApiToken"));
            _keys.ClientVersion.Returns(ConfigurationManager.AppSettings.Get("NexSDK.ClientVersion"));
            _keys.Endpoint.Returns(ConfigurationManager.AppSettings.Get("NexSDK.Endpoint"));

            return _keys;
        }
    }
}
