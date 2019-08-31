using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories
{
    public interface IConversationFactory
    {
        IConversation Create(LuisResult result, IIntent intent);
    }

    public class ConversationFactory : IConversationFactory
    {
        protected readonly IServiceProvider Provider;

        public ConversationFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IConversation Create(LuisResult result, IIntent intent)
        {
            var convo = Provider.GetService<IConversation>();
            convo.Result = result;
            convo.Intent = intent;
            convo.Data = new Dictionary<string, ParameterData>();

            return convo;
        }
    }
}