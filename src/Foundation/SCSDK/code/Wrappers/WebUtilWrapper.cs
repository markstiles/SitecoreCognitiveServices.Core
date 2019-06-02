﻿
namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IWebUtilWrapper
    {
        string GetQueryString(string key, string defaultValue = "");
        string UrlEncode(string value);
    }

    public class WebUtilWrapper : IWebUtilWrapper
    {
        public virtual string GetQueryString(string key, string defaultValue = "")
        {
            string value = Sitecore.Web.WebUtil.GetQueryString(key, defaultValue);
            return (string.IsNullOrEmpty(value))
                ? defaultValue
                : value;
        }

        public virtual string UrlEncode(string value)
        {
            return Sitecore.Web.WebUtil.UrlEncode(value);
        }
    }
}