﻿
using System;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public interface IFaceService
    {
        AddPersistedFaceResult AddFaceToFaceList(string faceListId, string imageUrl, string userData = null, Rectangle targetFace = null);
        Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, string imageUrl, string userData = null, Rectangle targetFace = null);
        AddPersistedFaceResult AddFaceToFaceList(string faceListId, Stream imageStream, string userData = null, Rectangle targetFace = null);
        Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, Stream imageStream, string userData = null, Rectangle targetFace = null);
        AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, string imageUrl, string userData = null, Rectangle targetFace = null);
        Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, string imageUrl, string userData = null, Rectangle targetFace = null);
        AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, Stream imageStream, string userData = null, Rectangle targetFace = null);
        Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, Stream imageStream, string userData = null, Rectangle targetFace = null);
        void CreateFaceList(string faceListId, string name, string userData);
        Task CreateFaceListAsync(string faceListId, string name, string userData);
        CreatePersonResult CreatePerson(string personGroupId, string name, string userData = null);
        Task<CreatePersonResult> CreatePersonAsync(string personGroupId, string name, string userData = null);
        void CreatePersonGroup(string personGroupId, string name, string userData = null);
        Task CreatePersonGroupAsync(string personGroupId, string name, string userData = null);
        void DeleteFaceFromFaceList(string faceListId, Guid persistedFaceId);
        Task DeleteFaceFromFaceListAsync(string faceListId, Guid persistedFaceId);
        void DeleteFaceList(string faceListId);
        Task DeleteFaceListAsync(string faceListId);
        void DeletePerson(string personGroupId, Guid personId);
        Task DeletePersonAsync(string personGroupId, Guid personId);
        void DeletePersonFace(string personGroupId, Guid personId, Guid persistedFaceId);
        Task DeletePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId);
        void DeletePersonGroup(string personGroupId);
        Task DeletePersonGroupAsync(string personGroupId);
        Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        Task<Face[]> DetectAsync(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        Face[] Detect(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20);
        Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20);
        SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20);
        Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20);
        SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);
        Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);
        SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);
        Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);
        FaceList GetFaceList(string faceListId);
        Task<FaceList> GetFaceListAsync(string faceListId);
        Person GetPerson(string personGroupId, Guid personId);
        Task<Person> GetPersonAsync(string personGroupId, Guid personId);
        PersonFace GetPersonFace(string personGroupId, Guid personId, Guid persistedFaceId);
        Task<PersonFace> GetPersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId);
        PersonGroup GetPersonGroup(string personGroupId);
        Task<PersonGroup> GetPersonGroupAsync(string personGroupId);
        TrainingStatus GetPersonGroupTrainingStatus(string personGroupId);
        Task<TrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId);
        Person[] GetPersons(string personGroupId);
        Task<Person[]> GetPersonsAsync(string personGroupId);
        GroupResult Group(Guid[] faceIds);
        Task<GroupResult> GroupAsync(Guid[] faceIds);
        IdentifyResult[] Identify(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1);
        Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1);
        IdentifyResult[] Identify(string personGroupId, Guid[] faceIds, float confidenceThreshold, int maxNumOfCandidatesReturned = 1);
        Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, float confidenceThreshold, int maxNumOfCandidatesReturned = 1);
        FaceListMetadata[] ListFaceLists();
        Task<FaceListMetadata[]> ListFaceListsAsync();
        PersonGroup[] ListPersonGroups(string start = "", int top = 1000);
        Task<PersonGroup[]> ListPersonGroupsAsync(string start = "", int top = 1000);
        void TrainPersonGroup(string personGroupId);
        Task TrainPersonGroupAsync(string personGroupId);
        void UpdateFaceList(string faceListId, string name, string userData);
        Task UpdateFaceListAsync(string faceListId, string name, string userData);
        void UpdatePerson(string personGroupId, Guid personId, string name, string userData = null);
        Task UpdatePersonAsync(string personGroupId, Guid personId, string name, string userData = null);
        void UpdatePersonFace(string personGroupId, Guid personId, Guid persistedFaceId, string userData = null);
        Task UpdatePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId, string userData = null);
        void UpdatePersonGroup(string personGroupId, string name, string userData = null);
        Task UpdatePersonGroupAsync(string personGroupId, string name, string userData = null);
        List<string> ValidateFaceImage(MediaItem image);
        VerifyResult Verify(Guid faceId1, Guid faceId2);
        Task<VerifyResult> VerifyAsync(Guid faceId1, Guid faceId2);
        VerifyResult Verify(Guid faceId, string personGroupId, Guid personId);
        Task<VerifyResult> VerifyAsync(Guid faceId, string personGroupId, Guid personId);
    }
}