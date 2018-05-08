using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors : IGenericReadModelRepositoryFor<CaseReportFromUnknownDataCollector, Guid>
    {
        IEnumerable<CaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync();

        IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);
    }
}
