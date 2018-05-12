using System;
using System.Collections.Generic;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportFromUnknownDataCollector : IReadModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }

        public InvalidCaseReportFromUnknownDataCollector(Guid id) => Id = id;
    }

    public class InvalidCaseReportFromUnknownDataCollectorClassMap : MongoDbClassMap<InvalidCaseReportFromUnknownDataCollector>
    {
        public override void Map(BsonClassMap<InvalidCaseReportFromUnknownDataCollector> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }
    }
}
