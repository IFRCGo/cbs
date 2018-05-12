using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReport : IReadModel
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidCaseReport(Guid id) => Id = id;
    }

    public class InvalidCaseReportBsonClassMap : MongoDbClassMap<InvalidCaseReport>
    {
        public override void Map(BsonClassMap<InvalidCaseReport> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

        public override void Register()
        {
            BsonClassMap.RegisterClassMap<InvalidCaseReport>(Map);
        }
    }
}
