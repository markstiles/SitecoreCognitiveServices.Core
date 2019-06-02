using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition;
using SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class VisualRecognitionService : IVisualRecognitionService
    {
        protected IVisualRecognitionRepository VisualRecognitionRepository;
        protected ILogWrapper Logger;

        public VisualRecognitionService(
            IVisualRecognitionRepository visualRecognitionRepository,
            ILogWrapper logger)
        {
            VisualRecognitionRepository = visualRecognitionRepository;
            Logger = logger;
        }
        
        #region Classify

        public virtual ClassifyTopLevelMultiple Classify(string url, string[] classifierIDs = null, string[] owners = null, float threshold = 0, string acceptLanguage = "en")
        {
            try
            {
                var result = VisualRecognitionRepository.Classify(url, classifierIDs, owners, threshold, acceptLanguage);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.Classify failed", this, ex);
            }

            return null;
        }

        public virtual ClassifyPost Classify(byte[] imageData = null, string imageDataName = null, string imageDataMimeType = null, string[] urls = null, string[] classifierIDs = null, string[] owners = null, float threshold = 0, string acceptLanguage = "en")
        {
            try
            {
                var result = VisualRecognitionRepository.Classify(imageData, imageDataName, imageDataMimeType, urls, classifierIDs, owners, threshold, acceptLanguage);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.Classify failed", this, ex);
            }

            return null;
        }

        #endregion

        #region Detect Faces

        public virtual Faces DetectFaces(string url)
        {
            try
            {
                var result = VisualRecognitionRepository.DetectFaces(url);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.DetectFaces failed", this, ex);
            }

            return null;
        }

        public virtual Faces DetectFaces(byte[] imageData = null, string imageDataName = null, string imageDataMimeType = null, string[] urls = null)
        {
            try
            {
                var result = VisualRecognitionRepository.DetectFaces(imageData, imageDataName, imageDataMimeType, urls);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.DetectFaces failed", this, ex);
            }

            return null;
        }

        #endregion

        #region Classifiers

        public virtual GetClassifiersBriefResponse GetClassifiersBrief()
        {
            try
            {
                var result = VisualRecognitionRepository.GetClassifiersBrief();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.GetClassifiersBrief failed", this, ex);
            }

            return null;
        }

        public virtual GetClassifiersVerboseResponse GetClassifiersVerbose()
        {
            try
            {
                var result = VisualRecognitionRepository.GetClassifiersVerbose();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.GetClassifiersVerbose failed", this, ex);
            }

            return null;
        }

        public virtual GetClassifierVerboseResponse CreateClassifier(string classifierName, Dictionary<string, byte[]> positiveExamplesData, byte[] negativeExamplesData = null)
        {
            try
            {
                var result = VisualRecognitionRepository.CreateClassifier(classifierName, positiveExamplesData, negativeExamplesData);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.CreateClassifier failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteClassifier(string classifierId)
        {
            try
            {
                VisualRecognitionRepository.DeleteClassifier(classifierId);
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.DeleteClassifier failed", this, ex);
            }
        }

        public virtual GetClassifierVerboseResponse GetClassifier(string classifierId)
        {
            try
            {
                var result = VisualRecognitionRepository.GetClassifier(classifierId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.GetClassifier failed", this, ex);
            }

            return null;
        }

        public virtual GetClassifierVerboseResponse UpdateClassifier(string classifierId, Dictionary<string, byte[]> positiveExamplesData = null, byte[] negativeExamplesData = null)
        {
            try
            {
                var result = VisualRecognitionRepository.UpdateClassifier(classifierId, positiveExamplesData, negativeExamplesData);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisualRecognitionService.UpdateClassifier failed", this, ex);
            }

            return null;
        }

        #endregion
    }
}