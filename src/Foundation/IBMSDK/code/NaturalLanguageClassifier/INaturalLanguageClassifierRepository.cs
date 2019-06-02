using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier
{
    public interface INaturalLanguageClassifierRepository
    {
        Classifier CreateClassifier(string classifier_name, string training_data_language, string training_data);
        ListClassifierResponse ListClassifiers();
        Classifier GetClassifierInfo(string classifier_id);
        void DeleteClassifier(string classifier_id);
        ClassifyResponse Classify(string classifier_id, string text);
        ClassifyCollectionResponse Classify(string classifier_id, List<string> textList);
    }
}