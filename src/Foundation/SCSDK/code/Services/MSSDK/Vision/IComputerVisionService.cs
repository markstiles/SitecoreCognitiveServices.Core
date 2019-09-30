﻿using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision;
using System.Collections.Generic;
using System.IO;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public interface IComputerVisionService
    {
        List<string> ValidateVisionImage(MediaItem image);
        List<string> ValidateVisionImage(MediaItem image, int newHeight, int newWidth);
        Adult GetAdultAnalysis(string imageUrl);
        Adult GetAdultAnalysis(Stream imageStream);
        Category[] GetCategoryAnalysis(string imageUrl);
        Category[] GetCategoryAnalysis(Stream imageStream);
        Color GetColorAnalysis(string imageUrl);
        Color GetColorAnalysis(Stream imageStream);
        SimpleFace[] GetFaceAnalysis(string imageUrl);
        SimpleFace[] GetFaceAnalysis(Stream imageStream);
        AnalysisResult GetFullAnalysis(string imageUrl);
        AnalysisResult GetFullAnalysis(Stream imageStream);
        ImageType GetImageTypeAnalysis(string imageUrl);
        ImageType GetImageTypeAnalysis(Stream imageStream);
        AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null, IEnumerable<string> details = null);
        AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null, IEnumerable<string> details = null);
        AnalysisInDomainResult AnalyzeImageInDomain(string url, Model model);
        AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, Model model);
        AnalysisInDomainResult AnalyzeImageInDomain(string url, string modelName);
        AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, string modelName);
        ModelResult ListModels();
        Description Describe(string url, int maxCandidates = 1);
        Description Describe(Stream imageStream, int maxCandidates = 1);
        byte[] GetThumbnail(string url, int width, int height, bool smartCropping = true);
        byte[] GetThumbnail(Stream stream, int width, int height, bool smartCropping = true);
        OcrResults RecognizeText(Stream stream, string language = "unk", bool detectOrientation = true);
        OcrResults RecognizeText(string imageUrl, string language = "unk", bool detectOrientation = true);
        Tag[] GetTags(string url);
        Tag[] GetTags(Stream imageStream);
    }
}