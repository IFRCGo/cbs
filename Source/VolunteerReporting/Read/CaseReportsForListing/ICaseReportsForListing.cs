using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Infrastructure.Read.MongoDb;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public interface ICaseReportsForListing : IExtendedReadModelRepositoryFor<CaseReportForListing>
    {
        IEnumerable<CaseReportForListing> GetAll();
        Task<IEnumerable<CaseReportForListing>> GetAllAsync();

        void SaveInvalidReportFromUnknownDataCollector(CaseReportId caseReportId, string message, string origin, 
            IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveInvalidReport(CaseReportId caseReportId, DataCollector dataCollector, string message, string origin, 
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveCaseReportFromUnknownDataCollector(CaseReportId caseReportId, HealthRisk healthRisk, string message, string origin, 
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        void SaveCaseReport(CaseReportId caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, 
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        Task SaveInvalidReportFromUnknownDataCollectorAsync(CaseReportId caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveInvalidReportAsync(CaseReportId caseReportId, DataCollector dataCollector, string message, string origin,
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveCaseReportFromUnknownDataCollectorAsync(CaseReportId caseReportId, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        Task SaveCaseReportAsync(CaseReportId caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);
    }
}