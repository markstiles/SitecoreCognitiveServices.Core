using System;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Tests.Services
{
    [TestFixture]
    public class AudioServiceTests
    {
        protected ISpeechService _sut;

        [SetUp]
        public void Setup()
        {
            var keys = Substitute.For<IMicrosoftCognitiveServicesApiKeys>();
            var policy = Substitute.For<IMSSDKPolicyService>();
            var speechRepository = Substitute.For<ISpeechRepository>();
            var logger = Substitute.For<ILogWrapper>();
            _sut = new SpeechService(keys, policy, speechRepository, logger);
        }

        [Test]
        public void SplitToLength_ValidString_ReturnsValidListLength()
        {
            var testString = new StringBuilder();
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");
            testString.Append("abcde fghijkl mnopqr stuvw xyz");

            var length = 100;

            var list = _sut.SplitToLength(testString.ToString(), length);

            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void SplitToLength_OddString_ReturnsValidListLength()
        {
            var testString = new StringBuilder();
            testString.Append("I am the first man to fly to the moon and walk on it's surface. ");
            testString.Append("Originally I wanted to be able to fly experimental jets for the Navy but when I found out about the space program I jumped at the opportunity. ");
            testString.Append("I don't think anyone thought I would make it. I certainly didn't have an aptitude for stress or extreme physical duress but the thought of moving that fast made me forget about all my fears. ");
            testString.Append("Now I can't see how I'd live without it. From morning until night I am always trying to figure out how much more flight time I can get into. ");
            testString.Append("No one knows as much about the planes we fly besides the mechanics and that's fine by me. I'm just happy I can fly like a bird. ");
        
            var stringLength = testString.Length;
            var length = 13;
            var dividedValue = (float)stringLength / length;
            var expectedCount = (int)Math.Ceiling(dividedValue);
            
            var list = _sut.SplitToLength(testString.ToString(), length);

            Assert.IsNotNull(list);
            Assert.GreaterOrEqual(list.Count, expectedCount);
        }

        [Test]
        public void SplitToLength_NullString_ReturnsEmptyList()
        {
            var length = 100;

            var list = _sut.SplitToLength(null, length);

            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void SplitToLength_NegativeLength_ReturnsEmptyList()
        {
            var testString = "abcde fghijkl mnopqr stuvw xyz";

            var length = -10;

            var list = _sut.SplitToLength(testString, length);

            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }
    }
}
