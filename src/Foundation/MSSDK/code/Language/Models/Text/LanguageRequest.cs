using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text {
    public class LanguageRequest : TextRequest {
        [JsonIgnore]
        public int NumberOfLanguagesToDetect { get; set; }

        public LanguageRequest() {
            this.NumberOfLanguagesToDetect = 1;
        }
    }
}
