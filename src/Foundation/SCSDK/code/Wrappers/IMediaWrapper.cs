using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IMediaWrapper
    {
        string GetFilePath(HttpRequestBase request, string fileName);
        bool WriteBytesToFile(byte[] content, string filePath);
        MediaItem UploadImageFile(string filePath, string newItemPath, string db);
        bool IsMediaFile(Item i);
        bool IsMediaFile(ID templateId, string database);
        bool IsMediaFolder(Item i);
        void SetImageAlt(MediaItem mediaItem, string altDescription);
        IEnumerable<MediaItem> GetMediaFileDescendents(string id, string db);
        int GetImageHeight(Item item);
        int GetImageWidth(Item item);
    }
}