using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.HealthRisks
{
    public class HealthRisk : BaseReadModel
    {
        public Guid HealthRiskId { get; set; }
        public string Name { get; set; }

        public Dictionary<int, int> ReportsPerWeek { get; set; }

        public HealthRisk(Guid id, string name)
        {
            HealthRiskId = id;
            Name = name;
            ReportsPerWeek = new Dictionary<int, int>();
        }

        public void ReportReceived(DateTimeOffset dateTime)
        {
            int weekNumber = dateTime.DateTime.GetWeekNumber();

            if (ReportsPerWeek.Keys.Contains(weekNumber))
                ReportsPerWeek[weekNumber] = ReportsPerWeek[weekNumber] + 1;
            else
                ReportsPerWeek[weekNumber] = 1;
        }
    }
}
