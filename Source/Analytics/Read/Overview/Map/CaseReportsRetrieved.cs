using Dolittle.ReadModels;
using System;
using System.Collections;
using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
namespace Read.Overview.Map
{
    public class CaseReportsRetrieved
    {
        public CaseReportIdRetrievedId Id { get; set; }
        public HealthRiskName HealthRiskName { get; set; }
        public IList<CaseReport> CaseReportsLast7Days { get; set; }
        public IList<CaseReport> CaseReportsLast30Days { get; set; }
    }

}