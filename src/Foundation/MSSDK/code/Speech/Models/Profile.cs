﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Speech.Models {
    public class Profile : ProfileBase {
        [JsonProperty("identificationProfileId")]
        public Guid ProfileId { get; set; }

        [JsonProperty("enrollmentSpeechTime")]
        public double EnrollmentSpeechSeconds { get; set; }

        [JsonProperty("remainingEnrollmentSpeechTime")]
        public double RemainingEnrollmentSpeechSeconds { get; set; }
    }
}
