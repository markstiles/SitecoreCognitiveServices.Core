using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http.Exceptions
{
    public class ErrorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Error));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Error err = new Error();

            foreach (var property in jo.Properties())
            {
                switch (property.Name)
                {
                    case "error":
                    case "error_message":
                    case "message":
                        err.Message = property.Value.ToString();
                        break;
                    case "error_code":
                    case "code":
                        err.Code = (int)property.Value;
                        break;
                    case "help":
                        err.Help = property.Value.ToString();
                        break;
                    case "description":
                    case "code_description":
                        err.CodeDescription = property.Value.ToString();
                        break;
                    case "session_closed":
                        err.SessionClosed = (bool)property.Value;
                        break;
                    default:
                        break;
                }
            }

            return err;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}