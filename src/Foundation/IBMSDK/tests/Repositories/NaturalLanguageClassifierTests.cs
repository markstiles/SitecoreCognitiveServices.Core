using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.IBMSDK;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Tests.Repositories
{
    [TestFixture]
    public class NaturalLanguageClassifierTests : BaseTestFixture
    {
        protected INaturalLanguageClassifierRepository _sut;
        protected IIBMWatsonApiKeys _keys;
        protected string _classifierId;

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new IBMWatsonRepositoryClient();

            _sut = new NaturalLanguageClassifierRepository(_keys, client);
            _classifierId = "some-id-generated-when-you-create-a-model";
        }
    
        [Test]
        public void Classify_ValidRequest_Returns_Temperature()
        {
            //arrange
            var text = "How hot will it be today?";

            //act
            var result = _sut.Classify(_classifierId, text);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual("temperature", result.top_class);
        }

        [Test]
        public void ClassifyCollection_ValidRequest_Returns_Temperature()
        {
            //arrange
            var collection = new List<string> {
                "How hot will it be today?",
                "Is it raining?"
            };

            //act
            var result = _sut.Classify(_classifierId, collection);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.collection.Length);
        }

        [Test]
        public void ListClassifiers_ValidRequest_Returns_Valid()
        {
            //arrange
            
            //act
            var result = _sut.ListClassifiers();

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.classifiers.Length > 0);
        }

        [Test]
        public void ClassifierInfo_ValidRequest_Returns_Valid()
        {
            //arrange

            //act
            var result = _sut.GetClassifierInfo(_classifierId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Weather Model", result.name);
        }

        [Test]
        public void CreateClassifier_ValidRequest_Returns_Valid()
        {
            //arrange
            var name = "Weather Model Sample";
            
            var trainingData = new List<string>
            {
                "How hot is it today?,temperature",
                "Is it hot outside?,temperature",
                "Will it be uncomfortably hot?,temperature",
                "Will it be sweltering?,temperature",
                "How cold is it today?,temperature",
                "Is it cold outside?,temperature",
                "Will it be uncomfortably cold?,temperature",
                "Will it be frigid?,temperature",
                "What is the expected high for today?,temperature",
                "What is the expected temperature?,temperature",
                "Will high temperatures be dangerous?,temperature",
                "Is it dangerously cold?,temperature",
                "When will the heat subside?,temperature",
                "Is it hot?,temperature",
                "Is it cold?,temperature",
                "How cold is it now?,temperature",
                "Will we have a cold day today?,temperature",
                "When will the cold subside?,temperature",
                "What highs are we expecting?,temperature",
                "What lows are we expecting?,temperature",
                "Is it warm?,temperature",
                "Is it chilly?,temperature",
                "What's the current temp in Celsius?,temperature",
                "What is the temperature in Fahrenheit?,temperature",
                "Is it windy?,conditions",
                "Will it rain today?,conditions",
                "What are the chances for rain?,conditions",
                "Will we get snow?,conditions",
                "Are we expecting sunny conditions?,conditions",
                "Is it overcast?,conditions",
                "Will it be cloudy?,conditions",
                "How much rain will fall today?,conditions",
                "How much snow are we expecting?,conditions",
                "Is it windy outside?,conditions",
                "How much snow do we expect?,conditions",
                "Is the forecast calling for snow today?,conditions",
                "Will we see some sun?,conditions",
                "When will the rain subside?,conditions",
                "Is it cloudy?,conditions",
                "Is it sunny now?,conditions",
                "Will it rain?,conditions",
                "Will we have much snow?,conditions",
                "Are the winds dangerous?,conditions",
                "What is the expected snowfall today?,conditions",
                "Will it be dry?,conditions",
                "Will it be breezy?,conditions",
                "Will it be humid?,conditions",
                "What is today's expected humidity?,conditions",
                "Will the blizzard hit us?,conditions",
                "Is it drizzling?,conditions"
            };

            StringBuilder csv = new StringBuilder();
            foreach (var line in trainingData)
            {
                csv.AppendLine(line);
            }
            
            //act
            var result = _sut.CreateClassifier(name, "en", csv.ToString());

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.name);
        }
    }
}
