using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Enums
{
    public static class EnumStatics {

        public static string MemberAttrValue<T>(this T enumVal) where T : IConvertible
        {
            var enumType = typeof(T);
            var memInfo = enumType.GetMember(enumVal.ToString());
            var attr = memInfo.FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            return attr?.Value;
        }

    }
}