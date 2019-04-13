namespace Read.Models.KPI
{
    public class AlertEscalated
    {
        public string HealthRisk { get; set; }
        public int NumberOfReports { get; set; }

        public AlertEscalated(string healthRisk, int numberOfReports)
        {
            HealthRisk = healthRisk;
            NumberOfReports = numberOfReports;
        }
    }
}
