using System;
using System.Net;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http.Models
{
    public class RequestEventArgs : EventArgs
    {
        public RequestEventArgs(string method, string url, string message)
        {
            _method = method;
            _url = url;
            _message = message;
        }

        private string _method;
        public string Method
        {
            get
            {
                return _method;
            }
        }

        private string _url;
        public string Url
        {
            get
            {
                return _url;
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
