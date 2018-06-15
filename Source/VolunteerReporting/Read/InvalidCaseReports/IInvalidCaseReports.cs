using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Concepts.CaseReport;
using Concepts.DataCollector;
using Infrastructure.Read.MongoDb;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReports : IExtendedReadModelRepositoryFor<InvalidCaseReport>
    {
        IEnumerable<InvalidCaseReport> GetAll();
        Task<IEnumerable<InvalidCaseReport>> GetAllAsync();


        void SaveInvalidReport(CaseReportId caseReportId, DataCollectorId dataCollectorId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
        Task SaveInvalidReportAsync(CaseReportId caseReportId, DataCollectorId dataCollectorId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
