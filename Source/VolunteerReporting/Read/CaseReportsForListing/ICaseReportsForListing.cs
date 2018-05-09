using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public interface ICaseReportsForListing : IExtendedReadModelRepositoryFor<CaseReportForListing>
    {
        IEnumerable<CaseReportForListing> GetAll();
        Task<IEnumerable<CaseReportForListing>> GetAllAsync();

        void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin, 
            IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveInvalidReport(Guid caseReportId, DataCollector dataCollector, string message, string origin, 
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveCaseReportFromUnknownDataCollector(Guid caseReportId, HealthRisk healthRisk, string message, string origin, 
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        void SaveCaseReport(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, 
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        Task SaveInvalidReportFromUnknownDataCollectorAsync(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveInvalidReportAsync(Guid caseReportId, DataCollector dataCollector, string message, string origin,
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveCaseReportFromUnknownDataCollectorAsync(Guid caseReportId, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        Task SaveCaseReportAsync(Guid caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);
    }
}