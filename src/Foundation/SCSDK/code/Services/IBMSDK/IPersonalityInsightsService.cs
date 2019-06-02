using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public interface IPersonalityInsightsService
    {
        /// <summary>
        /// Generates a personality profile based on input text. Derives personality insights for up to 20 MB of input content written by an author, though the service requires much less text to produce an accurate profile; for more information, see [Providing sufficient input](http://www.ibm.com/watson/developercloud/doc/personality-insights/basics.html#overviewGuidelines). Accepts input in Arabic, English, Japanese, Korean, or Spanish and produces output in one of eleven languages. Provide plain text, HTML, or JSON content, and receive results in JSON or CSV format.
        /// </summary>
        /// <param name="content">A maximum of 20 MB of content to analyze, though the service requires much less text; for more information, see [Providing sufficient input](http://www.ibm.com/watson/developercloud/doc/personality-insights/basics.html#overviewGuidelines). A JSON request must conform to the `Content` model.</param>
        /// <param name="contentType">The type of the input: application/json, text/html, or text/plain. A character encoding can be specified by including a `charset` parameter. For example, 'text/html;charset=utf-8'.</param>
        /// <param name="contentLanguage">The language of the input text for the request: Arabic, English, Japanese, Korean, or Spanish. Regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. The effect of the `contentLanguage` header depends on the `Content-Type` header. When `Content-Type` is `text/plain` or `text/html`, `contentLanguage` is the only way to specify the language. When `Content-Type` is `application/json`, `contentLanguage` overrides a language specified with the `language` parameter of a `ContentItem` object, and content items that specify a different language are ignored; omit this header to base the language on the specification of the content items. You can specify any combination of languages for `contentLanguage` and `Accept-Language`. (optional, default to en)</param>
        /// <param name="acceptLanguage">The desired language of the response. For two-character arguments, regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. You can specify any combination of languages for the input and response content. (optional, default to en)</param>
        /// <param name="rawScores">If `true`, a raw score in addition to a normalized percentile is returned for each characteristic; raw scores are not compared with a sample population. If `false` (the default), only normalized percentiles are returned. (optional, default to false)</param>
        /// <param name="csvHeaders">If `true`, column labels are returned with a CSV response; if `false` (the default), they are not. Applies only when the `Accept` header is set to `text/csv`. (optional, default to false)</param>
        /// <param name="consumptionPreferences">If `true`, information about consumption preferences is returned with the results; if `false` (the default), the response does not include the information. (optional, default to false)</param>
        /// <returns><see cref="Profile" />Profile</returns>
        Profile Profile(Content content, string contentType, string contentLanguage = null, string acceptLanguage = null, bool? rawScores = null, bool? csvHeaders = null, bool? consumptionPreferences = null);
    }
}