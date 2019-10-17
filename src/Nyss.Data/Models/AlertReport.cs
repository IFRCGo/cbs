namespace Nyss.Data.Models
{
    public class AlertReport
    {
        public int AlertId { get; set; }
        public virtual Alert Alert { get; set; }

        public int ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
