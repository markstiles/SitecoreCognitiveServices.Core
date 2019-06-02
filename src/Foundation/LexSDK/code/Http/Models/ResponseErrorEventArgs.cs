using System;
using System.Net;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http.Models
{
    public class ResponseErrorEventArgs : ResponseEventArgs
    {
        public ResponseErrorEventArgs(Type type, HttpStatusCode status, string message) : base(status, message)
        {
            _type = type;
        }

        private Type _type;
        public Type Type
        {
            get
            {
                return _type;
            }
        }
    }
}
