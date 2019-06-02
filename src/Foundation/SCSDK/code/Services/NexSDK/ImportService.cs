using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Import;
using SitecoreCognitiveServices.Foundation.NexSDK.Import.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class ImportService : IImportService
    {
        protected readonly IImportRepository ImportRepository;
        protected readonly ILogWrapper Logger;
        
        public ImportService(
            IImportRepository importRepository,
            ILogWrapper logger)
        {
            ImportRepository = importRepository;
            Logger = logger;
        }

        public async Task<ImportDetailList> List(ImportDetailQuery query = null)
        {
            try
            {
                var result = await ImportRepository.List(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.GetAccountBalance failed", this, ex);
            }

            return null;
        }

        public async Task<ImportDetail> Get(Guid id)
        {
            try
            {
                var result = await ImportRepository.Get(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.Get failed", this, ex);
            }

            return null;
        }

        public async Task<ImportDetail> ImportFromS3(ImportFromS3Request detail)
        {
            try
            {
                var result = await ImportRepository.ImportFromS3(detail);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.ImportFromS3 failed", this, ex);
            }

            return null;
        }

        public async Task<ImportDetail> ImportFromUrl(ImportFromUrlRequest detail)
        {
            try
            {
                var result = await ImportRepository.ImportFromUrl(detail);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.ImportFromUrl failed", this, ex);
            }

            return null;
        }

        public async Task<ImportDetail> ImportFromAzure(ImportFromAzureRequest detail)
        {
            try
            {
                var result = await ImportRepository.ImportFromAzure(detail);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AccountService.ImportFromAzure failed", this, ex);
            }

            return null;
        }
    }
}