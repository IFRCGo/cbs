namespace Nyss.Web.Features.SmsGateway.Logic.Models
{
    public class Case
    {
        public bool IsValid { get; set; }
        public bool IsSingle { get; set; }
        public int HealthRiskCode { get; set; }
        public int CountFemalesBelowFive { get; set; }
        public int CountFemalesAtLeastFive { get; set; }
        public int CountMalesBelowFive { get; set; }
        public int CountMalesAtLeastFive { get; set; }
    }
}