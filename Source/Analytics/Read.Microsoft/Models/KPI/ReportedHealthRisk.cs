namespace Read.Models.KPI
{
    public class ReportedHealthRisk
    {
        public string Name { get; set; }
        public int NumberOfReports { get; set; }

        public void AddNumberOfReports(int numReports)
        {
            NumberOfReports = NumberOfReports + numReports;
        }
    }
}
