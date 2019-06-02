using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.ImageSearch {
    public class ImageSearchCategory
    {
        public string Title { get; set; }
        public List<ImageSearchTile> Tiles { get; set; }
    }
}