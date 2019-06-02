using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class Source
    {
        public int category { get; set; }
        public int code { get; set; }
        public string content_type { get; set; }
        public DateTime created { get; set; }
        public int credits { get; set; }
        public object configuration { get; set; }
        public bool configuration_status { get; set; }
        public string creator { get; set; }
        public string description { get; set; }
        public bool disable_datetime { get; set; }
        public Fields fields { get; set; }
        public FieldTypes field_types { get; set; }
        public FieldsMeta fields_meta { get; set; }
        public string file_name { get; set; }
        public ItemAnalysis item_analysis { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }
        public string name_options { get; set; }
        public int number_of_anomalies { get; set; }
        public int number_of_anomalyscores { get; set; }
        public int number_of_associations { get; set; }
        public int number_of_associationsets { get; set; }
        public int number_of_centroids { get; set; }
        public int number_of_clusters { get; set; }
        public int number_of_correlations { get; set; }
        public int number_of_datasets { get; set; }
        public int number_of_deepnets { get; set; }
        public int number_of_ensembles { get; set; }
        public int number_of_forecasts { get; set; }
        public int number_of_linearregressions { get; set; }
        public int number_of_logisticregressions { get; set; }
        public int number_of_models { get; set; }
        public int number_of_optimls { get; set; }
        public int number_of_pca { get; set; }
        public int number_of_predictions { get; set; }
        public int number_of_projections { get; set; }
        public int number_of_statisticaltests { get; set; }
        public int number_of_timeseries { get; set; }
        public int number_of_topicdistributions { get; set; }
        public int number_of_topicmodels { get; set; }
        public bool _private { get; set; }
        public string project { get; set; }
        public string remote { get; set; }
        public string resource { get; set; }
        public bool shared { get; set; }
        public int size { get; set; }
        public SourceParser source_parser { get; set; }
        public Status status { get; set; }
        public bool subscription { get; set; }
        public string[] tags { get; set; }
        public TermAnalysis term_analysis { get; set; }
        public int type { get; set; }
        public DateTime updated { get; set; }
    }
}