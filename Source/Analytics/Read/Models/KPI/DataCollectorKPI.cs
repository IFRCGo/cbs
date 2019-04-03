namespace Read.Models.KPI
{
    public class DataCollectorKPI
    {
        public int TotalNumberOfDataCollectors { get; set; }
        public int ActiveDataCollectors { get; set; }
        public int InactiveDataCollectors { get { return TotalNumberOfDataCollectors - ActiveDataCollectors; } }
    }
}
