﻿using BigML.Meta;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Sample
    {
        /// <summary>
        /// Filterable properties for Sample
        /// </summary>
        public class Filterable : Filterable<Sample>
        {
            /// <summary>
            /// The dataset/id that was used to build the sample.
            /// </summary>
            public String Dataset
            {
                get { return Object.dataset; }
            }

            /// <summary>
            /// Whether the dataset is still available or has been deleted.
            /// </summary>
            public Bool DatasetStatus
            {
                get { return Object.dataset_status; }
            }
        }
    }
}
