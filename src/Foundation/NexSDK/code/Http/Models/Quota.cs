using System;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public class Quota
    {
        public Quota(string prefix, HttpResponseHeaders headers)
        {
            var allottedKey = $"{prefix}-allotted";
            var currentKey = $"{prefix}-current";
           
            if (headers.Contains(allottedKey) && Int32.TryParse(headers.GetValues(allottedKey).FirstOrDefault(), out var allotted))
                Allotted = allotted;

            if (headers.Contains(currentKey) && Int32.TryParse(headers.GetValues(currentKey).FirstOrDefault(), out var current))
                Current = current;
        }
        
        public int Allotted { get; set; }
        public int Current { get; set; }
    }
}