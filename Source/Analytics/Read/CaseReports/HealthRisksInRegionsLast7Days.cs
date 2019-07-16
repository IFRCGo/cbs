using Concepts.HealthRisks;
using Dolittle.ReadModels;
using System.Collections.Generic;

namespace Read.CaseReports
{
    public class HealthRisksInRegionsLast7Days : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskName HealthRiskName { get; set; }
        public IList<RegionWithHealthRisk> Regions { get; set; }
    }
}