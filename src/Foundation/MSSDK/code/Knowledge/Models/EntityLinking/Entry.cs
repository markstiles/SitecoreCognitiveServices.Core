﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.EntityLinking {
    [DataContract]
    public class Entry {
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}
