﻿using BigML.Meta;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Evaluation
    {
        /// <summary>
        /// Filterable properties for Evaluations
        /// </summary>
        public class Filterable : Filterable<Evaluation>
        {
            /// <summary>
            /// The dataset/id that was used to build the dataset.
            /// </summary>
            public String DataSet
            {
                get { return Object.dataset; }
            }

            /// <summary>
            /// Whether the dataset is still available or has been deleted.
            /// </summary>
            public Bool DataSetStatus
            {
                get { return Object.dataset_status; }
            }
        }
    }
}
