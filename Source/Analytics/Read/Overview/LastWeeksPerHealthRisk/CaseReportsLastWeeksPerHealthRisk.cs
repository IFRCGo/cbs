using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace Read.Overview.LastWeeksPerHealthRisk
{
    public class CaseReportsLastWeeksPerHealthRisk : IReadModel
    {
        public Day Id { get; set; }
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public IDictionary<HealthRiskId,CaseReportsLastWeeksForHealthRisk> CaseReportsPerHealthRisk { get; set; }
    }
}
