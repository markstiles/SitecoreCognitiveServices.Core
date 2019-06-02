using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Models
{
    /// <summary>
    /// A dataset is a structured version of a source where each field has been
    /// processed and serialized according to its type.
    /// The complete and updated reference with all available parameters is in
    /// our <a href="https://bigml.com/api/datasets">documentation</a>
    /// website.
    /// </summary>
    public partial class DataSet
    {
        public int columns { get; set; }
        public IDictionary<string, Field> fields
        {
            get
            {
                var dictionary = new Dictionary<string, Field>();
                foreach (var kv in Object.fields)
                {
                    dictionary[kv.Name] = new Field(kv.Value);
                }
                return dictionary;
            }
        }

        /// <summary>
        /// The dataset's locale.
        /// </summary>
       public string Locale
        {
            get { return Object.locale; }
        }

        /// <summary>
        /// The name of the dataset as your provided or based on the name of the source by default.
        /// </summary>
        public string Name
        {
            get { return Object.name; }
        }

        /// <summary>
        /// The current number of models that use this dataset.
        /// </summary>
        public int NumberOfModels
        {
            get { return Object.number_of_models; }
        }

        /// <summary>
        /// The current number of ensembles that use this dataset.
        /// </summary>
        public int NumberOfEnsembles
        {
            get { return Object.number_of_ensembles; }
        }

        /// <summary>
        /// The current number of logistic regresssions that use this dataset.
        /// </summary>
        public int NumberOfLogisticRegressions
        {
            get { return Object.number_of_logisticregressions; }
        }

        /// <summary>
        /// The current number of time series that use this dataset.
        /// </summary>
        public int NumberOfTimeSeries
        {
            get { return Object.number_of_timeseries; }
        }

        /// <summary>
        /// The current number of clusters that use this dataset.
        /// </summary>
        public int NumberOfClusters
        {
            get { return Object.number_of_clusters; }
        }

        /// <summary>
        /// The current number of anomaly detectors (anomalies) that use this dataset.
        /// </summary>
        public int NumberOfAnomalies
        {
            get { return Object.number_of_anomalies; }
        }

        /// <summary>
        /// The current number of association discoveries (associations) that use this dataset.
        /// </summary>
        public int NumberOfAssociations
        {
            get { return Object.number_of_associations; }
        }

        /// <summary>
        /// The current number of topic models that use this dataset.
        /// </summary>
        public int NumberOfTopicModels
        {
            get { return Object.number_of_topicmodels; }
        }

        /// <summary>
        /// The current number of predictions that use this dataset.
        /// </summary>
        public int NumberOfPredictions
        {
            get { return Object.number_of_predictions; }
        }

        /// <summary>
        /// The total number of rows in the dataset.
        /// </summary>
        public int Rows
        {
            get { return Object.rows; }
        }

        /// <summary>
        /// The number of bytes of the source that were used to create this dataset.
        /// </summary>
        public int Size
        {
            get { return Object.size; }
        }

        /// <summary>
        /// The source/id that was used to build the dataset.
        /// </summary>
        public string Source
        {
            get { return Object.source; }
        }

        /// <summary>
        /// Whether the source is still available or has been deleted.
        /// </summary>
        public bool SourceStatus
        {
            get { return Object.source_status; }
        }

        /// <summary>
        /// A description of the status of the dataset.
        /// </summary>
        public Status StatusMessage
        {
            get{ return new Status(Object.status); }
        }
    }
}