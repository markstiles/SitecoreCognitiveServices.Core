using SitecoreCognitiveServices.Foundation.NexSDK.View.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class ViewDeleteCriteria
    {
        public ViewDeleteCriteria(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the View to delete
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Options for cascading the delete.<br/>
        /// When cascade=sessions, also deletes sessions associated with the view
        /// </summary>
        public ViewCascadeOptions? Cascade { get; set; }
    }
}