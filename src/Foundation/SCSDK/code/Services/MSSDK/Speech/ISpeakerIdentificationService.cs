﻿
using SitecoreCognitiveServices.Foundation.MSSDK.Speech.Models;
using System;
using System.IO;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech
{
    public interface ISpeakerIdentificationService
    {
        OperationLocation Identify(Stream audioStream, Guid[] ids);
        CreateProfileResponse CreateProfile(string locale);
        void DeleteProfile(Guid id);
        Profile GetProfile(Guid id);
        Profile[] GetProfiles();
        OperationLocation Enroll(Stream audioStream, Guid id);
        EnrollmentOperation CheckEnrollmentStatus(OperationLocation location);
        IdentificationOperation CheckIdentificationStatus(OperationLocation location);
        void ResetEnrollments(Guid id);
    }
}