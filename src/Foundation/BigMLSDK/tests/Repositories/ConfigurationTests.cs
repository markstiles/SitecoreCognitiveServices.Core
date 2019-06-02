using System.Threading.Tasks;
using NUnit.Framework;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Tests.Repositories
{
    /// <summary>
    /// Test resources related with Configurations
    /// </summary>
    [TestFixture]
    public class ConfigurationTests : BaseTestFixture
    {
        string userName = "myuser";
        string apiKey = "eee633d03c7f45c9236e4346c636391d7d659a16";

        [Test]
        public async Task CreateConfiguration()
        {
            //Client c = new Client(userName, apiKey);

            //Configuration.Arguments cfArgs = new Configuration.Arguments();
            //cfArgs.Add("name", "configuration bindings test");
            //cfArgs.Add("configurations", new JObject());
            //Configuration cf = await c.CreateConfiguration(cfArgs);

            
            //Ordered<Configuration.Filterable, Configuration.Orderable, Configuration> result
            //    = (from cfg in c.ListConfigurations()
            //       orderby cfg.Created descending
            //       select cfg);
            //Listing<Configuration> configurations = await result;
            //if (configurations.Meta.TotalCount == 0)
            //{
            //    throw new System.Exception("Creation not created or not listed");
            //}

            //cf = await c.Update<Configuration>(cf.Resource, "renamed configuration");

            //await c.Delete(cf);
        }
    }
}
