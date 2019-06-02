namespace SitecoreCognitiveServices.Foundation.NexSDK.Import.Models
{
    /// <summary>
    /// The parameters needed to import data into the Nexosis API from a URL
    /// </summary>
    public class ImportFromUrlRequest : ImportRequest
    {
        /// <summary>
        /// The URL to retrieve
        /// </summary>
        public string Url { get; set; }


        /// <summary>
        /// Authentication parameters to be used to retrieve the data at the given url
        /// </summary>
        public ImportFromUrlAuthentication Auth { get; set; }
    }
}