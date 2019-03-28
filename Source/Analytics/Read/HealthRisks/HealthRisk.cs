using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.HealthRisks
{
    public class HealthRisk : BaseReadModel
    {
        public Guid HealthRiskId { get; set; }
        public string Name { get; set; }

        public Dictionary<DateTimeOffset, int> ReportsPerDay { get; set; }

        public HealthRisk(Guid id, string name)
        {
            HealthRiskId = id;
            Name = name;
            ReportsPerDay = new Dictionary<DateTimeOffset, int>();
        }

        public void ReportReceived(DateTimeOffset dateTime)
        {
            if (ReportsPerDay.Keys.Contains(dateTime))
                ReportsPerDay[dateTime] = ReportsPerDay[dateTime] + 1;
            else
                ReportsPerDay[dateTime] = 1;
        }
    }
}
