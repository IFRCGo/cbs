using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReports : IExtendedReadModelRepositoryFor<InvalidCaseReport>
    {
        IEnumerable<InvalidCaseReport> GetAll();
        Task<IEnumerable<InvalidCaseReport>> GetAllAsync();


        void SaveInvalidReport(Guid caseReportId, Guid dataCollectorId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
        Task SaveInvalidReportAsync(Guid caseReportId, Guid dataCollectorId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
