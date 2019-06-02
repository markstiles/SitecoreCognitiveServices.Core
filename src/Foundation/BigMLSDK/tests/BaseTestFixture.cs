using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Tests
{
    public class BaseTestFixture
    {
        public IBigMLApiKeys GetKeys()
        {
            IBigMLApiKeys _keys;

            _keys = Substitute.For<IBigMLApiKeys>();

            
            return _keys;
        }
    }
}
