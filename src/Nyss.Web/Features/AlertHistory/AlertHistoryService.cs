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
        IEnumerable<AlertHistoryViewModel> GetAlertsHistory(int numberOfWeeks, DateTime? startDate, bool includeNoAlerts);
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        private readonly Random Random = new Random();
        public IEnumerable<AlertHistoryViewModel> GetAlertsHistory(int numberOfWeeks, DateTime? startDate, bool includeNoAlerts)
        {
            return GenerageMockAlerts(numberOfWeeks, startDate, includeNoAlerts);
        }
        private List<AlertHistoryViewModel> GenerageMockAlerts(int numberOfWeeks, DateTime? startDate, bool includeNoAlerts = true)
        {
            if (!startDate.HasValue)
            {
                startDate = DateTime.Now;
            }
            DateTime to = startDate.Value.StartOfWeek(DayOfWeek.Sunday);
            DateTime from = DateTime.Now.AddDays(-7 * numberOfWeeks);

            List<AlertStatus> statuses = Statuses();
            List<AlertHistoryViewModel> alertsHistory = GenerateAlertHistory();
            alertsHistory = alertsHistory.Select(alertHistory =>
            {
                DateTime firstDayOfWeek = from;
                bool generateNoAlertsPeriod = Random.Next(100) <= 10;
                AlertStatus previousStatus = Pick<AlertStatus>.RandomItemFrom(statuses);
                while (firstDayOfWeek <= to)
                {
                    AlertStatus status = CalculateStatus(previousStatus);
                    var week = new WeekData
                    {
                        Date = firstDayOfWeek.ToString("d"),
                        Status = generateNoAlertsPeriod ? GetEnumDescription(AlertStatus.NoAlerts)
                                                        : GetEnumDescription(status)
                    };
                    previousStatus = status;
                    alertHistory.Weeks.Add(week);
                    firstDayOfWeek = firstDayOfWeek.AddDays(7);
                }
                return alertHistory;
            }).ToList();
            return alertsHistory.Where(alertHistory => includeNoAlerts == true 
                                                        || alertHistory.Weeks.Any(week => week.Status != GetEnumDescription(AlertStatus.NoAlerts)))
                .OrderBy(alertHistory => alertHistory.Region)
                .ThenBy(alertHistory => alertHistory.District)
                .ThenBy(alertHistory => alertHistory.Village)
                .ToList();
        }
        private AlertStatus CalculateStatus(AlertStatus previuosStatus) {

            AlertStatus newStatus = AlertStatus.NoAlerts;
            if (previuosStatus == AlertStatus.Closed || previuosStatus == AlertStatus.Dismissed)
            {
                newStatus = AlertStatus.NoAlerts;
            }
            else
            {
                bool changeStatus = Random.Next(100) <= 20;
                if (changeStatus)
                {
                    switch (previuosStatus)
                    {
                        case AlertStatus.NoAlerts:
                            newStatus = AlertStatus.Open;
                            break;
                        case AlertStatus.Open:
                            int probability = Random.Next(100);
                            if (probability < 50)
                            {
                                newStatus= AlertStatus.Escalated;
                            }
                            else
                            {
                                newStatus= AlertStatus.Dismissed;
                            }
                            break;
                        case AlertStatus.Escalated:
                            newStatus = AlertStatus.Closed;
                            break;
                        default:
                            newStatus = AlertStatus.NoAlerts;
                            break;
                    }
                }
                else
                {
                    newStatus = previuosStatus;
                }
            }
            return newStatus;


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
                .With(alertHistory => alertHistory.Region = "Ziguinchor")
                .With(alertHistory => alertHistory.District = "Bignona")
                .TheRest()
                .With(alertHistory => alertHistory.Region = "Ziguinchor")
                .With(alertHistory => alertHistory.District = "Ziguinchor")
                .Build()
                .ToList();
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
