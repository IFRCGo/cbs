namespace Nyss.Data.Models
{
    public class AlertRule
    {
        public int Id { get; set; }

        public int CountThreshold { get; set; }

        public int? HoursThreshold { get; set; }

        public int? MetersThreshold { get; set; }
    }
}
