using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public interface INaturalLanguageClassifierService
    {
        ClassifyResponse Classify(string classifier_id, string text);
        Classifier CreateClassifier(string classifier_id, string training_data_language, string training_data);
        void DeleteClassifier(string classifier_id);
        Classifier GetClassifierInfo(string classifier_id);
        ListClassifierResponse ListClassifiers();
    }
}