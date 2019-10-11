using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Jobs;
using Sitecore.Security.Accounts;
using Sitecore.Security.Domains;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface ISitecoreDataWrapper
    {
        Database GetDatabase(string dbName);
        List<Database> GetDatabases();
        Database ContentDatabase { get; }
        Database ContextDatabase { get; }
        Language ContentLanguage { get; }
        Language ContextLanguage { get; }
        ID GetID(string itemId);
        Item GetItemByUri(string itemUri);
        Item GetItemByIdValue(string itemId, string database);
        Item GetItemById(ID itemId, string database);
        Item GetItemByPath(string itemPath, string database);
        Item CreateItem(ID parentId, ID templateId, string dbName, string itemName, Dictionary<ID, string> fieldNameValues);
        Item CreateItemFromBranch(ID parentId, ID branchId, string dbName, string itemName, Dictionary<ID, string> fieldNameValues);
        void UpdateFields(Item item, Dictionary<ID, string> fieldNameValues);
        void UpdateItemName(Item item, string newName);
        bool RemoveItem(string dbName, ID itemId);
        Item ExtractItem(CommandContext context);
        string GetFieldDimension(Item i, string fieldName, int minimum, int offset);
        IEnumerable<TemplateItem> GetBaseTemplates(Item i);
        IEnumerable<TemplateItem> GetBaseTemplates(TemplateItem t);
        IEnumerable<Language> GetLanguages(Database db);
        User ContextUser { get; }
        Domain ContextDomain { get; }
        string GetDateFieldValue(DateTime date);
        void SetJobPriority(ThreadPriority priority);
        void SetJobTotal(int total);
        void SetJobStatus(string message);
        void SetJobStatus(long currentLine);
        void SetJobProcessed(long currentLine);
        void SetJobState(JobState state);
    }

    public class SitecoreDataWrapper : ISitecoreDataWrapper
    {
        protected readonly ILogWrapper Logger;

        public SitecoreDataWrapper(ILogWrapper logger)
        {
            Logger = logger;
        }

        public virtual Database GetDatabase(string dbName) => Sitecore.Configuration.Factory.GetDatabase(dbName);

        public virtual List<Database> GetDatabases() => Sitecore.Configuration.Factory.GetDatabases();
        
        public virtual Database ContentDatabase => Sitecore.Context.ContentDatabase ?? ContextDatabase;

        public virtual Database ContextDatabase => Sitecore.Context.Database;

        public virtual Language ContentLanguage => Sitecore.Context.ContentLanguage;

        public virtual Language ContextLanguage => Sitecore.Context.Language;

        public virtual ID GetID(string itemId)
        {
            ID idObj;
            return (ID.TryParse(itemId, out idObj))
                ? idObj
                : ID.Null;
        }

        public virtual Item GetItemByUri(string itemUri)
        {
            //item uri format: sitecore://master/{04dad0fd-db66-4070-881f-17264ca257e1}?lang=en&ver=1
            string[] parts = itemUri
                .Replace("sitecore://", string.Empty)
                .Split(new [] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 1)
                return null;

            if (parts.Length < 2)
                return null;

            var guidParts = parts[1].Split(new [] { "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (guidParts.Length < 1)
                return null;
            
            return GetDatabase(parts[0]).GetItem(GetID(guidParts[0]));
        }

        public virtual Item GetItemByIdValue(string itemId, string database)
        {
            ID id = GetID(itemId);
            return GetItemById(id, database);
        }

        public virtual Item GetItemById(ID itemId, string database)
        {
            return itemId.IsNull ? null : GetDatabase(database)?.GetItem(itemId);
        }

        public virtual Item GetItemByPath(string itemPath, string database)
        {
            return GetDatabase(database).GetItem(itemPath);
        }

        public virtual Item CreateItem(ID parentId, ID templateId, string dbName, string itemName, Dictionary<ID, string> fieldNameValues)
        {
            var folder = GetItemById(parentId, dbName);
            if (folder == null)
                return null;

            Item templateItem = GetItemById(templateId, dbName);
            if (templateItem == null)
                return null;

            var validName = ItemUtil.ProposeValidItemName(itemName);
            Item newItem = folder.Add(validName, (TemplateItem)templateItem);
            if (newItem == null)
                return newItem;

            UpdateFields(newItem, fieldNameValues);

            return newItem;
        }

        public virtual Item CreateItemFromBranch(ID parentId, ID branchId, string dbName, string itemName, Dictionary<ID, string> fieldNameValues)
        {
            var folder = GetItemById(parentId, dbName);
            if (folder == null)
                return null;

            Item branchItem = GetItemById(branchId, dbName);
            if (branchItem == null)
                return null;

            var validName = ItemUtil.ProposeValidItemName(itemName);
            Item newItem = folder.Add(validName, (BranchItem)branchItem);
            if (newItem == null)
                return newItem;

            UpdateFields(newItem, fieldNameValues);

            return newItem;
        }

        public void UpdateItemName(Item item, string newName)
        {
            if (item == null || string.IsNullOrWhiteSpace(newName))
                return;

            using (new EditContext(item))
            {
                var validName = ItemUtil.ProposeValidItemName(newName);
                item.Name = validName;
            }
        }

        public bool RemoveItem(string dbName, ID itemId)
        {
            var item = GetItemById(itemId, dbName);
            if (item == null)
                return false;

            item.Delete();

            return true;
        }
        
        public virtual void UpdateFields(Item item, Dictionary<ID, string> fieldNameValues)
        {
            using (new EditContext(item, true, false))
            {
                foreach (KeyValuePair<ID, string> key in fieldNameValues)
                {
                    item.Fields[key.Key].Value = key.Value;
                }
            }
            item.Database.Caches.ItemCache.RemoveItem(item.ID);
        }

        public virtual Item ExtractItem(CommandContext context)
        {
            if (context == null)
                return null;

            if (!context.Items.Any())
                return null;

            return context.Items[0];
        }

        /// <summary>
        /// tries to parse a size value from the field on the item but falls back to minimum if it cannot. adds offset to the size if found.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="fieldName"></param>
        /// <param name="minimum"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public virtual string GetFieldDimension(Item i, string fieldName, int minimum, int offset)
        {
            if (i.Fields[fieldName] == null)
                return minimum.ToString();

            int size = minimum;
            if (!int.TryParse(i[fieldName], out size))
                return minimum.ToString();

            return (size > minimum)
                ? (size + offset).ToString()
                : minimum.ToString();
        }

        public virtual IEnumerable<TemplateItem> GetBaseTemplates(Item i) {
            return i.Template.BaseTemplates.SelectMany(GetBaseTemplates);
        }

        public virtual IEnumerable<TemplateItem> GetBaseTemplates(TemplateItem t) {

            if (t.ID.Guid.Equals(TemplateIDs.StandardTemplate.Guid))
                return new TemplateItem[0];

            return new[] { t }
                    .Concat(t.BaseTemplates.SelectMany(GetBaseTemplates));
        }
        
        public virtual IEnumerable<Language> GetLanguages(Database db)
        {
            return LanguageManager.GetLanguages(db).ToList();
        }

        public virtual User ContextUser => Sitecore.Context.User;

        public virtual Domain ContextDomain => Sitecore.Context.Domain;

        public string GetDateFieldValue(DateTime date)
        {
            return date.ToString("yyyyMMddTHHmmss");
        }

        public void SetJobPriority(ThreadPriority priority)
        {
            if (Context.Job == null)
                return;

            Context.Job.Options.Priority = priority;
        }

        public void SetJobTotal(int total)
        {
            if (Context.Job == null)
                return;

            Context.Job.Status.Total = total;
        }

        public void SetJobStatus(string message)
        {
            if (Context.Job == null)
                return;

            Context.Job.Status.Messages.Add(message);
        }

        public void SetJobStatus(long currentLine)
        {
            if (Context.Job == null)
                return;

            Context.Job.Status.Processed = currentLine;
            Context.Job.Status.Messages.Add($"Processed item {currentLine} of {Context.Job.Status.Total}");
        }

        public void SetJobProcessed(long currentLine)
        {
            if (Context.Job == null)
                return;

            Context.Job.Status.Processed = currentLine;
        }

        public void SetJobState(JobState state)
        {
            if (Context.Job == null)
                return;
            
            Context.Job.Status.State = state;
        }
    }
}