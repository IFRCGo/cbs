using System;
namespace Nyss.Web.Features.Report
{
    public class ReportViewModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string DataCollector { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string HealthRisk { get; set; }
        public int MalesUnder5 { get; set; }
        public int Males5OrOlder { get; set; }
        public int FemalesUnder5 { get; set; }
        public int Females5OrOlder { get; set; }
        public int TotalUnder5 { get; set; }
        public int Total5OrOlder { get; set; }
        public int TotalFemales { get; set; }
        public int TotalMales { get; set; }
        public int Total { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
        public string IsoYear { get; set; }
        public string IsoWeek { get; set; }
        public string IsoYearIsoWeek { get; set; }

    }
}
