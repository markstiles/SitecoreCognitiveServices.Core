﻿using System.Net;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http.Models
{
    public class AuthResponse
    {
        public AuthResponse()
        {
        }

        public AuthResponse(HttpStatusCode status, string data)
        {
            _status = status;
            _data = data;
        }

        private QueryMethod _method = QueryMethod.GET;
        private HttpStatusCode _status = HttpStatusCode.Unauthorized;
        private string _data = string.Empty;
        private byte[] _binaryData = null;


        public QueryMethod Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public HttpStatusCode Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public byte[] BinaryData
        {
            get { return _binaryData; }
            set { _binaryData = value; }
        }

    }
}
