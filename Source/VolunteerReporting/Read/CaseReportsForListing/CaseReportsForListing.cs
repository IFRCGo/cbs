using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Infrastructure.Read.MongoDb;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public class CaseReportsForListing : ExtendedReadModelRepositoryFor<CaseReportForListing>,
        ICaseReportsForListing
    {
        public CaseReportsForListing(IMongoDatabase database)
            : base(database, database.GetCollection<CaseReportForListing>("CaseReportForListing"))
        {
        }

        public IEnumerable<CaseReportForListing> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<CaseReportForListing>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,
                HealthRiskId = null,
                HealthRisk = "Unknown",
                Location = Location.NotSet,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null
            });
        }

        public void SaveInvalidReport(Guid caseReportId, DataCollector dataCollector, string message, string origin, double latitude,
            double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorId = dataCollector.Id,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorVillage = dataCollector.Village,

                HealthRiskId = null,
                HealthRisk = "Unknown",

                Location = dataCollector.Location,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp
                
            });
        }

        public void SaveCaseReportFromUnknownDataCollector(Guid caseReportId, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            Update(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.UnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,

                HealthRisk = healthRisk.Name,
                HealthRiskId = healthRisk.Id,

                Location = Location.NotSet,
                Message = message,
                Origin = origin,
                Timestamp = timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null
                
            });
        }

        public void SaveCaseReport(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message,
            string origin, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            Update(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.Success,
                Message = message,
                DataCollectorId = dataCollector.Id,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorVillage = dataCollector.Village,
                Location = dataCollector.Location,
                Origin = origin,

                HealthRiskId = healthRisk.Id,
                HealthRisk = healthRisk.Name,

                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder,
                
                Timestamp = timestamp
            });
        }

        public Task SaveInvalidReportFromUnknownDataCollectorAsync(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            return UpdateAsync(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,
                HealthRiskId = null,
                HealthRisk = "Unknown",
                Location = Location.NotSet,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null
            });
        }

        public Task SaveInvalidReportAsync(Guid caseReportId, DataCollector dataCollector, string message, string origin,
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            return UpdateAsync(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorId = dataCollector.Id,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorVillage = dataCollector.Village,

                HealthRiskId = null,
                HealthRisk = "Unknown",

                Location = dataCollector.Location,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp

            });
        }

        public Task SaveCaseReportFromUnknownDataCollectorAsync(Guid caseReportId, HealthRisk healthRisk, string message,
            string origin, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            return UpdateAsync(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.UnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,

                HealthRisk = healthRisk.Name,
                HealthRiskId = healthRisk.Id,

                Location = Location.NotSet,
                Message = message,
                Origin = origin,
                Timestamp = timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null

            });
        }

        public Task SaveCaseReportAsync(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message,
            string origin, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            return UpdateAsync(new CaseReportForListing(caseReportId)
            {
                Status = CaseReportStatus.Success,
                Message = message,
                DataCollectorId = dataCollector.Id,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorVillage = dataCollector.Village,
                Location = dataCollector.Location,
                Origin = origin,

                HealthRiskId = healthRisk.Id,
                HealthRisk = healthRisk.Name,

                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder,

                Timestamp = timestamp
            });
        }
    }
}
