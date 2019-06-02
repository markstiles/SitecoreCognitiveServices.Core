﻿using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions
{
    [JsonConverter(typeof(ErrorConverter))]
    public class Error
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Response message that describes the problem.
        /// </summary>
        public string CodeDescription { get; set; }

        /// <summary>
        /// Description of the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Help message
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// For some session-based responses, indicates whether the session was closed as a result of the error. Set to true if an active session is closed as a result of the problem.
        /// </summary>
        public bool SessionClosed { get; set; }
    }
}