using System;
using Dolittle.ReadModels;
using Concepts;
using Concepts.HealthRisks;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace Read.Map
{
    public class CaseReportsBeforeDay : IReadModel
    {
        public Day Id {get; set;}
        
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public IDictionary<HealthRiskId, CaseReportsRetrieved> CaseReportsPerHealthRisk { get; set; } 
    }
}