using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public class MediaWrapper : IMediaWrapper
    {
        #region Constructor
        
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ILogWrapper Logger;

        public MediaWrapper(
            ISitecoreDataWrapper dataWrapper,
            ILogWrapper logger)
        {
            DataWrapper = dataWrapper;
            Logger = logger;
        }

        #endregion

        public string GetFilePath(HttpRequestBase request, string fileName)
        {
            string path = fileName.Replace("/", @"\").Replace(@"\", "\\");
            string filePath = $"{request.PhysicalApplicationPath}{path}";
            string invalid = new string(Path.GetInvalidPathChars());

            //strip bad chars
            foreach (char c in invalid)
                if (filePath.Contains(c))
                    filePath = filePath.Replace(c.ToString(), "");

            return filePath;
        }

        public bool WriteBytesToFile(byte[] content, string filePath)
        {
            try
            {
                using (var stream = new MemoryStream(content))
                {
                    using (var image = System.Drawing.Image.FromStream(stream, false, false))
                    {
                        image.Save(filePath, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        
        public MediaItem UploadImageFile(string filePath, string newItemPath, string db)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);

            MediaItem mediaItem;
            using (MemoryStream stream2 = new MemoryStream())
            {
                file.CopyTo(stream2);

                // Create the options
                MediaCreatorOptions options = new MediaCreatorOptions
                {
                    FileBased = false,
                    IncludeExtensionInItemName = false,
                    OverwriteExisting = true,
                    Versioned = false,
                    Destination = newItemPath,
                    Database = Sitecore.Configuration.Factory.GetDatabase(db)
                };
                stream2.Flush();
                // upload to sitecore
                MediaCreator creator = new MediaCreator();
                mediaItem = creator.CreateFromStream(stream2, filePath, options);
            }

            return mediaItem;
        }
        
        /// <summary>
        /// Checks if both in the media library and not a folder
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public virtual bool IsMediaFile(Item i)
        {
            var bases = DataWrapper.GetBaseTemplates(i).ToList();

            return bases
                .Any(a =>
                    a.ID.Guid.Equals(TemplateIDs.UnversionedFile.Guid)
                    || a.ID.Guid.Equals(TemplateIDs.VersionedFile.Guid));
        }

        public virtual bool IsMediaFile(ID templateId, string database)
        {
            TemplateItem templateItem = DataWrapper.GetItemById(templateId, database);
            var bases = templateItem.BaseTemplates.SelectMany(DataWrapper.GetBaseTemplates);

            return bases
                .Any(a =>
                    a.ID.Guid.Equals(TemplateIDs.UnversionedFile.Guid)
                    || a.ID.Guid.Equals(TemplateIDs.VersionedFile.Guid));
        }

        public virtual bool IsMediaFolder(Item i)
        {
            return i.ID.Guid.Equals(Sitecore.ItemIDs.MediaLibraryRoot.Guid) || (i.Paths.IsMediaItem && !IsMediaFile(i));
        }

        public virtual void SetImageAlt(MediaItem mediaItem, string altDescription)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (new SecurityDisabler())
            {
                using (new EventDisabler())
                {
                    using (new EditContext(mediaItem))
                    {
                        try
                        {
                            mediaItem.Alt = altDescription;
                            mediaItem.Database.Caches.ItemCache.RemoveItem(mediaItem.ID);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Set Image Alt: " + ex.Message, this, ex);
                        }
                    }
                }
            }
        }

        public virtual IEnumerable<MediaItem> GetMediaFileDescendents(string id, string db)
        {

            Item item = DataWrapper.GetItemByIdValue(id, db);
            if (item == null)
                return new MediaItem[0];

            return item
                .Axes
                .GetDescendants()
                .Where(IsMediaFile)
                .Select(a => new MediaItem(a))
                .ToList();
        }

        public int GetImageHeight(Item item)
        {
            int height = 0;
            var heightField = item.Fields["Height"];
            if (heightField == null)
                return height;

            return int.TryParse(heightField.Value, out height)
                ? height
                : 0;
        }

        public int GetImageWidth(Item item)
        {
            int width = 0;
            var widthField = item.Fields["Width"];
            if (widthField == null)
                return width;

            return int.TryParse(widthField.Value, out width)
                ? width
                : 0;
        }
    }
}