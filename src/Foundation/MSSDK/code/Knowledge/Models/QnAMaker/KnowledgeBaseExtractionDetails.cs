using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.QnAMaker {
    public class KnowledgeBaseExtractionDetails {
        public Guid KbId { get; set; }
        public DataExtractionResult[] DataExtractionResults { get; set; }
    }
}
