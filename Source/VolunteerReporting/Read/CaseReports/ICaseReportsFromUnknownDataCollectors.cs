using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors
    {
        void Save(CaseReportFromUnknownDataCollector caseReport);
        Task SaveAsync(CaseReportFromUnknownDataCollector anonymousCaseReport);

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        IEnumerable<CaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync();

        IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);
    }
}
