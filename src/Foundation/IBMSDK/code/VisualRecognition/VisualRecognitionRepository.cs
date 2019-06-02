using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition
{
    public class VisualRecognitionRepository : IVisualRecognitionRepository
    {
        protected static readonly string classifyUrl = "/classify";
        protected static readonly string detectFacesUrl = "/detect_faces";
        protected static readonly string classifiersUrl = "/classifiers";
        protected static readonly string classifierUrl = "/classifiers/{0}";
        protected static readonly string versionDate = "2016-05-20";
        
        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public VisualRecognitionRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #region Classify

        public virtual ClassifyTopLevelMultiple Classify(string url, string[] classifierIDs = null, string[] owners = null, float threshold = 0, string acceptLanguage = "en")
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("'url' is required for 'Classify()'");
            
            if (owners != null && owners.Select(a => a.ToLower()).Any(b => !b.Equals("ibm") && !b.Equals("me")))
                throw new ArgumentOutOfRangeException("Owners can only be a combination of IBM and me ('IBM', 'me', 'IBM,me').");
            
            try
            {
                var result = RepositoryClient.GetAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifyUrl}")
                    .WithHeader("Accept-Language", "en")
                    .WithArgument("url", url)
                    .WithArgument("classifier_ids", classifierIDs != null ? string.Join(",", classifierIDs) : "default")
                    .WithArgument("owners", owners != null ? string.Join(",", owners) : "IBM,me")
                    .WithArgument("threshold", threshold)
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .As<ClassifyTopLevelMultiple>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual ClassifyPost Classify(byte[] imageData = null, string imageDataName = null, string imageDataMimeType = null, string[] urls = null, string[] classifierIDs = null, string[] owners = null, float threshold = 0, string acceptLanguage = "en")
        {
            if (imageData == null && (urls == null || urls.Length < 1))
                throw new ArgumentNullException($"{nameof(imageData)} or 'urls' are required for 'Classify()'");

            if (imageData != null && (string.IsNullOrEmpty(imageDataName) || string.IsNullOrEmpty(imageDataMimeType)))
                throw new ArgumentException($"{nameof(imageDataName)} and {nameof(imageDataMimeType)} are required for 'Classify()'");
           
            if (owners != null && owners.Select(a => a.ToLower()).Any(b => !b.Equals("ibm") && !b.Equals("me")))
                throw new ArgumentOutOfRangeException("Owners can only be a combination of IBM and me ('IBM', 'me', 'IBM,me').");

            ClassifyParameters parametersObject = new ClassifyParameters
            {
                classifier_ids = classifierIDs ?? (new string[] { "default" }),
                urls = urls ?? new string[0],
                owners = owners ?? new string[0],
                threshold = threshold
            };

            string parameters = JsonConvert.SerializeObject(parametersObject);

            var formData = new MultipartFormDataContent();

            if (imageData != null)
            {
                var imageContent = new ByteArrayContent(imageData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(imageDataMimeType);
                formData.Add(imageContent, "images_file", imageDataName);
            }

            if (!string.IsNullOrEmpty(parameters))
            {
                var parametersContent = new StringContent(parameters, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                parametersContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                formData.Add(parametersContent, "parameters");
            }
            
            try
            {
                var result = RepositoryClient.PostAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifyUrl}")
                    .WithHeader("Accept-Language", "en")
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithBodyContent(formData)
                    .As<ClassifyPost>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        #endregion

        #region Detect Faces

        public virtual Faces DetectFaces(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("'url' is required for 'DetectFaces()'");

            try
            {
                var result = RepositoryClient.GetAsync($"{ApiKeys.VisualRecognitionEndpoint}{detectFacesUrl}")
                    .WithArgument("url", url)
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .As<Faces>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual Faces DetectFaces(byte[] imageData = null, string imageDataName = null, string imageDataMimeType = null, string[] urls = null)
        {
            if (imageData == null && (urls == null || urls.Length < 1))
                throw new ArgumentNullException($"{nameof(imageData)} or 'urls' are required for 'DetectFaces()'");

            if (imageData != null && (string.IsNullOrEmpty(imageDataName) || string.IsNullOrEmpty(imageDataMimeType)))
                throw new ArgumentNullException($"{nameof(imageDataName)} and {nameof(imageDataMimeType)} are required for 'DetectFaces()'");
            
            var formData = new MultipartFormDataContent();

            if (urls != null && urls.Length > 0)
            {
                DetectFacesParameters parametersObject = new DetectFacesParameters
                {
                    urls = urls
                };
                
                var parametersContent = new StringContent(JsonConvert.SerializeObject(parametersObject), Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                parametersContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                formData.Add(parametersContent);
            }
            
            if (imageData != null)
            {
                var imageContent = new ByteArrayContent(imageData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(imageDataMimeType);
                formData.Add(imageContent, imageDataName, imageDataName);
            }
            
            try
            {
                var result = RepositoryClient.PostAsync($"{ApiKeys.VisualRecognitionEndpoint}{detectFacesUrl}")
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithBodyContent(formData)
                    .As<Faces>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        #endregion

        #region Classifiers

        public virtual GetClassifiersBriefResponse GetClassifiersBrief()
        {
            try
            {
                var result = RepositoryClient.GetAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifiersUrl}")
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithArgument("version", versionDate)
                    .WithArgument("verbose", false)
                    .As<GetClassifiersBriefResponse>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual GetClassifiersVerboseResponse GetClassifiersVerbose()
        {
            try
            {
                var result = RepositoryClient.GetAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifiersUrl}")
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithArgument("version", versionDate)
                    .WithArgument("verbose", true)
                    .WithFormatter(new MediaTypeHeaderValue("application/octet-stream"))
                    .As<GetClassifiersVerboseResponse>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual GetClassifierVerboseResponse CreateClassifier(string classifierName, Dictionary<string, byte[]> positiveExamplesData, byte[] negativeExamplesData = null)
        {
            if (string.IsNullOrEmpty(classifierName))
                throw new ArgumentNullException(nameof(classifierName));

            if (positiveExamplesData == null)
                throw new ArgumentNullException(nameof(positiveExamplesData));

            if (positiveExamplesData.Count < 2 && negativeExamplesData == null)
                throw new ArgumentNullException("Training a Visual Recognition classifier requires at least two positive example files or one positive example and negative example file.");
            
            var formData = new MultipartFormDataContent();

            foreach (var kvp in positiveExamplesData)
            {
                var positiveExampleDataContent = new ByteArrayContent(kvp.Value);
                positiveExampleDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
                formData.Add(positiveExampleDataContent, $"{kvp.Key}_positive_examples", $"{kvp.Key}_positive_examples.zip");
            }

            if (negativeExamplesData != null)
            {
                var negativeExamplesDataContent = new ByteArrayContent(negativeExamplesData);
                negativeExamplesDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
                formData.Add(negativeExamplesDataContent, "negative_examples", "negative_examples.zip");
            }

            var nameDataContent = new StringContent(classifierName, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
            nameDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            formData.Add(nameDataContent, "name");

            try
            {
                var result = RepositoryClient.PostAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifiersUrl}")
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithBodyContent(formData)
                    .WithFormatter(new MediaTypeHeaderValue("application/octet-stream"))
                    .As<GetClassifierVerboseResponse>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual void DeleteClassifier(string classifierId)
        {
            if (string.IsNullOrEmpty(classifierId))
                throw new ArgumentNullException(nameof(classifierId));

            try
            {
                RepositoryClient.DeleteAsync($"{ApiKeys.VisualRecognitionEndpoint}{classifiersUrl}/{classifierId}")
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithArgument("version", versionDate)
                    .WithHeader("accept", HttpMediaType.TEXT_HTML)
                    .WithFormatter(new MediaTypeHeaderValue("application/octet-stream"));
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual GetClassifierVerboseResponse GetClassifier(string classifierId)
        {
            if (string.IsNullOrEmpty(classifierId))
                throw new ArgumentNullException(nameof(classifierId));
            
            try
            {
                var result = RepositoryClient.GetAsync($"{ApiKeys.VisualRecognitionEndpoint}{string.Format(classifierUrl, classifierId)}")
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithArgument("version", versionDate)
                    .As<GetClassifierVerboseResponse>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public virtual GetClassifierVerboseResponse UpdateClassifier(string classifierId, Dictionary<string, byte[]> positiveExamplesData = null, byte[] negativeExamplesData = null)
        {
            if (string.IsNullOrEmpty(classifierId))
                throw new ArgumentNullException(nameof(classifierId));

            if (positiveExamplesData == null && negativeExamplesData == null)
                throw new ArgumentNullException("Positive example data and/or negative example data are required to update a classifier.");
            
            var formData = new MultipartFormDataContent();

            if (positiveExamplesData != null)
            {
                foreach (var kvp in positiveExamplesData)
                {
                    var positiveExampleDataContent = new ByteArrayContent(kvp.Value);
                    positiveExampleDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
                    formData.Add(positiveExampleDataContent, $"{kvp.Key}_positive_examples", "{kvp.Key}_positive_examples.zip");
                }
            }

            if (negativeExamplesData != null)
            {
                var negativeExamplesDataContent = new ByteArrayContent(negativeExamplesData);
                negativeExamplesDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/zip");
                formData.Add(negativeExamplesDataContent, "negative_examples", "negative_examples.zip");
            }

            try
            {
                var result = RepositoryClient.PostAsync($"{ApiKeys.VisualRecognitionEndpoint}{string.Format(classifierUrl, classifierId)}")
                    .WithArgument("version", versionDate)
                    .WithArgument("api_key", ApiKeys.VisualRecognition)
                    .WithBodyContent(formData)
                    .WithFormatter(new MediaTypeHeaderValue("application/octet-stream"))
                    .As<GetClassifierVerboseResponse>()
                    .Result;

                return result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        
        #endregion
    }
}
