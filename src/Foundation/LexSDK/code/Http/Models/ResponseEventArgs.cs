using System;
using System.Net;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http.Models
{
    public class ResponseEventArgs : EventArgs
    {
        public ResponseEventArgs()
        {
        }

        public ResponseEventArgs(HttpStatusCode status, string message)
        {
            _status = status;
            _message = message;
        }

        private HttpStatusCode _status;
        public HttpStatusCode Status
        {
            get
            {
                return _status;
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
