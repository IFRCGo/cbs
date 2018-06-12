using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReports : ExtendedReadModelRepositoryFor<InvalidCaseReport>, 
        IInvalidCaseReports
    {
        public InvalidCaseReports(IMongoDatabase database)
            : base(database, database.GetCollection<InvalidCaseReport>("InvalidCaseReport"))
        {
        }


        public IEnumerable<InvalidCaseReport> GetAll()
        {
            return GetMany(_ => true);
        }
        public void SaveInvalidReport(Guid caseReportId, Guid dataCollectorId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Update(new InvalidCaseReport(caseReportId)
            {
                DataCollectorId = dataCollectorId,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp
            });
        }
    }
}
