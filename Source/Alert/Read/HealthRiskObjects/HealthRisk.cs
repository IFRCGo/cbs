namespace Read.HealthRiskObjects
{
    public class HealthRisk : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ThresholdTimePeriodInDays { get; set; }
        public int ThresholdNumberOfCases { get; set; }
    }
}
