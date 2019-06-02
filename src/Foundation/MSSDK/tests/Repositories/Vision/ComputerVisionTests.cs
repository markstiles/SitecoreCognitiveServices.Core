using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Tests.Repositories.Vision
{

    [TestFixture]
    public class ComputerVisionTests : BaseTestFixture
    {
        protected ComputerComputerVisionRepository _sut;
        protected IMicrosoftCognitiveServicesApiKeys _keys;
        
        protected IEnumerable<VisualFeature> _visualFeatures = new List<VisualFeature>
        {
            VisualFeature.Adult,
            VisualFeature.Categories,
            VisualFeature.Color,
            VisualFeature.Description,
            VisualFeature.Faces,
            VisualFeature.ImageType,
            VisualFeature.Tags
        };

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new MicrosoftCognitiveServicesRepositoryClient();

            _sut = new ComputerComputerVisionRepository(_keys, client);
        }

        #region Analyze Image
        
        [Test]
        public void AnalyzeImage()
        {
            //arrange

            //act
            var result = _sut.AnalyzeImage("", _visualFeatures);

            ////assert
            //Assert.IsNotNull(result
        }

        #endregion

        #region Analyze Image In Domain



        #endregion

        #region List Domain Specific Models



        #endregion

        #region Describe



        #endregion

        #region Get Thumbnail



        #endregion

        #region Recognize Text



        #endregion

        #region Get Tags



        #endregion

        #region Get Handwritten Text Operation Result



        #endregion

        #region Recognize Handwritten Text



        #endregion
    }
}
