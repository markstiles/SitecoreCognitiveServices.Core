using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models
{
    public class ContestantResponse : ChampionContestant
    {
        /// <summary>
        /// The test data used when scoring the contestant
        /// </summary>
        public Dictionary<string, string>[] Data { get; set; }
    }
}