using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Import.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Model.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Session.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.View.Enums;
using SitecoreCognitiveServices.Foundation.NexSDK.View.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http
{
    internal static class ParameterExtensions
    {
        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ImportDetailQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("dataSetName", query?.DataSetName);
            builder.Add("requestedAfterDate", query?.RequestedAfterDate);
            builder.Add("requestedBeforeDate", query?.RequestedBeforeDate);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }


        internal static List<KeyValuePair<string, string>> ToParameters(this DataSetSummaryQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("partialName", query?.PartialName);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }


        internal static List<KeyValuePair<string, string>> ToParameters(this DataSetDataQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("startDate", query?.StartDate);
            builder.Add("endDate", query?.EndDate);
            if (query?.IncludedColumns?.Any() == true)
            {
                foreach (var col in query?.IncludedColumns)
                {
                    builder.Add("include", col);
                }
            }
            builder.Add(query?.Page);

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this DataSetRemoveCriteria criteria)
        {
            var builder = new ParameterBuilder();
            builder.Add("startDate", criteria?.StartDate);
            builder.Add("endDate", criteria?.EndDate);

            if ((criteria?.Options & DataSetDeleteOptions.CascadeSessions).GetValueOrDefault() != 0) builder.Add("cascade", "session");
            if ((criteria?.Options & DataSetDeleteOptions.CascadeViews).GetValueOrDefault() != 0) builder.Add("cascade", "view");
            if ((criteria?.Options & DataSetDeleteOptions.CascadeModels).GetValueOrDefault() != 0) builder.Add("cascade", "model");
            if ((criteria?.Options & DataSetDeleteOptions.CascadeVocabularies).GetValueOrDefault() != 0) builder.Add("cascade", "vocabulary");

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ModelSummaryQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("dataSourceName", query?.DataSourceName);
            builder.Add("createdAfterDate", query?.CreatedAfterDate);
            builder.Add("createdBeforeDate", query?.CreatedBeforeDate);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this SessionQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("dataSourceName", query?.DataSourceName);
            builder.Add("requestedAfterDate", query?.RequestedAfterDate);
            builder.Add("requestedBeforeDate", query?.RequestedBeforeDate);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this SessionRemoveCriteria criteria)
        {
            var builder = new ParameterBuilder();
            builder.Add("dataSourceName", criteria?.DataSourceName);
            builder.Add("requestedAfterDate", criteria?.RequestedAfterDate);
            builder.Add("requestedBeforeDate", criteria?.RequestedBeforeDate);
            builder.Add("type", criteria?.Type);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ViewQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("partialName", query?.PartialName);
            builder.Add("dataSetName", query?.DataSetName);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ViewDataQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("startDate", query?.StartDate);
            builder.Add("endDate", query?.EndDate);
            builder.Add(query?.Page);
            if (query?.Include?.Any() == true)
            {
                foreach (var col in query?.Include)
                {
                    builder.Add("include", col);
                }
            }

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ViewDeleteCriteria criteria)
        {
            var builder = new ParameterBuilder();

            if ((criteria?.Cascade & ViewCascadeOptions.CascadeSessions).GetValueOrDefault() != 0) builder.Add("cascade", "session");
            if ((criteria?.Cascade & ViewCascadeOptions.CascadeModels).GetValueOrDefault() != 0) builder.Add("cascade", "model");
            if ((criteria?.Cascade & ViewCascadeOptions.CascadeVocabularies).GetValueOrDefault() != 0) builder.Add("cascade", "vocabulary");

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ModelRemoveCriteria criteria)
        {
            var builder = new ParameterBuilder();
            builder.Add("modelId", criteria?.ModelId);
            builder.Add("dataSourceName", criteria?.DataSourceName);
            builder.Add("createdAfterDate", criteria?.CreatedAfterDate);
            builder.Add("createdBeforeDate", criteria?.CreatedBeforeDate);

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this VocabularyRemoveCriteria criteria)
        {
            var builder = new ParameterBuilder();
            builder.Add("vocabularyId", criteria?.VocabularyId);
            builder.Add("dataSource", criteria?.DataSourceName);
            builder.Add("createdFromSession", criteria?.CreatedFromSession);

            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this ChampionQueryOptions query)
        {
            var builder = new ParameterBuilder();
            builder.Add("predictionInterval", query?.PredictionInterval);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this SessionResultsQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("predictionInterval", query?.PredictionInterval);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }

        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this VocabulariesQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("dataSource", query?.DataSource);
            builder.Add("createdFromSession", query?.CreatedFromSession);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }


        internal static IEnumerable<KeyValuePair<string, string>> ToParameters(this VocabularyWordsQuery query)
        {
            var builder = new ParameterBuilder();
            builder.Add("type", query?.Type);
            builder.Add(query?.Page);
            return builder.GetParameters();
        }
    }
}