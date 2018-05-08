using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public class CaseReportsForListing : GenericReadModelRepositoryFor<CaseReportForListing, Guid>,
        ICaseReportsForListing
    {
        public CaseReportsForListing(IMongoDatabase database)
            : base(database, database.GetCollection<CaseReportForListing>("CaseReportForListing"))
        {
        }

        public IEnumerable<CaseReportForListing> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public async Task<IEnumerable<CaseReportForListing>> GetAllAsync()
        {
            var filter = Builders<CaseReportForListing>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Save(new CaseReportForListing(caseReportId)
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


            });
        }

        public void SaveInvalidReport(Guid caseReportId, DataCollector dataCollector, string message, string origin, double latitude,
            double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            TODO_IMPLEMENT_ME();
        }

        public void SaveCaseReportFromUnknownDataCollector(Guid caseReportId, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            TODO_IMPLEMENT_ME();
        }

        public void SaveCaseReport(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message,
            string origin, double latitude, double longitude, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            TODO_IMPLEMENT_ME();
        }

        public Task SaveInvalidReportFromUnknownDataCollectorAsync(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            return TODO_IMPLEMENT_ME;
        }

        public Task SaveInvalidReportAsync(Guid caseReportId, DataCollector dataCollector, string message, string origin,
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            return TODO_IMPLEMENT_ME;
        }

        public Task SaveCaseReportFromUnknownDataCollectorAsync(Guid caseReportId, HealthRisk healthRisk, string message,
            string origin, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            return TODO_IMPLEMENT_ME;
        }

        public Task SaveCaseReportAsync(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message,
            string origin, double latitude, double longitude, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp)
        {
            return TODO_IMPLEMENT_ME;
        }
    }
}
