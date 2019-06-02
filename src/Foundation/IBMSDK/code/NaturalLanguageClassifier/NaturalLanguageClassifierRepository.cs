using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier
{
    public class NaturalLanguageClassifierRepository : INaturalLanguageClassifierRepository
    {
        #region Constructor

        protected static readonly string classifyUrl = "/classify";
        protected static readonly string classifyCollectionUrl = "/classify_collection";
        
        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public NaturalLanguageClassifierRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion

        #region Create Classifier

        /// <summary>
        /// POST /v1/classifiers
        /// The training data must have at least five records (rows) and no more than 20,000 records.
        /// The maximum total length of a text value is 1024 characters.
        /// </summary>
        /// <param name="training_data">(Required) Training data. Each text value must have at least one class. The data can include up to 15,000 records. For details, see https://www.ibm.com/watson/developercloud/doc/natural-language-classifier/using-your-data.html</param>
        /// <param name="training_metadata">The metadata identifies the required language of the data and an optional name to identify the classifier. Specify the language with the 2-letter primary language code as assigned in ISO standard 639. Supported languages are English (en), Arabic (ar), French (fr), German, (de), Italian (it), Japanese (ja), Korean (ko), Brazilian Portuguese (pt), and Spanish (es).</param>
        /// <returns></returns>
        public virtual Classifier CreateClassifier(string classifier_name, string training_data_language, string training_data)
        {   
            var form = new MultipartFormDataContent();

            TrainingMetadataEntity trainingMetadata = new TrainingMetadataEntity { name = classifier_name, language = training_data_language };
           
            var metadataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(trainingMetadata)));
            metadataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            form.Add(metadataContent, "training_metadata", "filename");
            
            var contentBytes = Encoding.ASCII.GetBytes(training_data);
            var trainingDataContent = new ByteArrayContent(contentBytes, 0, contentBytes.Length);
            trainingDataContent.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            form.Add(trainingDataContent, "training_data", "filename");
            
            var response = RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .PostAsync(ApiKeys.NaturalLanguageClassifierEndpoint)
                .WithBodyContent(form)
                .As<Classifier>()
                .Result;
            
            return response;
        }
        
        #endregion

        #region List Classifiers

        /// <summary>
        /// GET /v1/classifiers
        /// </summary>
        /// <param name="classifiers">An array [ClassifierInfoPayload] of classifiers that are available for the service instance. Returns an empty array if no classifiers are available.</param>
        /// <returns></returns>
        public virtual ListClassifierResponse ListClassifiers()
        {
            var response = RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .GetAsync(ApiKeys.NaturalLanguageClassifierEndpoint)
                .As<ListClassifierResponse>()
                .Result;

            return response;
        }

        #endregion

        #region Get Classifier Info

        /// <summary>
        /// GET /v1/classifiers/{classifier_id}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to query</param>
        /// <returns></returns>
        public virtual Classifier GetClassifierInfo(string classifier_id)
        {
            var response = RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .GetAsync($"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}")
                .As<Classifier>()
                .Result;

            return response;
        }

        #endregion

        #region Delete Classifier

        /// <summary>
        /// DELETE /v1/classifiers/{classifier_id}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to delete</param>
        /// <returns></returns>
        public virtual void DeleteClassifier(string classifier_id)
        {
            RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .DeleteAsync($"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}");
        }

        #endregion

        #region Classify
        
        /// <summary>
        /// GET /v1/classifiers/{classifier_id}/classify
        /// POST /v1/classifiers/{classifier_id}/classify : {\"text\":\"How hot will it be today?\"}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to use</param>
        /// <param name="text">(Required) Phrase to classify</param>
        /// <returns></returns>
        public virtual ClassifyResponse Classify(string classifier_id, string text)
        {
            var response = RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .PostAsync($"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}{classifyUrl}")
                .WithBody(new TextEntity { text = $"\"{text}\"" })
                .As<ClassifyResponse>()
                .Result;
            
            return response;
        }

        /// <summary>
        /// The maximum length of the text phrase is 1024 characters. 
        /// You can submit up to 30 text phrases in a request.
        /// </summary>
        /// <param name="classifier_id"></param>
        /// <param name="textList"></param>
        /// <returns></returns>
        public virtual ClassifyCollectionResponse Classify(string classifier_id, List<string> textList)
        {
            TextEntityCollection collection = new TextEntityCollection
            {
                collection = textList.Select(t => new TextEntity { text = t }).ToList()
            };

            var response = RepositoryClient
                .WithAuthentication(ApiKeys.NaturalLanguageClassifierUsername, ApiKeys.NaturalLanguageClassifierPassword)
                .PostAsync($"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}{classifyCollectionUrl}")
                .WithBody(collection)
                .As<ClassifyCollectionResponse>()
                .Result;

            return response;
        }

        #endregion
    }
}