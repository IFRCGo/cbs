using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors
    {
        Task Save(CaseReportFromUnknownDataCollector anonymousCaseReport);
        Task Remove(Guid id);
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync();
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumber(string phoneNumber);
    }
}
