using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReports
{
    public interface ICaseReportsFromUnknownDataCollectors : IExtendedReadModelRepositoryFor<CaseReportFromUnknownDataCollector>
    {
        IEnumerable<CaseReportFromUnknownDataCollector> GetAll();
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetAllAsync();

        IEnumerable<CaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<CaseReportFromUnknownDataCollector>> GetByPhoneNumberAsync(string phoneNumber);
    }
}
