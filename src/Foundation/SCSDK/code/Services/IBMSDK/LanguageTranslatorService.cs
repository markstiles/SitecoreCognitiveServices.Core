using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator;
using SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class LanguageTranslatorService : ILanguageTranslatorService
    {
        protected ILanguageTranslatorRepository LanguageTranslatorRepository;
        protected ILogWrapper Logger;

        public LanguageTranslatorService(
            ILanguageTranslatorRepository languageTranslatorRepository,
            ILogWrapper logger)
        {
            LanguageTranslatorRepository = languageTranslatorRepository;
            Logger = logger;
        }
        
        public TranslationResult Translate(TranslateRequest body)
        {
            try
            {
                var result = LanguageTranslatorRepository.Translate(body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.Translate failed", this, ex);
            }

            return null;
        }

        public IdentifiedLanguages Identify(string text)
        {
            try
            {
                var result = LanguageTranslatorRepository.Identify(text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.Identify failed", this, ex);
            }

            return null;
        }

        public IdentifiableLanguages ListIdentifiableLanguages()
        {
            try
            {
                var result = LanguageTranslatorRepository.ListIdentifiableLanguages();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.ListIdentifiableLanguages failed", this, ex);
            }

            return null;
        }

        public TranslationModel CreateModel(string baseModelId, string name = null, System.IO.Stream forcedGlossary = null, System.IO.Stream parallelCorpus = null, Stream monolingualCorpus = null)
        {
            try
            {
                var result = LanguageTranslatorRepository.CreateModel(baseModelId, name, forcedGlossary, parallelCorpus, monolingualCorpus);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.CreateModel failed", this, ex);
            }

            return null;
        }

        public DeleteModelResult DeleteModel(string modelId)
        {
            try
            {
                var result = LanguageTranslatorRepository.DeleteModel(modelId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.DeleteModel failed", this, ex);
            }

            return null;
        }

        public TranslationModel GetModel(string modelId)
        {
            try
            {
                var result = LanguageTranslatorRepository.GetModel(modelId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.GetModel failed", this, ex);
            }

            return null;
        }

        public TranslationModels ListModels(string source = null, string target = null, bool? defaultModels = null)
        {
            try
            {
                var result = LanguageTranslatorRepository.ListModels(source, target, defaultModels);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("LanguageTranslatorService.ListModels failed", this, ex);
            }

            return null;
        }
    }
}