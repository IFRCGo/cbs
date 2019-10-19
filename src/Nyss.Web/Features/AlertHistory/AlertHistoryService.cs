using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;

namespace Nyss.Web.Features.AlertHistory
{
    public interface IAlertHistoryService
    {
        AlertHistoryViewModel GetAlertsHistory(int numberOfWeeks, string startDate, bool includeNoAlerts, string baseURL);
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        private readonly Random Random = new Random();
        public AlertHistoryViewModel GetAlertsHistory(int numberOfWeeks, string startDate, bool includeNoAlerts, string baseURL)
        {
            if (!DateTime.TryParse(startDate, CultureInfo.CurrentUICulture, DateTimeStyles.None, out DateTime startDateFormatted))
            {
                startDateFormatted = DateTime.Now;
            }
            return GenerageMockAlerts(numberOfWeeks, startDateFormatted, baseURL, includeNoAlerts);
        }
        private AlertHistoryViewModel GenerageMockAlerts(int numberOfWeeks, DateTime startDate, string baseURL, bool includeNoAlerts = true)
        {

            DateTime to = startDate;
            DateTime from = to.AddDays(-7 * numberOfWeeks);

            AlertHistoryViewModel alertsHistory = new AlertHistoryViewModel
            {
                Villages = GenerateVillages(),
                Alerts = new List<Alert>()
            };
            foreach (var village in alertsHistory.Villages)
            {
                alertsHistory.Alerts.AddRange(GenerateAlerts(from, to, village.Id, baseURL));
            }
            return alertsHistory;
        }
        private List<Alert> GenerateAlerts(DateTime from, DateTime to, int villageId, string baseURL)
        {
            List<Alert> alerts = new List<Alert>();
            bool generateNoAlertsPeriod = Random.Next(100) <= 10;
            if (!generateNoAlertsPeriod)
            {
                DateTime startDate = from.AddDays(Random.Next(-10, 4));
                DateTime endAlertDate = to.AddDays(Random.Next(-3, 3));
                DateTime endDate = startDate;

                int alertId = 1;
                while (endDate <= endAlertDate && startDate <= to)
                {
                    endDate = startDate.AddDays(Random.Next(100));
                    var alert = new Alert
                    {
                        StartDate = startDate.ToString("s"),
                        VillageId = villageId,
                        EndDate = endDate >= endAlertDate ? null : endDate.ToString("s"),
                        Metadata = new AlertData
                        {
                            Id = alertId * villageId,
                            Url = baseURL
                        }
                    };
                    alerts.Add(alert);
                    alertId++;
                    startDate = endDate.AddDays(Random.Next(100));
                }
            }
            return alerts;
        }
        private List<Village> GenerateVillages()
        {
            var villages = Builder<Village>.CreateListOfSize(50)
                .TheFirst(5)
                .With(alertHistory => alertHistory.Region = "Dakar")
                .With(alertHistory => alertHistory.District = "Almadies")
                .TheNext(7)
                .With(alertHistory => alertHistory.Region = "Dakar")
                .With(alertHistory => alertHistory.District = "Dakar Plateau")
                .TheNext(13)
                .With(alertHistory => alertHistory.Region = "Thiès")
                .With(alertHistory => alertHistory.District = "M'bour")
                .TheNext(4)
                .With(alertHistory => alertHistory.Region = "Thiès")
                .With(alertHistory => alertHistory.District = "Saly")
                .TheNext(16)
                .With(alertHistory => alertHistory.Region = "Ziguinchor")
                .With(alertHistory => alertHistory.District = "Bignona")
                .TheRest()
                .With(alertHistory => alertHistory.Region = "Ziguinchor")
                .With(alertHistory => alertHistory.District = "Ziguinchor")
                .Build()
                .ToList();
            foreach (var villate in villages)
            {

            }
            return villages.Select((village, index) =>
            {
                village.Id = index + 1;
                return village;
            }).ToList();
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
