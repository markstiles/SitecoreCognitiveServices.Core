﻿using BigML.Meta;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    using Meta.Key;

    public partial class AssociationSet
    {
        /// <summary>
        /// Orderable properties for Association Sets
        /// </summary>
        public class Orderable : Orderable<AssociationSet>
        {   
            /// <summary>
            /// The dataset/id that was used to build the association discovery.
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