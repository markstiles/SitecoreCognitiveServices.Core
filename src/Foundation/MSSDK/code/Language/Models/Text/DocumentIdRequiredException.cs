using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text {
    public class DocumentIdRequiredException : Exception {
        public override string Message
        {
            get
            {
                return "A document's Id property is required.";
            }
        }
    }
}
