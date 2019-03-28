using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRisks
{
    public class HealthRisk : BaseReadModel
    {
        public Guid HealthRiskId { get; set; }
        public string Name { get; set; }

        public HealthRisk(Guid id, string name)
        {
            HealthRiskId = id;
            Name = name;
        }
    }
}
