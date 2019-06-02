using System;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Commands
{
    [Serializable]
    public class BaseCommand : Command
    {
        protected static readonly string idParam = "idValue";
        protected static readonly string heightParam = "heightValue";
        protected static readonly string widthParam = "widthValue";
        protected static readonly string languageParam = "language";

        protected Item ContextItem;
        protected string Id;
        protected string Db;
        protected string Language;

        protected readonly ISitecoreDataWrapper DataWrapper;

        public BaseCommand()
        {
            DataWrapper = DependencyResolver.Current.GetService<ISitecoreDataWrapper>();
        }

        public override void Execute(CommandContext context)
        {
            ContextItem = DataWrapper.ExtractItem(context);
            if (ContextItem == null)
                return;

            Id = ContextItem.ID.ToString();
            Db = Sitecore.Context.ContentDatabase.Name;
            Language = ContextItem.Language.Name;

            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }
    }
}