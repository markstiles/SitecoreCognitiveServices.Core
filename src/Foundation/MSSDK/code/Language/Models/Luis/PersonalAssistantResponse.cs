﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class PersonalAssistantResponse {
        public object[] EndpointKeys { get; set; }
        public PersonalAssistantEndpoints EndpointUrls { get; set; }
    }
}