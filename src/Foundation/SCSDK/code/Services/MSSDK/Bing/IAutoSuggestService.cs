using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public interface IAutoSuggestService
    {
        AutoSuggestResponse GetSuggestions(string text);
    }
}