using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Tests.Repositories
{
    [TestFixture]
    public class ToneAnalyzerTests : BaseTestFixture
    {
        protected IToneAnalyzerRepository _sut;
        protected IIBMWatsonApiKeys _keys;

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new IBMWatsonRepositoryClient();

            _sut = new ToneAnalyzerRepository(_keys, client);
        }

        [Test]
        public void Classify_ValidRequest_Returns_Temperature()
        {
            //arrange
            var text = "How hot will it be today?";

            ////act
            //var result = _sut.Classify(_keys.NaturalLanguageClassifier, text);

            ////assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("temperature", result.top_class);
        }
    }
}
