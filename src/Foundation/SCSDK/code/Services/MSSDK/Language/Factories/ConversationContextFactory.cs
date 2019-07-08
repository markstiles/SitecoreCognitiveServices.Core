using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories
{
    public interface IConversationContextFactory
    {
        IConversationContext Create(Guid appId, string clearText, string confirmText, string yesIntentName, string noIntentName, string frustratedIntentName, string quitIntentName, ItemContextParameters parameters, LuisResult result);
    }

    public class ConversationContextFactory : IConversationContextFactory
    {
        protected readonly IServiceProvider Provider;

        public ConversationContextFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IConversationContext Create(Guid appId, string clearText, string confirmText, string yesIntentName, string noIntentName, string frustratedIntentName, string quitIntentName, ItemContextParameters parameters, LuisResult result)
        {
            var convo = Provider.GetService<IConversationContext>();
            convo.AppId = appId;
            convo.ClearText = clearText;
            convo.ConfirmText = confirmText;
            convo.YesIntentName = yesIntentName;
            convo.NoIntentName = noIntentName;
            convo.FrustratedIntentName = frustratedIntentName;
            convo.QuitIntentName = quitIntentName;
            convo.Parameters = parameters;
            convo.Result = result;
            
            return convo;
        }
    }
}