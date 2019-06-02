using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.QnAMaker {
    public class KnowledgeBaseDetails {
        public string Name { get; set; }
        public QnAPair[] QnAPairs { get; set; }
        public string[] Urls { get; set; }
    }
}
