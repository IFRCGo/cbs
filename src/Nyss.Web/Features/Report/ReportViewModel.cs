
using System;

namespace Nyss.Web.Features.Report
{
    public class ReportViewModel
    {
        public DateTime Timestamp { get; set; }
        public string Date => Timestamp.ToString("dd/MM/yyyy");
        public string Time => Timestamp.ToString("HH:mm");
        public string Status { get; set; }
        public string DataCollector { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string HealthRisk { get; set; }
        public string MalesUnder5 { get; set; }
        public string Males5OrOlder { get; set; }
        public string FemalesUnder5 { get; set; }
        public string Females5OrOlder { get; set; }
        public string TotalUnder5 { get; set; }
        public string Total5OrOlder { get; set; }
        public string TotalFemales { get; set; }
        public string TotalMales { get; set; }
        public string Total { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
        public string IsoYear { get; set; }
        public string IsoWeek { get; set; }
        public string IsoYearIsoWeek { get; set; }
    }
}
