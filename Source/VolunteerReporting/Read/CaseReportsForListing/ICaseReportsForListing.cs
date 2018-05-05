using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.CaseReportsForListing
{
    public interface ICaseReportsForListing
    {
        IEnumerable<CaseReportForListing> GetAll();
        Task<IEnumerable<CaseReportForListing>> GetAllAsync();
        //TODO: Remove this evil abomination

        Task<IEnumerable<CaseReportForListing>> GetLimitAsync(int limit, Boolean last);
        void Save(CaseReportForListing caseReport);
        Task SaveAsync(CaseReportForListing caseReport);

        void Remove(Guid id);
        Task RemoveAsync(Guid id);
    }
}