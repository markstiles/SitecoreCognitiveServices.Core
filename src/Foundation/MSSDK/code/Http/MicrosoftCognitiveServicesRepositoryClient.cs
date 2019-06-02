﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Http
{
    public class MicrosoftCognitiveServicesRepositoryClient : IMicrosoftCognitiveServicesRepositoryClient
    {
        public virtual async Task<string> SendGetAsync(string apiKey, string url) {
            return await SendAsync(apiKey, url, null, "application/json", "GET");
        }

        public virtual string SendGet(string apiKey, string url) {
            return Send(apiKey, url, null, "application/json", "GET");
        }

        public virtual async Task<string> SendPostMultiPartAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "multipart/form-data", "POST");
        }

        public virtual string SendPostMultiPart(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "multipart/form-data", "POST");
        }

        public virtual async Task<string> SendEncodedFormPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "application/x-www-form-urlencoded", "POST");
        }

        public virtual string SendEncodedFormPost(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "application/x-www-form-urlencoded", "POST");
        }

        public virtual async Task<string> SendTextPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "text/plain", "POST");
        }

        public virtual string SendTextPost(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "text/plain", "POST");
        }

        public virtual async Task<string> SendJsonPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "application/json", "POST");
        }

        public virtual string SendJsonPost(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "application/json", "POST");
        }

        public virtual async Task<string> SendJsonPutAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "application/json", "PUT");
        }

        public virtual string SendJsonPut(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "application/json", "PUT");
        }

        public virtual async Task<string> SendJsonPatchAsync(string apiKey, string url, string data) {
            return await SendAsync(apiKey, url, GetByteArray(data), "application/json", "PATCH");
        }

        public virtual string SendJsonPatch(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "application/json", "PATCH");
        }

        public virtual async Task<string> SendJsonDeleteAsync(string apiKey, string url)
        {
            return await SendAsync(apiKey, url, null, "application/json", "DELETE");
        }

        public virtual string SendJsonDelete(string apiKey, string url) {
            return Send(apiKey, url, null, "application/json", "DELETE");
        }

        public virtual async Task<string> SendOctetStreamUpdateAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetByteArray(stream), "application/octet-stream", "UPDATE");
        }

        public virtual string SendOctetStreamUpdate(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetByteArray(stream), "application/octet-stream", "UPDATE");
        }

        public virtual async Task<string> SendOctetStreamPostAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual string SendOctetStreamPost(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual async Task<byte[]> SendOctetStreamPostForBytesAsync(string apiKey, string url, Stream stream)
        {
            return await SendForBytesAsync(apiKey, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual byte[] SendOctetStreamPostForBytes(string apiKey, string url, Stream stream)
        {
            return SendForBytes(apiKey, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual async Task<string> SendJsonUpdateAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, GetByteArray(data), "application/json", "UPDATE");
        }

        public virtual string SendJsonUpdate(string apiKey, string url, string data) {
            return Send(apiKey, url, GetByteArray(data), "application/json", "UPDATE");
        }

        public virtual async Task<string> SendImagePostAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetByteArray(stream), GetImageStreamContentType(stream), "POST");
        }

        public virtual string SendImagePost(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetByteArray(stream), GetImageStreamContentType(stream), "POST");
        }

        public virtual async Task<string> SendAsync(string apiKey, string url, byte[] data, string contentType, string method, string token = "", bool sendChunked = false, string host = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("authorization", $"Bearer {token}");
            }

            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;

            if(sendChunked)
                request.SendChunked = true;
            if(!string.IsNullOrEmpty(host))
                request.Host = host;

            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStreamAsync = await request.GetRequestStreamAsync();
                requestStreamAsync.Write(data, 0, data.Length);
                requestStreamAsync.Close();
            }
            else
            {
                request.ContentLength = 0;
            }

            string end = "";
            WebResponse responseAsync = null;
            StreamReader streamReader = null;
            Exception exHolder = null;
            try
            {
                responseAsync = await request.GetResponseAsync();
                streamReader = new StreamReader(responseAsync.GetResponseStream());
                end = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                exHolder = ex;
            }
            finally
            {
                streamReader?.Close();
                responseAsync?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return end;
        }

        public virtual string Send(string apiKey, string url, byte[] data, string contentType, string method, string token = "", bool sendChunked = false, string host = "") {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            if (!string.IsNullOrEmpty(token)) {
                request.Headers.Add("authorization", $"Bearer {token}");
            }

            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;

            if (sendChunked)
                request.SendChunked = true;
            if (!string.IsNullOrEmpty(host))
                request.Host = host;

            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
            } else {
                request.ContentLength = 0;
            }

            string end = "";
            WebResponse response = null;
            StreamReader streamReader = null;
            Exception exHolder = null;
            try {
                response = request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                end = streamReader.ReadToEnd();
            } catch (Exception ex) {
                exHolder = ex;
            } finally {
                streamReader?.Close();
                response?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return end;
        }

        public virtual async Task<byte[]> SendForBytesAsync(string apiKey, string url, byte[] data, string contentType, string method)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;
            request.ContentLength = 0;

            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStreamAsync = await request.GetRequestStreamAsync();
                requestStreamAsync.Write(data, 0, data.Length);
                requestStreamAsync.Close();
            }
            
            byte[] bytes = null;
            WebResponse responseAsync = null;
            Exception exHolder = null;
            try
            {
                responseAsync = await request.GetResponseAsync();
                bytes = GetByteArray(responseAsync.GetResponseStream());
            }
            catch (Exception ex)
            {
                exHolder = ex;
            }
            finally
            {
                responseAsync?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return bytes;
        }
        
        public virtual byte[] SendForBytes(string apiKey, string url, byte[] data, string contentType, string method)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;
            request.ContentLength = 0;

            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
            }
            
            byte[] bytes = null;
            WebResponse response = null;
            Exception exHolder = null;
            try
            {
                response = request.GetResponse();
                bytes = GetByteArray(response.GetResponseStream());
            }
            catch (Exception ex)
            {
                exHolder = ex;
            }
            finally
            {
                response?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return bytes;
        }

        public virtual async Task<string> SendOperationPostAsync(string apiKey, string url, string data) {
            return await SendOperationPostAsync(apiKey, url, GetByteArray(data), "application/json");
        }

        public virtual async Task<string> SendOctetOperationPostAsync(string apiKey, string url, Stream stream) {
            return await SendOperationPostAsync(apiKey, url, GetByteArray(stream), "application/octet-stream");
        }

        public virtual async Task<string> SendOperationPostAsync(string apiKey, string url, byte[] data, string contentType)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.ContentLength = data.Length;
            request.Method = "POST";

            Stream requestStreamAsync = await request.GetRequestStreamAsync();
            requestStreamAsync.Write(data, 0, data.Length);
            requestStreamAsync.Close();

            HttpWebResponse responseAsync = (HttpWebResponse)await request.GetResponseAsync();
            var opLocation = responseAsync.GetResponseHeader("operation-location");
            responseAsync.Close();

            return opLocation;
        }

        public virtual string SendOperationPost(string apiKey, string url, string data) {
            return SendOperationPost(apiKey, url, GetByteArray(data), "application/json");
        }

        public virtual string SendOctetOperationPost(string apiKey, string url, Stream stream) {
            return SendOperationPost(apiKey, url, GetByteArray(stream), "application/octet-stream");
        }

        public virtual string SendOperationPost(string apiKey, string url, byte[] data, string contentType) {

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.ContentLength = data.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var opLocation = response.GetResponseHeader("operation-location");
            response.Close();

            return opLocation;
        }

        public virtual Dictionary<string, string> GetAudioHeaders(string token, AudioOutputFormatOptions outputFormat) {
            return new Dictionary<string, string>()
            {
                { "Content-Type", "application/ssml+xml" },
                { "X-Microsoft-OutputFormat", outputFormat.MemberAttrValue() },
                { "Authorization", $"Bearer {token}" },
                { "User-Agent", "TTSClient" }
            };
        }

        public virtual string GetAudioContent(string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType)
        {
            var langValue = locale.MemberAttrValue();
            var namespaceAttr = $"xmlns=\"http://www.w3.org/2001/10/synthesis\"";
            var versionAttr = $"version=\"1.0\"";
            var langAttr = $"xml:lang=\"{langValue}\"";
            var genderAttr = $"xmlns:gender=\"{voiceType}\"";
            var nameAttr = $"name=\"Microsoft Server Speech Text to Speech Voice {voiceName.MemberAttrValue()}\"";
            var speakTag = $"<speak {versionAttr} {namespaceAttr} {langAttr}><voice {nameAttr}>{text}</voice></speak>";
            
            return speakTag;
        }
        
        public virtual async Task<Stream> GetAudioStreamAsync(string url, string text, SpeechLocaleOptions locale, VoiceName voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat, string token)
        {
            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = new CookieContainer(), UseProxy = false };
            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders.Clear();

            var Headers = GetAudioHeaders(token, outputFormat);
            
            foreach (var header in Headers) {
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url) {
                Content = new StringContent(GetAudioContent(text, locale, voiceName, voiceType))
            };

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}:{response.ReasonPhrase}");

            return await response.Content.ReadAsStreamAsync();
        }
        
        public virtual TokenResponse SendContentModeratorTokenRequest(string privateKey, string clientId)
        {
            byte[] reqData = Encoding.UTF8.GetBytes($"resource=https%3A%2F%2Fapi.contentmoderator.cognitive.microsoft.com%2Freview&client_id={clientId}&client_secret={privateKey}&grant_type=client_credentials");

            WebRequest request = WebRequest.Create("https://login.microsoftonline.com/contentmoderatorprod.onmicrosoft.com/oauth2/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = (long)reqData.Length;

            Stream requestStreamAsync = request.GetRequestStream();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            response.Close();

            TokenResponse t = new JavaScriptSerializer().Deserialize<TokenResponse>(end);

            return t;
        }

        public virtual string SendSpeechTokenRequest(string url, string apiKey) {

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
            request.ContentLength = 0;

            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            response.Close();

            return end;
        }
        
        public virtual string GetImageStreamContentType(Stream stream)
        {
            var image = Image.FromStream(stream);
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
                return "image/jpeg";
            else if (ImageFormat.Png.Equals(image.RawFormat))
                return "image/png";
            else if (ImageFormat.Gif.Equals(image.RawFormat))
                return "image/gif";
            else if (ImageFormat.Bmp.Equals(image.RawFormat))
                return "image/bmp";

            throw new BadImageFormatException("The image stream provided for cognitive analysis wasn't an allowed format (jpeg, png, gif or bmp)");
        }

        public virtual byte[] GetByteArray(Stream stream)
        {
            if (stream is MemoryStream)
                return ((MemoryStream)stream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public virtual byte[] GetByteArray(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}