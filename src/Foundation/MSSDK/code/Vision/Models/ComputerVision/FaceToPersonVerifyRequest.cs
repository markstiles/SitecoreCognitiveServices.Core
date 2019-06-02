
using System;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision {

    public class FaceToPersonVerifyRequest {
        public Guid FaceId { get; set; }
        public Guid PersonId { get; set; }
        public string PersonGroupId { get; set; }
    }
}
