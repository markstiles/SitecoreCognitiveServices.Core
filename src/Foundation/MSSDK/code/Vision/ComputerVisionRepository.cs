﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision
{
    public class ComputerComputerVisionRepository : IComputerVisionRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public ComputerComputerVisionRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual string GetImageUrlJson(string imageUrl)
        {
            return JsonConvert.SerializeObject(new Image { Url = imageUrl });
        }

        #region Analyze Image

        public virtual async Task<AnalysisResult> GetFullAnalysisAsync(Stream stream)
        {
            return await AnalyzeImageAsync(stream, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual AnalysisResult GetFullAnalysis(Stream stream)
        {
            return AnalyzeImage(stream, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<AnalysisResult> GetFullAnalysisAsync(string imageUrl)
        {
            return await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual AnalysisResult GetFullAnalysis(string imageUrl)
        {
            return AnalyzeImage(imageUrl, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<Adult> GetAdultAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual Adult GetAdultAnalysis(Stream stream)
        {
            var result = AnalyzeImage(stream, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Adult> GetAdultAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual Adult GetAdultAnalysis(string imageUrl)
        {
            var result = AnalyzeImage(imageUrl, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Category[]> GetCategoryAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual Category[] GetCategoryAnalysis(Stream stream)
        {
            var result = AnalyzeImage(stream, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Category[]> GetCategoryAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual Category[] GetCategoryAnalysis(string imageUrl)
        {
            var result = AnalyzeImage(imageUrl, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Color> GetColorAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual Color GetColorAnalysis(Stream stream)
        {
            var result = AnalyzeImage(stream, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual async Task<Color> GetColorAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual Color GetColorAnalysis(string imageUrl)
        {
            var result = AnalyzeImage(imageUrl, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual async Task<SimpleFace[]> GetFaceAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual SimpleFace[] GetFaceAnalysis(Stream stream)
        {
            var result = AnalyzeImage(stream, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<SimpleFace[]> GetFaceAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual SimpleFace[] GetFaceAnalysis(string imageUrl)
        {
            var result = AnalyzeImage(imageUrl, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual ImageType GetImageTypeAnalysis(Stream stream)
        {
            var result = AnalyzeImage(stream, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual ImageType GetImageTypeAnalysis(string imageUrl)
        {
            var result = AnalyzeImage(imageUrl, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual string GetAnalyzeQuerystring(IEnumerable<VisualFeature> visualFeatures, IEnumerable<string> details)
        {
            StringBuilder sb = new StringBuilder();
            if (visualFeatures != null && visualFeatures.Any())
                sb.Append($"?visualFeatures={string.Join(",", visualFeatures)}");

            if (details != null && details.Any())
            {
                var concat = sb.Length > 0 ? "&" : "?";
                sb.Append($"{concat}details={string.Join(",", details)}");
            }

            return sb.ToString();
        }

        public virtual async Task<AnalysisResult> AnalyzeImageAsync(string imageUrl, IEnumerable<VisualFeature> visualFeatures = null, IEnumerable<string> details = null)
        {
            var qs = GetAnalyzeQuerystring(visualFeatures, details);
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}analyze{qs}", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult AnalyzeImage(string imageUrl, IEnumerable<VisualFeature> visualFeatures = null, IEnumerable<string> details = null)
        {
            var qs = GetAnalyzeQuerystring(visualFeatures, details);
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}analyze{qs}", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual async Task<AnalysisResult> AnalyzeImageAsync(Stream imageStream, IEnumerable<VisualFeature> visualFeatures = null, IEnumerable<string> details = null)
        {
            var qs = GetAnalyzeQuerystring(visualFeatures, details);
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}analyze{qs}", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult AnalyzeImage(Stream imageStream, IEnumerable<VisualFeature> visualFeatures = null, IEnumerable<string> details = null)
        {
            var qs = GetAnalyzeQuerystring(visualFeatures, details);
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}analyze{qs}", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        #endregion Analyze Image

        #region Analyze Image In Domain

        public virtual async Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(string url, Model model)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{model.Name}/analyze", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, Model model)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{model.Name}/analyze", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual async Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(string url, string modelName)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{modelName}/analyze", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, string modelName)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{modelName}/analyze", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual async Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(Stream imageStream, Model model)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{model.Name}/analyze", imageStream);

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, Model model)
        {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{model.Name}/analyze", imageStream);

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual async Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(Stream imageStream, string modelName)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{modelName}/analyze", imageStream);

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, string modelName)
        {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models/{modelName}/analyze", imageStream);

            return JsonConvert.DeserializeObject<AnalysisInDomainResult>(response);
        }

        #endregion Analyze Image In Domain

        #region List Domain Specific Models

        public virtual async Task<ModelResult> ListModelsAsync()
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models");

            return JsonConvert.DeserializeObject<ModelResult>(response);
        }

        public virtual ModelResult ListModels()
        {
            var response = RepositoryClient.SendGet(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}models");

            return JsonConvert.DeserializeObject<ModelResult>(response);
        }

        #endregion List Domain Specific Models

        #region Describe

        public virtual async Task<AnalysisResult> DescribeAsync(string url, int maxCandidates = 1)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}describe?maxCandidates={maxCandidates}", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult Describe(string url, int maxCandidates = 1)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}describe?maxCandidates={maxCandidates}", GetImageUrlJson(url));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual async Task<AnalysisResult> DescribeAsync(Stream imageStream, int maxCandidates = 1)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}describe?maxCandidates={maxCandidates}", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult Describe(Stream imageStream, int maxCandidates = 1)
        {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}describe?maxCandidates={maxCandidates}", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        #endregion Describe

        #region Get Thumbnail

        public virtual async Task<byte[]> GetThumbnailAsync(string url, int width, int height, bool smartCropping = true)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}generateThumbnail?width={width}&height={height}&smartCropping={smartCropping}", GetImageUrlJson(url));

            return RepositoryClient.GetByteArray(response);
        }

        public virtual byte[] GetThumbnail(string url, int width, int height, bool smartCropping = true)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}generateThumbnail?width={width}&height={height}&smartCropping={smartCropping}", GetImageUrlJson(url));

            return RepositoryClient.GetByteArray(response);
        }

        public virtual async Task<byte[]> GetThumbnailAsync(Stream stream, int width, int height, bool smartCropping = true)
        {
            var response = await RepositoryClient.SendOctetStreamPostForBytesAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}generateThumbnail?width={width}&height={height}&smartCropping={smartCropping}", stream);

            return response;
        }

        public virtual byte[] GetThumbnail(Stream stream, int width, int height, bool smartCropping = true)
        {
            var response = RepositoryClient.SendOctetStreamPostForBytes(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}generateThumbnail?width={width}&height={height}&smartCropping={smartCropping}", stream);

            return response;
        }

        #endregion Get Thumbnail

        #region Recognize Text

        public virtual async Task<OcrResults> RecognizeTextAsync(string imageUrl, string languageCode = "unk", bool detectOrientation = true)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}ocr?language={languageCode}&detectOrientation={detectOrientation}", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<OcrResults>(response);
        }

        public virtual OcrResults RecognizeText(string imageUrl, string languageCode = "unk", bool detectOrientation = true)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}ocr?language={languageCode}&detectOrientation={detectOrientation}", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<OcrResults>(response);
        }

        public virtual async Task<OcrResults> RecognizeTextAsync(Stream imageStream, string languageCode = "unk", bool detectOrientation = true)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}ocr?language={languageCode}&detectOrientation={detectOrientation}", imageStream);

            return JsonConvert.DeserializeObject<OcrResults>(response);
        }

        public virtual OcrResults RecognizeText(Stream imageStream, string languageCode = "unk", bool detectOrientation = true)
        {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}ocr?language={languageCode}&detectOrientation={detectOrientation}", imageStream);

            return JsonConvert.DeserializeObject<OcrResults>(response);
        }

        #endregion Recognize Text

        #region Get Tags

        public virtual async Task<AnalysisResult> GetTagsAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}tag", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult GetTags(string imageUrl)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}tag", GetImageUrlJson(imageUrl));

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual async Task<AnalysisResult> GetTagsAsync(Stream imageStream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}tag", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        public virtual AnalysisResult GetTags(Stream imageStream)
        {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}tag", imageStream);

            return JsonConvert.DeserializeObject<AnalysisResult>(response);
        }

        #endregion Get Tags

        #region Get Handwritten Text Operation Result

        public virtual async Task<HandwrittenTextResponse> GetHandwrittenTextOperationResultAsync(string operationId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}textOperations/{operationId}");

            return JsonConvert.DeserializeObject<HandwrittenTextResponse>(response);
        }

        public virtual HandwrittenTextResponse GetHandwrittenTextOperationResult(string operationId)
        {
            var response = RepositoryClient.SendGet(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}textOperations/{operationId}");

            return JsonConvert.DeserializeObject<HandwrittenTextResponse>(response);
        }

        #endregion Get Handwritten Text Operation Result

        #region Recognize Handwritten Text

        public virtual async Task<string> RecognizeHandwrittenTextAsync(string imageUrl, bool handwriting = false)
        {
            return await RepositoryClient.SendOperationPostAsync(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}recognizeText?handwriting={handwriting}", GetImageUrlJson(imageUrl));
        }

        public virtual string RecognizeHandwrittenText(string imageUrl, bool handwriting = false)
        {
            return RepositoryClient.SendOperationPost(ApiKeys.ComputerVision, $"{ApiKeys.ComputerVisionEndpoint}recognizeText?handwriting={handwriting}", GetImageUrlJson(imageUrl));
        }

        #endregion Recognize Handwritten Text
    }
}