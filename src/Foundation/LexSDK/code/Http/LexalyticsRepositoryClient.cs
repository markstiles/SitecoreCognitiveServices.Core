using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http
{
    public class LexalyticsRepositoryClient : ILexalyticsRepositoryClient
    {
        #region Constructor 

        protected readonly ILexalyticsApiKeys ApiKeys;

        #region Properties

        protected readonly string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        protected readonly string OAuthVersion = "1.0";
        protected readonly string OAuthParameterPrefix = "oauth_";
        protected readonly string OAuthConsumerKeyKey = "oauth_consumer_key";
        protected readonly string OAuthVersionKey = "oauth_version";
        protected readonly string OAuthSignatureMethodKey = "oauth_signature_method";
        protected readonly string OAuthSignatureKey = "oauth_signature";
        protected readonly string OAuthTimestampKey = "oauth_timestamp";
        protected readonly string OAuthNonceKey = "oauth_nonce";

        #endregion

        public LexalyticsRepositoryClient(ILexalyticsApiKeys apiKeys)
        {
            ApiKeys = apiKeys;
        }

        #endregion

        #region Request Methods

        public string BuildUrl(ILexalyticsApiKeys apiKeys, string path, string configId = "")
        {
            var configQuery = !string.IsNullOrEmpty(configId)
                ? $"?config_id={configId}"
                : "";
            string url = $"{apiKeys.Host}/{path}.{apiKeys.Format}{configQuery}";

            return url;
        }
        
        public virtual T Get<T>(string url)
        {
            var result = AuthWebRequest(QueryMethod.GET, url, null, false);

            return JsonConvert.DeserializeObject<T>(result.Data);
        }
        
        public virtual T GetBinary<T>(string url)
        {
            var result = AuthWebRequest(QueryMethod.GET, url, null, true);

            return JsonConvert.DeserializeObject<T>(result.Data);
        }

        public virtual T Post<T>(string url, string data)
        {
            var result = AuthWebRequest(QueryMethod.POST, url, data, false);

            return JsonConvert.DeserializeObject<T>(result.Data);
        }

        public virtual int PostStatus(string url, string data)
        {
            var result = AuthWebRequest(QueryMethod.POST, url, data, false);
            int status = (int)result.Status;

            return status;
        }

        public virtual T Put<T>(string url, string data)
        {
            var result = AuthWebRequest(QueryMethod.PUT, url, data, false);

            return JsonConvert.DeserializeObject<T>(result.Data);
        }

        public virtual int PutStatus(string url, string data)
        {
            var result = AuthWebRequest(QueryMethod.PUT, url, data, false);
            int status = (int)result.Status;

            return status;
        }
        
        public virtual int Delete(string url, string data)
        {
            var result = AuthWebRequest(QueryMethod.DELETE, url, data, false);
            int status = (int)result.Status;

            return status;
        }

        #endregion
    
        #region Authentication Methods

        /// <summary>
        /// Sign a web request using Auth.
        /// </summary>
        /// <param name="method">Http method GET, POST or DELETE</param>
        /// <param name="url">The full url, including the querystring.</param>
        /// <param name="postData">Data to post in xml or json fromat</param>
        /// <returns>The web server response.</returns>
        protected AuthResponse AuthWebRequest(QueryMethod method, string url, string postData, bool isBinary)
        {
            Uri uri = new Uri(url);

            string nonce = this.GenerateNonce();
            string timeStamp = this.GenerateTimeStamp();

            string authheader = this.GenerateAuthorizationHeader(uri,
                method.ToString(),
                timeStamp,
                nonce);

            string querystringUri = this.GenerateQueryString(uri,
                method.ToString(),
                timeStamp,
                nonce);

            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(querystringUri);
            webRequest.Method = method.ToString();
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Headers.Add("x-app-name", ApiKeys.AppName);
            webRequest.Headers.Add("x-api-version", ApiKeys.ApiVersion);
            webRequest.Headers.Add("Authorization", authheader);

            if (ApiKeys.UseCompression)
            {
                webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            if (method == QueryMethod.POST || method == QueryMethod.PUT || method == QueryMethod.DELETE)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //Write the data.
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                }
            }

            AuthResponse authResponse = WebResponseGet(webRequest, isBinary);
            authResponse.Method = method;

            return authResponse;
        }

        protected AuthResponse WebResponseGet(HttpWebRequest webRequest, bool isBinary)
        {
            AuthResponse authResponse = new AuthResponse();
            try
            {
                readGoodResponse(webRequest, authResponse, isBinary);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    readProtocolError(e, authResponse);
                }
                else
                {
                    authResponse.Status = HttpStatusCode.BadRequest;
                    authResponse.Data = e.Message;
                }
            }

            return authResponse;
        }

        protected void readGoodResponse(HttpWebRequest webRequest, AuthResponse authResponse, bool isBinary)
        {
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            using (response)
            {
                authResponse.Status = response.StatusCode;
                if (isBinary)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        response.GetResponseStream().CopyTo(ms);
                        authResponse.BinaryData = ms.ToArray();
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(stream))
                        {
                            authResponse.Data = responseReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        protected void readProtocolError(WebException e, AuthResponse authResponse)
        {
            using (HttpWebResponse response = (HttpWebResponse)e.Response)
            {
                authResponse.Status = response.StatusCode;
                authResponse.Data = response.StatusDescription;
                using (Stream stream = response.GetResponseStream())
                {
                    if (null != stream && stream.CanRead)
                    {
                        using (StreamReader responseReader = new StreamReader(stream))
                        {
                            authResponse.Data = responseReader.ReadToEnd();
                        }
                    }
                }

            }
        }

        protected string GenerateQueryUrl(Uri url)
        {
            string normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                normalizedUrl += ":" + url.Port;
            }
            normalizedUrl += url.AbsolutePath;
            return normalizedUrl;
        }

        protected string GenerateQueryString(Uri url, string httpMethod, string timeStamp, string nonce)
        {
            List<QueryParameter> parameters = this.GetQueryParameters(url.Query);
            parameters.Add(new QueryParameter(OAuthVersionKey, OAuthVersion));
            parameters.Add(new QueryParameter(OAuthNonceKey, nonce));
            parameters.Add(new QueryParameter(OAuthTimestampKey, timeStamp));
            parameters.Add(new QueryParameter(OAuthSignatureMethodKey, "HMAC-SHA1"));
            parameters.Add(new QueryParameter(OAuthConsumerKeyKey, ApiKeys.ConsumerKey));

            parameters.Sort(new QueryParameterComparer());

            string normalizedUrl = this.GenerateQueryUrl(url);
            string normalizedRequestParameters = this.NormalizeRequestParameters(parameters);

            StringBuilder signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}?", normalizedUrl);
            signatureBase.AppendFormat("{0}", normalizedRequestParameters);

            return signatureBase.ToString();
        }

        protected string GenerateAuthorizationHeader(Uri url, string httpMethod, string timeStamp, string nonce)
        {
            string query = this.GenerateQueryString(url, httpMethod, timeStamp, nonce);
            query = this.UrlEncode(query);
            string md5cs = this.CalculateMD5Hash(ApiKeys.ConsumerSecret);

            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes(md5cs);
            string hash = this.ComputeHash(hmacsha1, query);
            hash = HttpUtility.UrlEncode(hash);

            List<QueryParameter> parameters = this.GetQueryParameters(url.Query);
            parameters.Add(new QueryParameter("OAuth realm", ""));
            parameters.Add(new QueryParameter(OAuthVersionKey, OAuthVersion));
            parameters.Add(new QueryParameter(OAuthNonceKey, nonce));
            parameters.Add(new QueryParameter(OAuthTimestampKey, timeStamp));
            parameters.Add(new QueryParameter(OAuthSignatureMethodKey, "HMAC-SHA1"));
            parameters.Add(new QueryParameter(OAuthConsumerKeyKey, ApiKeys.ConsumerKey));
            parameters.Add(new QueryParameter(OAuthSignatureKey, hash));

            parameters.Sort(new QueryParameterComparer());

            string normalizedHeaderParameters = NormalizeHeaderParameters(parameters);

            StringBuilder signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}", normalizedHeaderParameters);

            return signatureBase.ToString();
        }

        protected List<QueryParameter> GetQueryParameters(string parameters)
        {
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }

            List<QueryParameter> result = new List<QueryParameter>();

            if (!string.IsNullOrEmpty(parameters))
            {
                string[] p = parameters.Split('&');
                foreach (string s in p)
                {
                    if (!string.IsNullOrEmpty(s) && !s.StartsWith(OAuthParameterPrefix))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(new QueryParameter(temp[0], temp[1]));
                        }
                        else
                        {
                            result.Add(new QueryParameter(s, string.Empty));
                        }
                    }
                }
            }

            return result;
        }

        protected string NormalizeRequestParameters(IList<QueryParameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            QueryParameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        protected string NormalizeHeaderParameters(IList<QueryParameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            QueryParameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}=\"{1}\"", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }

        protected string ComputeHash(HashAlgorithm hashAlgorithm, string data)
        {
            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = hashAlgorithm.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }

        protected string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        protected string UrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }

        protected string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        protected string GenerateNonce()
        {
            return this.NextUInt64().ToString();
            // Just a simple implementation of a random number between 123400 and 9999999
            //Random random = new Random();
            //return random.Next(123400, 9999999).ToString();
        }

        protected UInt64 NextUInt64()
        {
            var bytes = new byte[sizeof(UInt64)];
            RNGCryptoServiceProvider gen = new RNGCryptoServiceProvider();
            gen.GetBytes(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        #endregion
    }
}
