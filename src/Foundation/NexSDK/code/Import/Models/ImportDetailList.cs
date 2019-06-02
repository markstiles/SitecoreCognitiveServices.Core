using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Import.Models
{
    public class ImportDetailList : Paged<ImportDetail>
    {
        /// <summary>
        /// The list of Imports
        /// </summary>
        public List<ImportDetail> Items { get; set; }
    }
}