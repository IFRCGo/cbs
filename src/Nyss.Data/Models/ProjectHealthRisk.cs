namespace Nyss.Data.Models
{
    public class ProjectHealthRisk
    {
        public int Id { get; set; }

        public string FeedbackMessage { get; set; }

        public virtual Project Project { get; set; }

        public virtual HealthRisk HealthRisk { get; set; }

        public virtual AlertRule AlertRule { get; set; }
    }
}
