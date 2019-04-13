using System.Collections.Generic;

namespace Read.Models.KPI
{
    public class AlertKPI
    {
        public int TotalNumberOfAlerts { get; set; }
        public List<AlertEscalated> AlertsPerHealthRisk { get; set; }

        public AlertKPI()
        {
            AlertsPerHealthRisk = new List<AlertEscalated>();
        }
    }
}
