using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.EntityLinking {
    [DataContract]
    public class Match {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "entries")]
        public IList<Entry> Entries { get; set; }
    }
}
