using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors : IExtendedReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector>
    {
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync();
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);


        void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        Task SaveInvalidReportFromUnknownDataCollectorAsync(Guid caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
