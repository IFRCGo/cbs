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
        IEnumerable<AlertHistoryViewModel> GenerateAlerts(int numberOfWeeks);
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        public IEnumerable<AlertHistoryViewModel> GenerateAlerts(int numberOfWeeks)
        {
            DateTime to = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            DateTime from = DateTime.Now.AddDays(-7 * numberOfWeeks);

            var statuses = Statuses();
            List<AlertHistoryViewModel> villages = Builder<AlertHistoryViewModel>.CreateListOfSize(10).Build().ToList();
            villages = villages.Select(village =>
            {
                DateTime firstDayOfWeek = from;
                while (firstDayOfWeek <= to)
                {
                    var week = new WeekData
                    {
                        Date = firstDayOfWeek.ToString("d"),
                        Status = GetEnumDescription(Pick<AlertStatus>.RandomItemFrom(statuses))
                    };
                    village.Week.Add(week);
                    firstDayOfWeek = firstDayOfWeek.AddDays(7);
                }
                return village;
            }).ToList();
           
            return villages;
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
