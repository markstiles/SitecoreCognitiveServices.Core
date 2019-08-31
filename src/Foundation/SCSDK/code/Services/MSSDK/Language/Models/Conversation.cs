using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public class Conversation : IConversation
    {
        public virtual bool IsEnded { get; set; }
        public virtual bool IsConfirmed { get; set; }
        public virtual IIntent Intent { get; set; }
        public virtual LuisResult Result { get; set; }
        /// <summary>
        /// the stored parameter objects converted from the user input (ie: the web database object)
        /// </summary>
        public virtual Dictionary<string, ParameterData> Data { get; set; }
    }
}