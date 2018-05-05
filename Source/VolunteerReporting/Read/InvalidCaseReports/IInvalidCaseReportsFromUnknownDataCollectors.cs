using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors
    {
        //TODO: Redo with repository pattern
        void Save(InvalidCaseReportFromUnknownDataCollector caseReport);
        Task SaveAsync(InvalidCaseReportFromUnknownDataCollector caseReport);
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync();
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);
        void Remove(Guid id);
        Task RemoveAsync(Guid id);
    }
}
