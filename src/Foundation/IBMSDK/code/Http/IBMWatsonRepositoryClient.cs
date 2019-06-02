using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Filters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http
{
    public class IBMWatsonRepositoryClient : IIBMWatsonRepositoryClient
    {
        private bool IsDisposed;

        public List<IHttpFilter> Filters { get; private set; }

        public HttpClient BaseClient { get; private set; }

        public MediaTypeFormatterCollection Formatters { get; protected set; }

        public IBMWatsonRepositoryClient()
        {
            BaseClient = new HttpClient();

            Filters = new List<IHttpFilter> { new ErrorFilter() };
            
            Formatters = new MediaTypeFormatterCollection();
        }

        public IIBMWatsonRepositoryClient WithAuthentication(string username, string password)
        {
            if (BaseClient.DefaultRequestHeaders.Authorization == null && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                string auth = $"{username}:{password}";
                string auth64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));

                BaseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth64);
            }

            return this;
        }

        public IRequest DeleteAsync(string url)
        {
            return SendAsync(url, HttpMethod.Delete);
        }

        public IRequest GetAsync(string url)
        {
            return SendAsync(url, HttpMethod.Get);
        }

        public IRequest PostAsync(string url)
        {
            return SendAsync(url, HttpMethod.Post);
        }

        public IRequest PostAsync<TBody>(string url, TBody body)
        {
            return PostAsync(url).WithBody(body);
        }

        public IRequest PutAsync(string url)
        {
            return SendAsync(url, HttpMethod.Put);
        }

        public IRequest PutAsync<TBody>(string url, TBody body)
        {
            return PutAsync(url).WithBody(body);
        }

        public virtual IRequest SendAsync(string url, HttpMethod method)
        {
            AssertNotDisposed();
            
            HttpRequestMessage message = HttpFactory.GetRequestMessage(method, BaseClient.BaseAddress, Formatters);
            return SendAsync(url, message);
        }

        public virtual IRequest SendAsync(string url, HttpRequestMessage message)
        {
            AssertNotDisposed();
            if (url != null)
                message.RequestUri = new Uri(url);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            return new Request(message, Formatters, request => BaseClient.SendAsync(request.Message), Filters.ToArray());
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected void AssertNotDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(IBMWatsonRepositoryClient));
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (IsDisposed)
                return;

            if (isDisposing)
                BaseClient.Dispose();

            IsDisposed = true;
        }

        ~IBMWatsonRepositoryClient()
        {
            Dispose(false);
        }
    }
}