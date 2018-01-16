using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors
    {
        void Save(CaseReportFromUnknownDataCollector anonymousCaseReport);
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync();
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumber(string phoneNumber);
    }
}
