using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources
{
    public interface ISourceRepository
    {
        Source CreateSource(CreateSourceRemoteApiModel model);
        Source CreateSource(CreateSourceDataApiModel model);
        Source CreateSource(CreateSourceSyntheticApiModel model);
        Source GetSource(string sourceId);
        List<Source> GetSources();
        bool DeleteSource(string sourceId);
    }
}