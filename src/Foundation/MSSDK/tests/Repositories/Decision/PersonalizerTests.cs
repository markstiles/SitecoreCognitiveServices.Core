using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer.Action;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Tests.Repositories.Decision
{
    public class PersonalizerTests : BaseTestFixture
    {
        protected PersonalizerRepository _sut;
        protected IMicrosoftCognitiveServicesApiKeys _keys;
        
        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new MicrosoftCognitiveServicesRepositoryClient();
            _sut = new PersonalizerRepository(_keys, client);



        }

        [Test]
        public void RankTest()
        {
            var request = new RankRequest
            {
                contextFeatures = new ContextFeature[]
                {
                    new ContextFeature { timeOfDay = "Morning" }
                },
                actions = new Action[]
                {
                    new Action {
                        id = "NewsArticle",
                        features = new Feature[]
                        {
                            new Feature { type = "News" }
                        }
                    },
                    new Action {
                        id = "SportsArticle",
                        features = new Feature[]
                        {
                            new Feature { type = "Sports" }
                        }
                    },
                    new Action {
                        id = "EntertainmentArticle",
                        features = new Feature[]
                        {
                            new Feature { type = "Entertainment" }
                        }
                    }
                },
                excludedActions = new string[] { "SportsArticle" },
                eventId = "75269AD0-BFEE-4598-8196-C57383D38E10",
                deferActivation = false
            };

            var result = _sut.Rank(request);

            Assert.Greater(result.ranking.Count(), 0);
        }
    }
}
