using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Tests.Repositories
{
    [TestFixture]
    public class AccountTests : BaseTestFixture
    {
        protected IAccountRepository _sut;
        protected INexosisApiKeys _keys;

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new NexosisClient();

            _sut = new AccountRepository(_keys, client);
        }

        [Test]
        public void GetAccountBalance_SessionCount_ReturnsValue()
        {
            //arrange
            
            //act
            var result = _sut.GetAccountBalance();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Result.SessionCount.Current);
        }
    }
}
