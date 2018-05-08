using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors : IGenericReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector, Guid>
    {
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync();
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);


        void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveInvalidReportFromUnknownDataCollectorAsync(Guid caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
