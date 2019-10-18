
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using RandomNameGeneratorLibrary;

namespace Nyss.Web.Features.Report
{
    public class RandomReportService : IReportService
    {
        public IEnumerable<ReportViewModel> GenerateMultipleRandomReports(int numberOfReportsToGenerate = 20)
        {
            var r = new Random();

            for (int i = 0; i < numberOfReportsToGenerate; i++)
            {
                yield return GenerateRandomReport(r);
            }
        }

        public ReportViewModel GenerateRandomReport(Random r = null)
        {
            var random = r ?? new Random();

            var report = new ReportViewModel();

            var dt = DateTime.Now;

            report.Timestamp = dt;
            report.IsoYear = dt.ToString("yyyy");
            report.IsoWeek = GetEpiWeek(dt).ToString();
            report.IsoYearIsoWeek = $"{report.IsoYear}-{report.IsoWeek}";

            var personGenerator = new PersonNameGenerator();
            report.DataCollector = personGenerator.GenerateRandomFirstAndLastName();

            report.Region = $"Region {random.Next(1, 10)}";
            report.District = $"District {random.Next(1, 10)}";
            report.Village = $"Village {random.Next(1, 10)}";

            var latitude = random.NextDouble() * 180 - 90;
            var longitude = random.NextDouble() * 360 - 180;
            report.Location = $"{latitude:0.0000}/{longitude:0.0000}";

            var error = random.Next(0, 5);
            if (error == 0)
            {
                GenerateErrorReport(report);
            }
            else
            {
                GenerateSuccessReport(report, random);
            }

            return report;
        }

        private readonly string[] _healthRisks = new[]
        {
            "AWD",
            "Cholera",
            "HepatitsB"
        };

        private void GenerateSuccessReport(ReportViewModel report, Random random)
        {
            report.Status = "Success";

            var healthRiskIndex = random.Next(0, _healthRisks.Length);

            var mUnder5 = random.Next(1, 10);
            var mOver5 = random.Next(1, 10);
            var fUnder5 = random.Next(1, 10);
            var fOver5 = random.Next(1, 10);

            report.HealthRisk = _healthRisks[healthRiskIndex];
            report.MalesUnder5 = mUnder5.ToString();
            report.Males5OrOlder = mOver5.ToString();
            report.FemalesUnder5 = fUnder5.ToString();
            report.Females5OrOlder = fOver5.ToString();
            report.TotalUnder5 = (mUnder5 + fUnder5).ToString();
            report.Total5OrOlder = (mOver5 + fOver5).ToString();
            report.TotalFemales = (fUnder5 + fOver5).ToString();
            report.TotalMales = (mUnder5 + mOver5).ToString();
            report.Total = (mUnder5 + mOver5 + fUnder5 + fOver5).ToString();

            report.Message = $"{healthRiskIndex + 1}#{mUnder5}#{mOver5}#{fUnder5}#{fOver5}";
            report.Errors = string.Empty;
        }

        private void GenerateErrorReport(ReportViewModel report)
        {
            report.Status = "Error";
            report.HealthRisk = string.Empty;
            report.MalesUnder5 = string.Empty;
            report.Males5OrOlder = string.Empty;
            report.FemalesUnder5 = string.Empty;
            report.Females5OrOlder = string.Empty;
            report.TotalUnder5 = string.Empty;
            report.Total5OrOlder = string.Empty;
            report.TotalFemales = string.Empty;
            report.TotalMales = string.Empty;
            report.Total = string.Empty;

            report.Message = "gibberish";
            report.Errors = "Wrong message";
        }

        public IEnumerable<ReportViewModel> All()
        {
            return GenerateMultipleRandomReports();
        }

        public static int GetEpiWeek(DateTime time)
        {
            if (time.Month == 12 && time.Day > 28)
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
                if (day >= DayOfWeek.Sunday && day <= DayOfWeek.Tuesday)
                {
                    time = time.AddDays(3);
                }
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }
    }
}