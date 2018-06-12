using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportsFromUnknownDataCollectors : ExtendedReadModelRepositoryFor<InvalidCaseReportFromUnknownDataCollector>,
        IInvalidCaseReportsFromUnknownDataCollectors
    {
        public InvalidCaseReportsFromUnknownDataCollectors(IMongoDatabase database)
            : base(database, database.GetCollection<InvalidCaseReportFromUnknownDataCollector>("InvalidCaseReportFromUnknownDataCollector"))
        {
        }

        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetAll()
        {
            return GetMany(_ => true);
        }
        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> GetByPhoneNumber(string phoneNumber)
        {
            return GetMany(r => r.PhoneNumber == phoneNumber);
        }

        public void SaveInvalidReportFromUnknownDataCollector(Guid caseReportId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new InvalidCaseReportFromUnknownDataCollector(caseReportId)
            {
                Message = message,
                ParsingErrorMessage = errorMessages,
                PhoneNumber = origin,
                Timestamp = timestamp
            });
        }
    }
}
