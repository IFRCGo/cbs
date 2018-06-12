using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors : IExtendedReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector>
    {
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll();
        IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber);


        void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin, IEnumerable<string> errorMessages, DateTimeOffset timestamp);
    }
}
