using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;
using Polly;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class ComputerVisionService : IComputerVisionService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IComputerVisionRepository ComputerVisionRepository;
        protected readonly ILogWrapper Logger;
        protected readonly IMediaWrapper MediaWrapper;

        public ComputerVisionService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IComputerVisionRepository computerVisionRepository,
            ILogWrapper logger,
            IMediaWrapper mediaWrapper)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            ComputerVisionRepository = computerVisionRepository;
            Logger = logger;
            MediaWrapper = mediaWrapper;
        }

        #region Validation

        public List<string> ValidateVisionImage(MediaItem image)
        {
            return ValidateVisionImage(image, -1, -1);
        }

        public List<string> ValidateVisionImage(MediaItem image, int newHeight, int newWidth)
        {
            List<string> validationErrors = new List<string>();
            List<string> validExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "bmp" };
            
            //Supported image formats: JPEG, PNG, GIF, BMP.
            if (!validExtensions.Contains(image.Extension))
                validationErrors.Add("Vision API only supports JPEG, PNG, GIF, and BMP.");

            //Image dimensions must be at least 50 x 50.
            var height = MediaWrapper.GetImageHeight(image);
            var width = MediaWrapper.GetImageWidth(image);
            
            if (newHeight > height || newWidth > width)
                validationErrors.Add("New dimensions must at be smaller than the original dimensions.");

            if (height < 50 || width < 50)
                validationErrors.Add("Vision API images must at least be 50px in height and width.");

            //Image file size must be less than 4MB.
            if (image.Size >= 4000000)
                validationErrors.Add("Vision API images must be less than 4MB.");

            return validationErrors;
        }

        #endregion

        #region Adult

        public virtual Adult GetAdultAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetAdultAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetAdultAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Adult GetAdultAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetAdultAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetAdultAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Adult

        #region Categories

        public virtual Category[] GetCategoryAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetCategoryAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetCategoryAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Category[] GetCategoryAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetCategoryAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetCategoryAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Categories

        #region Color

        public virtual Color GetColorAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetColorAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetColorAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Color GetColorAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetColorAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetColorAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Color

        #region Face

        public virtual SimpleFace[] GetFaceAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFaceAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetFaceAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual SimpleFace[] GetFaceAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFaceAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetFaceAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Face

        #region Full Analysis

        public virtual AnalysisResult GetFullAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFullAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetFullAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual AnalysisResult GetFullAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFullAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetFullAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Full Analysis

        #region Image Type

        public virtual ImageType GetImageTypeAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetImageTypeAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetImageTypeAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual ImageType GetImageTypeAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetImageTypeAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetImageTypeAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Image Type

        #region Analyze Image
        
        public virtual AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImage",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImage(stream, features, details);
                    return result;
                },
                null);
        }

        public virtual AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImage",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImage(imageUrl, features, details);
                    return result;
                },
                null);
        }

        #endregion Analyze Image

        #region Analyze Image In Domain

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, Model model)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImageInDomain(url, model);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, Model model)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImageInDomain(imageStream, model);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, string modelName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImageInDomain(url, modelName);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, string modelName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.AnalyzeImageInDomain(imageStream, modelName);
                    return result;
                },
                null);
        }

        #endregion Analyze Image In Domain

        #region List Models

        public virtual ModelResult ListModels()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.ListModels",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.ListModels();
                    return result;
                },
                null);
        }

        #endregion List Models

        #region Describe
        
        public virtual Description Describe(string url, int maxCandidates = 1)
        {
            Assert.IsNotNull(url, GetType());

            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.Describe",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.Describe(url, maxCandidates).Description;
                    return result;
                },
                null);
        }

        public virtual Description Describe(Stream imageStream, int maxCandidates = 1)
        {
            Assert.IsNotNull(imageStream, GetType());

            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.Describe",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.Describe(imageStream, maxCandidates).Description;
                    return result;
                },
                null);
        }

        #endregion Describe

        #region Get Thumbnail
        
        public virtual byte[] GetThumbnail(string url, int width, int height, bool smartCropping = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetThumbnail",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetThumbnail(url, width, height, smartCropping);
                    return result;
                },
                null);
        }

        public virtual byte[] GetThumbnail(Stream stream, int width, int height, bool smartCropping = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetThumbnail",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetThumbnail(stream, width, height, smartCropping);
                    return result;
                },
                null);
        }

        #endregion Get Thumbnail

        #region Recognize Text

        public virtual OcrResults RecognizeText(Stream stream, string language = "unk", bool detectOrientation = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.RecognizeText",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.RecognizeText(stream, language, detectOrientation);
                    return result;
                },
                null);
        }

        public virtual OcrResults RecognizeText(string imageUrl, string language = "unk", bool detectOrientation = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.RecognizeText",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.RecognizeText(imageUrl, language, detectOrientation);
                    return result;
                },
                null);
        }
        
        #endregion Recognize Text

        #region Get Tags

        public virtual Tag[] GetTags(string url)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetTags",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetTags(url).Tags;
                    return result;
                },
                null);
        }
        
        public virtual Tag[] GetTags(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetTags",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = ComputerVisionRepository.GetTags(imageStream).Tags;
                    return result;
                },
                null);
        }

        #endregion Get Tags
    }
}