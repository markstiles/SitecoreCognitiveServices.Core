﻿using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.AcademicSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge {
    public interface IAcademicSearchRepository
    {
        CalcHistogramResponse CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0);
        Task<CalcHistogramResponse> CalcHistogramAsync(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0);
        EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "");
        Task<EvaluateResponse> EvaluateAsync(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "");
        GraphSearchResponse GraphSearch(GraphSearchRequest request);
        Task<GraphSearchResponse> GraphSearchAsync(GraphSearchRequest request);
        InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest);
        Task<InterpretResponse> InterpretAsync(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest);
        double Similarity(string s1, string s2);
        Task<double> SimilarityAsync(string s1, string s2);
    }
}