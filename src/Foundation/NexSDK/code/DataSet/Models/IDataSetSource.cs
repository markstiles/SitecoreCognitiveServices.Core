namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    /// <summary>
    /// A source of data to be used when creating a dataset.  Use the DataSet.From to get instances of me
    /// </summary>
    public interface IDataSetSource
    {
        /// <summary>
        /// The name of the DataSet
        /// </summary>
        string Name { get; }
    }
}