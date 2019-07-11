using Dolittle.ReadModels;
using System;
using System.Collections;
using System.Collections.Generic;
using Concepts;
using Concepts.Map;
using Concepts.HealthRisk;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
namespace Read.Map
{
    public class CaseReportsRetrieved
    {
        public CaseReportRetrievedId Id { get; set; }
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReportForMap> CaseReportsLast7Days { get; set; }
        public IList<CaseReportForMap> CaseReportsLast30Days { get; set; }
    }

}