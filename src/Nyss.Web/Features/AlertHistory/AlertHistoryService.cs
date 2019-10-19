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
        AlertHistoryViewModel GetAlertsHistory(int numberOfWeeks, string startDate, bool includeNoAlerts);
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        private readonly Random Random = new Random();
        public AlertHistoryViewModel GetAlertsHistory(int numberOfWeeks, string startDate, bool includeNoAlerts)
        {
            if (!DateTime.TryParse(startDate, CultureInfo.CurrentUICulture, DateTimeStyles.None, out DateTime startDateFormatted))
            {
                startDateFormatted = DateTime.Now;
            }
            return GenerageMockAlerts(numberOfWeeks, startDateFormatted, includeNoAlerts);
        }
        private AlertHistoryViewModel GenerageMockAlerts(int numberOfWeeks, DateTime startDate, bool includeNoAlerts = true)
        {

            DateTime to = startDate;
            DateTime from = to.AddDays(-7 * numberOfWeeks);

            AlertHistoryViewModel alertsHistory = new AlertHistoryViewModel
            {
                From = from.ToString("s"),
                To = to.ToString("s"),
                Villages = GenerateVillages()
            };
            alertsHistory.Villages = alertsHistory.Villages.Select((village, index) =>
            {
                village.Alerts = GenerateAlerts(from, to, index + 1);
                return village;
            }).ToList();
            alertsHistory.Villages = alertsHistory.Villages.Where(alertHistory => includeNoAlerts == true || alertHistory.Alerts.Any())
                .OrderBy(alertHistory => alertHistory.Region)
                .ThenBy(alertHistory => alertHistory.District)
                .ThenBy(alertHistory => alertHistory.Village)
                .ToList();
            return alertsHistory;
        }
        private List<Alert> GenerateAlerts(DateTime from, DateTime to, int index)
        {
            List<Alert> alerts = new List<Alert>();
            bool generateNoAlertsPeriod = Random.Next(100) <= 10;
            if (!generateNoAlertsPeriod)
            {
                DateTime startDate = from.AddDays(Random.Next(-10, 4));
                DateTime endAlertDate = to.AddDays(Random.Next(-3, 3));
                DateTime endDate = startDate.AddDays(Random.Next(20));
                if (endDate > endAlertDate)
                {
                    endDate = endAlertDate;
                }
                int alertId = 1;
                while (endDate <= endAlertDate)
                {
                    var alert = new Alert
                    {
                        StartDate = startDate.ToString("s"),
                        EndDate = endDate == endAlertDate ? null : endDate.ToString("s"),
                        Metadata = new AlertData
                        {
                            Id = alertId * index,
                            Url = "https://localhost:44365/Alerts/"
                        }
                    };
                    alerts.Add(alert);
                    alertId++;
                    startDate = endDate.AddDays(Random.Next(100));
                    endDate = startDate.AddDays(Random.Next(100));
                }
            }
            return alerts;
        }
        private List<VillageHistory> GenerateVillages()
        {
            var alertsHistory = Builder<VillageHistory>.CreateListOfSize(50)
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
            return alertsHistory;
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
