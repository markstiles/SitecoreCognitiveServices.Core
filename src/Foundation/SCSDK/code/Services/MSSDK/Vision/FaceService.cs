using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class FaceService : IFaceService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IFaceRepository FaceRepository;
        protected readonly ILogWrapper Logger;
        protected readonly IMediaWrapper MediaWrapper;

        public FaceService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IFaceRepository faceRepository,
            ILogWrapper logger,
            IMediaWrapper mediaWrapper)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            FaceRepository = faceRepository;
            Logger = logger;
            MediaWrapper = mediaWrapper;
        }

        #region Face

        #region Detect

        public virtual Face[] Detect(Stream stream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Detect",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Detect(stream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }

        public virtual Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId = true,
            bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DetectAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DetectAsync(imageStream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }

        public virtual Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Detect",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Detect(imageUrl, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }

        public virtual Task<Face[]> DetectAsync(string imageUrl, bool returnFaceId = true,
            bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DetectAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DetectAsync(imageUrl, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }
        
        public List<string> ValidateFaceImage(MediaItem image)
        {
            List<string> validationErrors = new List<string>();
            List<string> validExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "bmp" };
            
            //JPEG, PNG, GIF (the first frame), and BMP format are supported. 
            if (!validExtensions.Contains(image.Extension))
                validationErrors.Add("Face API only supports JPEG, PNG, GIF, and BMP.");

            //valid dimensions - 36x36 to 4096x4096
            var height = MediaWrapper.GetImageHeight(image);
            var width = MediaWrapper.GetImageWidth(image);
            if (height < 36 || width < 36)
                validationErrors.Add("Face API images must at least be 36px in height and width.");

            if (height > 4096 || width > 4096)
                validationErrors.Add("Face API images cannot be more than 4096px in height or width.");

            //valid file sizes - 1KB to 6MB
            if (image.Size < 1000)
                validationErrors.Add("Face API images must be at least 1KB.");

            if (image.Size > 6000000)
                validationErrors.Add("Face API images can't be more than 6MB.");

            return validationErrors;
        }

        #endregion

        #region Verify

        public virtual VerifyResult Verify(Guid faceId1, Guid faceId2)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Verify",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Verify(faceId1, faceId2);
                    return result;
                },
                null);
        }

        public virtual Task<VerifyResult> VerifyAsync(Guid faceId1, Guid faceId2)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.VerifyAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.VerifyAsync(faceId1, faceId2);
                    return result;
                },
                null);
        }

        public virtual VerifyResult Verify(Guid faceId, string personGroupId, Guid personId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Verify",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Verify(faceId, personGroupId, personId);
                    return result;
                },
                null);
        }

        public virtual Task<VerifyResult> VerifyAsync(Guid faceId, string personGroupId, Guid personId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.VerifyAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.VerifyAsync(faceId, personGroupId, personId);
                    return result;
                },
                null);
        }

        #endregion

        #region Identify

        public virtual IdentifyResult[] Identify(string personGroupId, Guid[] faceIds,
            int maxNumOfCandidatesReturned = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Identify",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Identify(personGroupId, faceIds, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds,
            int maxNumOfCandidatesReturned = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.IdentifyAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.IdentifyAsync(personGroupId, faceIds, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual IdentifyResult[] Identify(string personGroupId, Guid[] faceIds, float confidenceThreshold,
            int maxNumOfCandidatesReturned = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Identify",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Identify(personGroupId, faceIds, confidenceThreshold, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds,
            float confidenceThreshold, int maxNumOfCandidatesReturned = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.IdentifyAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.IdentifyAsync(personGroupId, faceIds, confidenceThreshold, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        #endregion

        #region Find Similar

        public virtual SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilar",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilar(faceId, faceIds, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilarAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilarAsync(faceId, faceIds, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilar",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilar(faceId, faceListId, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilarAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilarAsync(faceId, faceListId, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId, FindSimilarMatchMode mode,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilar",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilar(faceId, faceListId, mode, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId,
            FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilarAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilarAsync(faceId, faceListId, mode, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilar",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilar(faceId, faceIds, mode, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode,
            int maxNumOfCandidatesReturned = 20)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.FindSimilarAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.FindSimilarAsync(faceId, faceIds, mode, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        #endregion

        #region Group

        public virtual GroupResult Group(Guid[] faceIds)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Group",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Group(faceIds);
                    return result;
                },
                null);
        }

        public virtual Task<GroupResult> GroupAsync(Guid[] faceIds)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GroupAsync(faceIds);
                    return result;
                },
                null);
        }

        #endregion

        #endregion

        #region Face List

        public virtual AddPersistedFaceResult AddFaceToFaceList(string faceListId, string imageUrl,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddFaceToFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddFaceToFaceList(faceListId, imageUrl, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, string imageUrl,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddFaceToFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddFaceToFaceListAsync(faceListId, imageUrl, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual AddPersistedFaceResult AddFaceToFaceList(string faceListId, Stream imageStream,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddFaceToFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddFaceToFaceList(faceListId, imageStream, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, Stream imageStream,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddFaceToFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddFaceToFaceListAsync(faceListId, imageStream, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual void CreateFaceList(string faceListId, string name, string userData)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreateFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.CreateFaceList(faceListId, name, userData);
                    return true;
                },
                false);
        }

        public virtual Task CreateFaceListAsync(string faceListId, string name, string userData)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreateFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.CreateFaceListAsync(faceListId, name, userData);
                    return result;
                },
                null);
        }

        public virtual void DeleteFaceFromFaceList(string faceListId, Guid persistedFaceId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeleteFaceFromFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.DeleteFaceFromFaceList(faceListId, persistedFaceId);
                    return true;
                },
                false);
        }

        public virtual Task DeleteFaceFromFaceListAsync(string faceListId, Guid persistedFaceId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeleteFaceFromFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DeleteFaceFromFaceListAsync(faceListId, persistedFaceId);
                    return result;
                },
                null);
        }

        public virtual void DeleteFaceList(string faceListId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeleteFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.DeleteFaceList(faceListId);
                    return true;
                },
                false);
        }

        public virtual Task DeleteFaceListAsync(string faceListId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeleteFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DeleteFaceListAsync(faceListId);
                    return result;
                },
                null);
        }

        public virtual FaceList GetFaceList(string faceListId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetFaceList(faceListId);
                    return result;
                },
                null);
        }

        public virtual Task<FaceList> GetFaceListAsync(string faceListId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetFaceListAsync(faceListId);
                    return result;
                },
                null);
        }

        public virtual FaceListMetadata[] ListFaceLists()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.ListFaceLists",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.ListFaceLists();
                    return result;
                },
                null);
        }

        public virtual Task<FaceListMetadata[]> ListFaceListsAsync()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.ListFaceListsAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.ListFaceListsAsync();
                    return result;
                },
                null);
        }

        public virtual void UpdateFaceList(string faceListId, string name, string userData)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdateFaceList",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.UpdateFaceList(faceListId, name, userData);
                    return true;
                },
                false);
        }

        public virtual Task UpdateFaceListAsync(string faceListId, string name, string userData)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdateFaceListAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.UpdateFaceListAsync(faceListId, name, userData);
                    return result;
                },
                null);
        }

        #endregion

        #region Large Face List

        #endregion

        #region Large Person Group

        #endregion

        #region Large Person Group Person

        #endregion

        #region Person Group

        public virtual void CreatePersonGroup(string personGroupId, string name, string userData = null)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreatePersonGroup",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.CreatePersonGroup(personGroupId, name, userData);
                    return true;
                },
                false);
        }

        public virtual Task CreatePersonGroupAsync(string personGroupId, string name, string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreatePersonGroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.CreatePersonGroupAsync(personGroupId, name, userData);
                    return result;
                },
                null);
        }

        public virtual void DeletePersonGroup(string personGroupId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePersonGroup",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.DeletePersonGroup(personGroupId);
                    return true;
                },
                false);
        }

        public virtual Task DeletePersonGroupAsync(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePersonGroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DeletePersonGroupAsync(personGroupId);
                    return result;
                },
                null);
        }

        public virtual PersonGroup GetPersonGroup(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonGroup",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonGroup(personGroupId);
                    return result;
                },
                null);
        }

        public virtual Task<PersonGroup> GetPersonGroupAsync(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonGroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonGroupAsync(personGroupId);
                    return result;
                },
                null);
        }

        public virtual TrainingStatus GetPersonGroupTrainingStatus(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonGroupTrainingStatus",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonGroupTrainingStatus(personGroupId);
                    return result;
                },
                null);
        }

        public virtual Task<TrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonGroupTrainingStatusAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonGroupTrainingStatusAsync(personGroupId);
                    return result;
                },
                null);
        }

        public virtual PersonGroup[] ListPersonGroups(string start = "", int top = 1000)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.ListPersonGroups",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.ListPersonGroups(start, top);
                    return result;
                },
                null);
        }

        public virtual Task<PersonGroup[]> ListPersonGroupsAsync(string start = "", int top = 1000)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.ListPersonGroupsAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.ListPersonGroupsAsync(start, top);
                    return result;
                },
                null);
        }

        public virtual void TrainPersonGroup(string personGroupId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.TrainPersonGroup",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.TrainPersonGroup(personGroupId);
                    return true;
                },
                false);
        }

        public virtual Task TrainPersonGroupAsync(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.TrainPersonGroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.TrainPersonGroupAsync(personGroupId);
                    return result;
                },
                null);
        }

        public virtual void UpdatePersonGroup(string personGroupId, string name, string userData = null)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePersonGroup",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.UpdatePersonGroup(personGroupId, name, userData);
                    return true;
                },
                false);
        }

        public virtual Task UpdatePersonGroupAsync(string personGroupId, string name, string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePersonGroupAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.UpdatePersonGroupAsync(personGroupId, name, userData);
                    return result;
                },
                null);
        }

        #endregion

        #region Person Group Person

        public virtual CreatePersonResult CreatePerson(string personGroupId, string name, string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreatePerson",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.CreatePerson(personGroupId, name, userData);
                    return result;
                },
                null);
        }

        public virtual Task<CreatePersonResult> CreatePersonAsync(string personGroupId, string name,
            string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.CreatePersonAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.CreatePersonAsync(personGroupId, name, userData);
                    return result;
                },
                null);
        }

        public virtual AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, string imageUrl,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddPersonFace",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddPersonFace(personGroupId, personId, imageUrl, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId,
            string imageUrl, string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddPersonFaceAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddPersonFaceAsync(personGroupId, personId, imageUrl, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, Stream imageStream,
            string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddPersonFace",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddPersonFace(personGroupId, personId, imageStream, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId,
            Stream imageStream, string userData = null, Rectangle targetFace = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.AddPersonFaceAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.AddPersonFaceAsync(personGroupId, personId, imageStream, userData, targetFace);
                    return result;
                },
                null);
        }

        public virtual void DeletePerson(string personGroupId, Guid personId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePerson",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.DeletePerson(personGroupId, personId);
                    return true;
                },
                false);
        }

        public virtual Task DeletePersonAsync(string personGroupId, Guid personId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePersonAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DeletePersonAsync(personGroupId, personId);
                    return result;
                },
                null);
        }

        public virtual void DeletePersonFace(string personGroupId, Guid personId, Guid persistedFaceId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePersonFace",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.DeletePersonFace(personGroupId, personId, persistedFaceId);
                    return true;
                },
                false);
        }

        public virtual Task DeletePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.DeletePersonFaceAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.DeletePersonFaceAsync(personGroupId, personId, persistedFaceId);
                    return result;
                },
                null);
        }

        public virtual Person GetPerson(string personGroupId, Guid personId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPerson",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPerson(personGroupId, personId);
                    return result;
                },
                null);
        }

        public virtual Task<Person> GetPersonAsync(string personGroupId, Guid personId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonAsync(personGroupId, personId);
                    return result;
                },
                null);
        }

        public virtual PersonFace GetPersonFace(string personGroupId, Guid personId, Guid persistedFaceId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonFace",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonFace(personGroupId, personId, persistedFaceId);
                    return result;
                },
                null);
        }

        public virtual Task<PersonFace> GetPersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonFaceAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonFaceAsync(personGroupId, personId, persistedFaceId);
                    return result;
                },
                null);
        }

        public virtual Person[] GetPersons(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersons",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersons(personGroupId);
                    return result;
                },
                null);
        }

        public virtual Task<Person[]> GetPersonsAsync(string personGroupId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.GetPersonsAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.GetPersonsAsync(personGroupId);
                    return result;
                },
                null);
        }

        public virtual void UpdatePerson(string personGroupId, Guid personId, string name, string userData = null)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePerson",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.UpdatePerson(personGroupId, personId, name, userData);
                    return true;
                },
                false);
        }

        public virtual Task UpdatePersonAsync(string personGroupId, Guid personId, string name, string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePersonAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.UpdatePersonAsync(personGroupId, personId, name, userData);
                    return result;
                },
                null);
        }

        public virtual void UpdatePersonFace(string personGroupId, Guid personId, Guid persistedFaceId,
            string userData = null)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePersonFace",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    FaceRepository.UpdatePersonFace(personGroupId, personId, persistedFaceId, userData);
                    return true;
                },
                false);
        }

        public virtual Task UpdatePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId,
            string userData = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.UpdatePersonFaceAsync",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.UpdatePersonFaceAsync(personGroupId, personId, persistedFaceId, userData);
                    return result;
                },
                null);
        }
        
        #endregion
    }
}