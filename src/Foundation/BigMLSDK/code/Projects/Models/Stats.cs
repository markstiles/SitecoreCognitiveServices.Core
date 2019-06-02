using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Projects.Models
{
    public class Stats
    {
        public Anomalies anomalies { get; set; }
        public AnomalyScores anomalyscores { get; set; }
        public BatchAnomalyScores batchanomalyscores { get; set; }
        public BatchCentroids batchcentroids { get; set; }
        public BatchPredictions batchpredictions { get; set; }
        public BatchTopicDistributions batchtopicdistributions { get; set; }
        public Centroids centroids { get; set; }
        public Clusters clusters { get; set; }
        public Configurations configurations { get; set; }
        public Correlations correlations { get; set; }
        public Datasets datasets { get; set; }
        public Ensembles ensembles { get; set; }
        public Evaluations evaluations { get; set; }
        public Models models { get; set; }
        public Predictions predictions { get; set; }
        public Sources sources { get; set; }
        public StatisticalTests statisticaltests { get; set; }
        public TopicModels topicmodels { get; set; }
        public TopicDistributions topicdistributions { get; set; }
    }
}