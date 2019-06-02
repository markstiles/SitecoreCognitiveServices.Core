﻿using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Speech.Models {
    public class ProfileBase {
        public string Locale { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastActionDateTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentStatus EnrollmentStatus { get; set; }
    }
}
