namespace SitecoreCognitiveServices.Foundation.NexSDK.Import.Models
{
    public class BasicAuthentication
    {
        /// <summary>
        /// If the url is secured by basic authentication, use this username to authenticate
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// If the url is secured by basic authentication, use this password to authenticate
        /// </summary>
        public string Password { get; set; }
    }
}