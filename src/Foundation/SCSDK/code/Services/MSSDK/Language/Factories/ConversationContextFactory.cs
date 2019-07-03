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
        IConversationContext Create(Guid appId, string acceptText, string clearText, string confirmText, string frustratedIntentName, string message, ItemContextParameters parameters, LuisResult result, string quitIntentName);
    }

    public class ConversationContextFactory : IConversationContextFactory
    {
        protected readonly IServiceProvider Provider;

        public ConversationContextFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IConversationContext Create(Guid appId, string acceptText, string clearText, string confirmText, 
            string frustratedIntentName, string message, ItemContextParameters parameters, LuisResult result, string quitIntentName)
        {
            var convo = Provider.GetService<IConversationContext>();
            convo.AppId = appId;
            convo.AcceptText = acceptText;
            convo.ClearText = clearText;
            convo.ConfirmText = confirmText;
            convo.FrustratedIntentName = frustratedIntentName;
            convo.Message = message;
            convo.Parameters = parameters;
            convo.Result = result;
            convo.QuitIntentName = quitIntentName;
            
            return convo;
        }
    }
}