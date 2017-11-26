using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors
    {
        void Save(InvalidCaseReportFromUnknownDataCollector caseReport);
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync();
    }
}
