﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    /// <summary>
    /// A batch anomaly score provides an easy way to compute an anomaly score
    /// for each instance in a dataset in only one request. To create a new
    /// batch anomaly score you need an anomaly/id and a dataset/id.
    /// The complete and updated reference with all available parameters is in
    /// our <a href="https://bigml.com/api/batchanomalyscores">
    /// documentation</a> website.
    /// </summary>
    public partial class BatchAnomalyScore : Response
    {

        /// <summary>
        /// The name of the batch score as your provided or based on the name
        /// of the anomaly by default.
        /// </summary>
        public string Name
        {
            get { return Object.name; }
        }


        /// <summary>
        /// The anomaly/id that was used to build the batch score.
        /// </summary>
        public string Anomaly
        {
            get { return Object.anomaly; }
        }



        /// <summary>
        /// Whether the anomaly is still available or has been deleted.
        /// </summary>
        public bool AnomalyStatus
        {
            get { return Object.anomaly_status; }
        }


        /// <summary>
        /// A description of the status of the Batch Score.
        /// It includes a code, a message, and some extra information.
        /// </summary>
        public Status StatusMessage
        {
            get { return new Status(Object.status); }
        }
    }
}
