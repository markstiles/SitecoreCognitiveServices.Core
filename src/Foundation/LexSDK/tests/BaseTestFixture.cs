using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using SitecoreCognitiveServices.Foundation.LexSDK;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Tests
{
    public class BaseTestFixture
    {
        public ILexalyticsApiKeys GetKeys()
        {
            ILexalyticsApiKeys _keys = Substitute.For<ILexalyticsApiKeys>();

            _keys.ApiVersion.Returns(ConfigurationManager.AppSettings.Get("LexSDK.ApiVersion"));
            _keys.AppName.Returns(ConfigurationManager.AppSettings.Get("LexSDK.AppName"));
            _keys.AuthAppKey.Returns(ConfigurationManager.AppSettings.Get("LexSDK.AuthAppKey"));
            _keys.AuthHost.Returns(ConfigurationManager.AppSettings.Get("LexSDK.AuthHost"));
            _keys.ConsumerKey.Returns(ConfigurationManager.AppSettings.Get("LexSDK.ConsumerKey"));
            _keys.ConsumerSecret.Returns(ConfigurationManager.AppSettings.Get("LexSDK.ConsumerSecret"));
            _keys.Format.Returns(ConfigurationManager.AppSettings.Get("LexSDK.Format"));
            _keys.Host.Returns(ConfigurationManager.AppSettings.Get("LexSDK.Host"));
            _keys.Password.Returns(ConfigurationManager.AppSettings.Get("LexSDK.Password"));
            _keys.UseCompression.Returns(Boolean.Parse(ConfigurationManager.AppSettings.Get("LexSDK.UseCompression")));
            _keys.Username.Returns(ConfigurationManager.AppSettings.Get("LexSDK.Username"));
            _keys.WrapperName.Returns(ConfigurationManager.AppSettings.Get("LexSDK.WrapperName"));

            return _keys;
        }
    }
}
