using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face {
    public class Person {
        public Guid PersonId { get; set; }

        public Guid[] PersistedFaceIds { get; set; }

        public string Name { get; set; }

        public string UserData { get; set; }
    }
}
