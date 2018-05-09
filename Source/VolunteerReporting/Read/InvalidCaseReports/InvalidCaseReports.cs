using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;

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

        public Task<IEnumerable<InvalidCaseReport>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public void SaveInvalidReport(Guid caseReportId, Guid dataCollectorId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            Save(new InvalidCaseReport(caseReportId)
            {
                DataCollectorId = dataCollectorId,
                Message = message,
                Origin = origin,
                ParsingErrorMessage = errorMessages,
                Timestamp = timestamp
            });
        }

        public Task SaveInvalidReportAsync(Guid caseReportId, Guid dataCollectorId, string message, string origin,
            IEnumerable<string> errorMessages, DateTimeOffset timestamp)
        {
            return SaveAsync(new InvalidCaseReport(caseReportId)
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
