using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Tests.Repositories
{

    [TestFixture]
    public class ConfigurationTests : BaseTestFixture
    {
        protected ConfigurationRepository _sut;
        protected ILexalyticsApiKeys _keys;
        
        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new LexalyticsRepositoryClient(_keys);

            _sut = new ConfigurationRepository(_keys, client);
        }

        #region List Configurations
        
        [Test]
        public void ListConfigurations()
        {
            //arrange

            //act
            var result = _sut.ListConfigurations();

            //assert
            Assert.IsNotNull(result);
        }

        #endregion
    }
}
