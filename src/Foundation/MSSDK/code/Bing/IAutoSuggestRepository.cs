using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing {
    public interface IAutoSuggestRepository
    {
        AutoSuggestResponse GetSuggestions(string text);
        Task<AutoSuggestResponse> GetSuggestionsAsync(string text);
    }
}