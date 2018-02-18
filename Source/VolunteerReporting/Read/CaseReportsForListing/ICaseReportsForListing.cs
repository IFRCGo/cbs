using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReportsForListing
{
    public interface ICaseReportsForListing
    {
        Task<IEnumerable<CaseReportForListing>> GetAllAsync();
        Task Save(CaseReportForListing caseReport);
        Task Remove(Guid id);
    }
}