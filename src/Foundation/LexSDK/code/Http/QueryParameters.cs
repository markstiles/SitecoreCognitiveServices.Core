using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Http
{
    public class QueryParameter
    {
        public QueryParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }
}
