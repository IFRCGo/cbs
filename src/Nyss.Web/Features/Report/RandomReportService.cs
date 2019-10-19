
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using Nyss.Web.Features.SlowReports;
using Nyss.Web.Features.SlowReports.Logic;
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

        public Task<PaginationResult<ReportViewModel>> GetReportsAsync(PaginationOptions options)
        {
            var query = GenerateMultipleRandomReports(312).AsQueryable();

            var totalCount = query.Count();

            switch (options.Order?.ToLower())
            {
                case "date":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Date)
                        : query.OrderByDescending(x => x.Date);
                    break;

                case "time":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Time)
                        : query.OrderByDescending(x => x.Time);
                    break;

                case "status":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Status)
                        : query.OrderByDescending(x => x.Status);
                    break;

                case "datacollector":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.DataCollector)
                        : query.OrderByDescending(x => x.DataCollector);
                    break;

                case "region":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Region)
                        : query.OrderByDescending(x => x.Region);
                    break;

                case "district":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.District)
                        : query.OrderByDescending(x => x.District);
                    break;

                case "village":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Village)
                        : query.OrderByDescending(x => x.Village);
                    break;

                case "healthrisk":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.HealthRisk)
                        : query.OrderByDescending(x => x.HealthRisk);
                    break;

                case "malesunder5":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.MalesUnder5)
                        : query.OrderByDescending(x => x.MalesUnder5);
                    break;

                case "males5orolder":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Males5OrOlder)
                        : query.OrderByDescending(x => x.Males5OrOlder);
                    break;

                case "femalesunder5":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.FemalesUnder5)
                        : query.OrderByDescending(x => x.FemalesUnder5);
                    break;

                case "females5orolder":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Females5OrOlder)
                        : query.OrderByDescending(x => x.Females5OrOlder);
                    break;

                case "totalunder5":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.TotalUnder5)
                        : query.OrderByDescending(x => x.TotalUnder5);
                    break;

                case "total5orolder":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Total5OrOlder)
                        : query.OrderByDescending(x => x.Total5OrOlder);
                    break;

                case "totalfemales":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.TotalFemales)
                        : query.OrderByDescending(x => x.TotalFemales);
                    break;

                case "totalmales":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.TotalMales)
                        : query.OrderByDescending(x => x.TotalMales);
                    break;

                case "total":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Total)
                        : query.OrderByDescending(x => x.Total);
                    break;

                case "location":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Location)
                        : query.OrderByDescending(x => x.Location);
                    break;

                case "message":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Message)
                        : query.OrderByDescending(x => x.Message);
                    break;

                case "errors":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.Errors)
                        : query.OrderByDescending(x => x.Errors);
                    break;

                case "isoyear":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.IsoYear)
                        : query.OrderByDescending(x => x.IsoYear);
                    break;

                case "isoweek":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.IsoWeek)
                        : query.OrderByDescending(x => x.IsoWeek);
                    break;

                case "isoyearisoweek":
                    query = options.OrderAsc
                        ? query.OrderBy(x => x.IsoYearIsoWeek)
                        : query.OrderByDescending(x => x.IsoYearIsoWeek);
                    break;
            }

            foreach (var searchKeyValuePair in options.SearchDictionary.Where(x => !string.IsNullOrEmpty(x.Value)))
            {
                var search = searchKeyValuePair.Key.ToLower();
                var value = searchKeyValuePair.Value;
                if (search == "date")
                {
                    query = query.Where(x => (x.Date).Contains(value));
                }
                else if (search == "time")
                {
                    query = query.Where(x => (x.Time).Contains(value));
                }
                else if (search == "status")
                {
                    query = query.Where(x => (x.Status).Contains(value));
                }
                else if (search == "datacollector")
                {
                    query = query.Where(x => (x.DataCollector).Contains(value));
                }
                else if (search == "region")
                {
                    query = query.Where(x => (x.Region).Contains(value));
                }
                else if (search == "district")
                {
                    query = query.Where(x => (x.District).Contains(value));
                }
                else if (search == "village")
                {
                    query = query.Where(x => (x.Village).Contains(value));
                }
                else if (search == "healthrisk")
                {
                    query = query.Where(x => (x.HealthRisk).Contains(value));
                }
                else if (search == "malesunder5")
                {
                    query = query.Where(x => (x.MalesUnder5).Contains(value));
                }
                else if (search == "males5orolder")
                {
                    query = query.Where(x => (x.Males5OrOlder).Contains(value));
                }
                else if (search == "femalesunder5")
                {
                    query = query.Where(x => (x.FemalesUnder5).Contains(value));
                }
                else if (search == "females5orolder")
                {
                    query = query.Where(x => (x.Females5OrOlder).Contains(value));
                }
                else if (search == "totalunder5")
                {
                    query = query.Where(x => (x.TotalUnder5).Contains(value));
                }
                else if (search == "total5orolder")
                {
                    query = query.Where(x => (x.Total5OrOlder).Contains(value));
                }
                else if (search == "totalfemales")
                {
                    query = query.Where(x => (x.TotalFemales).Contains(value));
                }
                else if (search == "totalmales")
                {
                    query = query.Where(x => (x.TotalMales).Contains(value));
                }
                else if (search == "total")
                {
                    query = query.Where(x => (x.Total).Contains(value));
                }
                else if (search == "location")
                {
                    query = query.Where(x => (x.Location).Contains(value));
                }
                else if (search == "message")
                {
                    query = query.Where(x => (x.Message).Contains(value));
                }
                else if (search == "errors")
                {
                    query = query.Where(x => (x.Errors).Contains(value));
                }
                else if (search == "isoyear")
                {
                    query = query.Where(x => (x.IsoYear).Contains(value));
                }
                else if (search == "isoweek")
                {
                    query = query.Where(x => (x.IsoWeek).Contains(value));
                }
                else if (search == "isoyearisoweek")
                {
                    query = query.Where(x => (x.IsoYearIsoWeek).Contains(value));
                }
            }

            var filteredCount = query.Count();

            query = query.Skip(options.Start);

            if (options.Count != -1)
            {
                query = query.Take(options.Count);
            }

            var result = new PaginationResult<ReportViewModel>
            {
                TotalCount = totalCount,
                FilteredCount = filteredCount,
                Data = query.ToList()
            };

            return Task.FromResult(result);
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