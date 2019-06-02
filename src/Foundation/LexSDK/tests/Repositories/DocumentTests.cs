using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration;
using SitecoreCognitiveServices.Foundation.LexSDK.Document;
using SitecoreCognitiveServices.Foundation.LexSDK.Document.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Tests.Repositories
{

    [TestFixture]
    public class DocumentTests : BaseTestFixture
    {
        protected DocumentRepository _sut;
        protected ILexalyticsApiKeys _keys;
        
        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new LexalyticsRepositoryClient(_keys);

            _sut = new DocumentRepository(_keys, client);
        }

        #region Analzye Document
        
        [Test]
        public void AnalyzeDocument()
        {
            //arrange
            var doc = new DocumentRequest
            {
                id= "2d2e7341-a3c2-4fb4-9d3a-779e8b0a5eff",
                //2049
                text = "The drive for ever-greater institutional efficiency places an enormous burden on those involved in developing regulatory submissions. Jim Reilly suggests how this process can be engineered to function more effectively and meet the organisation's demands. Jim Reilly is a consultant, software implementation, for development partnering organisation Octagon Research Solutions Inc. He is based at the company's headquarters in Wayne, Pennsylvania, in the US. Email: jreilly@octagonresearch.com The pharmaceutical industry has been cast into the storm of the digital age in recent years. It is possible to walk around any pharma company and hear whispers of gene sequencing, predictive animal modelling, electronic data capture, XML authoring or the electronic common technical document. All of these are relatively new developments and form part of a trend towards the ever-elusive concept of institutional efficiency. It is clear that everyone wishes to do things better, smarter and faster. Those of us involved on the regulatory front have not turned a blind eye to this drive towards efficiency. Whether it be adverse event reporting (AERS in the US or EUDRAVigilance in the European Union), clinical trial applications/investigational new drug applications or marketing applications, we are confronted with a host of electronic means to submit data. The recent trend has been towards submitting data simultaneously across the globe. After all, what more efficient way is there to submit similar material than at the same time? Thanks to the advent of the common technical document, authors can pen the story of the safety, efficacy and quality of their therapeutic in a standard way. Gone are the days of writing similar content in alternative formats, or retrofitting information for a different purpose. In the drive towards commonality of review content amongst global regulatory agencies, regulatory groups in pharma have begun focusing their efficiency efforts towards simultaneous global submissions. For the first time, a marketing author"
            };

            //act
            var responseId = _sut.SendDocument(doc);
            
            var result = new DocumentAnalysis {status = ""};
            while (result.status.ToLower() != "processed")
            {
                System.Threading.Thread.Sleep(5000);
                result = _sut.GetDocument(doc.id);
            }
            
            //assert
            Assert.IsNotNull(result.summary.Length > 0);
        }

        #endregion
    }
}
