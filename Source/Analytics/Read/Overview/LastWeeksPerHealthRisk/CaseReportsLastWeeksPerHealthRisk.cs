using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.Overview.LastWeeksPerHealthRisk
{
    public class CaseReportsLastWeeksPerHealthRisk : IReadModel
    {
        public Day Id { get; set; }
        public IDictionary<HealthRiskId,CaseReportsLastWeeksForHealthRisk> CaseReportsPerHelthRisk { get; set; }
    }
}
