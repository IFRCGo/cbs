using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRiskFeatures
{
    public class HealthRisk
    {
        public Guid Id { get; set; }

        public int ReadableId { get; set; }

        public HealthRisk(Guid id)
        {
            Id = id;
        }
    }
}
