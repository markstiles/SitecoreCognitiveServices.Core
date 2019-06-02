using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Tests.Repositories
{
    [TestFixture]
    public class ContestTests : BaseTestFixture
    {
        protected IContestRepository _sut;
        protected INexosisApiKeys _keys;

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new NexosisClient();

            _sut = new ContestRepository(_keys, client);
        }

        [Test]
        public void GetContest_EmptyGuid_Returns()
        {
            //arrange
            
            //act
            var result = _sut.GetContest(Guid.Empty);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Result.Champion);
        }
    }
}
