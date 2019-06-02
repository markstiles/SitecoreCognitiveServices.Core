using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.QnAMaker {
    public class PatchKnowledgeBaseRequest {
        public KnowledgeBaseDetails Add { get; set; }
        public KnowledgeBaseDetails Delete { get; set; }
    }
}
