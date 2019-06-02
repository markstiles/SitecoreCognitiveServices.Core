﻿using System;
using System.Collections.Generic;
using System.Net;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public class NexosisClientException : Exception
    {
        public NexosisClientException(string message, Exception inner) : base(message, inner) { }

        public NexosisClientException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
            ErrorResponse = null;
        }

        public NexosisClientException(string message, ErrorResponse response) : base(message)
        {
            StatusCode = (HttpStatusCode)response.StatusCode;
            ErrorResponse = response;
        }

        public HttpStatusCode StatusCode { get; set; }
        public ErrorResponse ErrorResponse { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {
            ErrorDetails = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorType { get; set; }
        public Dictionary<string, object> ErrorDetails { get; set; }
    }
}

