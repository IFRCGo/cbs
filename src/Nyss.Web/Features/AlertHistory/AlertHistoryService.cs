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
        IEnumerable<AlertHistoryViewModel> GetAlertsHistory(int numberOfWeeks, bool includeNoAlerts);
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        public IEnumerable<AlertHistoryViewModel> GetAlertsHistory(int numberOfWeeks, bool includeNoAlerts)
        {
            return GenerageMockAlerts(numberOfWeeks, includeNoAlerts);
        }
        private IEnumerable<AlertHistoryViewModel> GenerageMockAlerts(int numberOfWeeks, bool includeNoAlerts = true)
        {
            DateTime to = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            DateTime from = DateTime.Now.AddDays(-7 * numberOfWeeks);

            List<AlertStatus> statuses = Statuses();
            List<AlertHistoryViewModel> alertsHistory = GenerateAlertHistory();
            alertsHistory = alertsHistory.Select(alertHistory =>
            {
                DateTime firstDayOfWeek = from;
                while (firstDayOfWeek <= to)
                {
                    var week = new WeekData
                    {
                        Date = firstDayOfWeek.ToString("d"),
                        Status = GetEnumDescription(Pick<AlertStatus>.RandomItemFrom(statuses))
                    };
                    alertHistory.Weeks.Add(week);
                    firstDayOfWeek = firstDayOfWeek.AddDays(7);
                }
                return alertHistory;
            }).ToList();

            var list =  alertsHistory
                .Where(alertHistory => includeNoAlerts == true || alertHistory.Weeks.Any(week => week.Status != GetEnumDescription(AlertStatus.NoAlerts)))
                .OrderBy(alertHistory => alertHistory.Region)
                .ThenBy(alertHistory => alertHistory.District)
                .ThenBy(alertHistory => alertHistory.Village)
                .ToList();
            return list;
        }
        private List<AlertHistoryViewModel> GenerateAlertHistory()
        {
            var alertsHistory = Builder<AlertHistoryViewModel>.CreateListOfSize(100)
                .TheFirst(10)
                .With(alertHistory => alertHistory.Region = "Dakar")
                .With(alertHistory => alertHistory.District = "Almadies")
                .TheNext(20)
                .With(alertHistory => alertHistory.Region = "Dakar")
                .With(alertHistory => alertHistory.District = "Dakar Plateau")
                .TheNext(20)
                .With(alertHistory => alertHistory.Region = "Thiès")
                .With(alertHistory => alertHistory.District = "M'bour")
                .TheNext(20)
                .With(alertHistory => alertHistory.Region = "Thiès")
                .With(alertHistory => alertHistory.District = "Saly")
                .TheNext(15)
                .With(alertHistory => alertHistory.Region = " Ziguinchor")
                .With(alertHistory => alertHistory.District = "Bignona")
                .TheRest()
                .With(alertHistory => alertHistory.Region = " Ziguinchor")
                .With(alertHistory => alertHistory.District = "Ziguinchor")
                .Build().ToList();
            return alertsHistory;
        }
        private List<AlertStatus> Statuses()
        {
            return Enum.GetValues(typeof(AlertStatus)).Cast<AlertStatus>().ToList();
        }
        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
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
