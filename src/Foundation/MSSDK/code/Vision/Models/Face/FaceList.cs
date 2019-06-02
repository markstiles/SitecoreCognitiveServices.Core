using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face {
    public class FaceList : FaceListMetadata {
        public PersonFace[] PersistedFaces { get; set; }
    }
}
