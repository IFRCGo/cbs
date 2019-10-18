using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.AlertHistory
{
    public class AlertHistoryViewModel
    {
        public AlertHistoryViewModel() {
            Weeks = new HashSet<WeekData>();
        }
        public string Village { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public ICollection<WeekData> Weeks { get; set; }

    }
    public class WeekData
    {
        public string Date { get; set; }
        public string Status { get; set; }
    }

    public enum AlertStatus
    {
        [Description("Open")]
        Open,
        [Description("Dismissed")]
        Dismissed,
        [Description("Escalated")]
        Escalated,
        [Description("Closed")]
        Closed,
        [Description("No alerts")]
        NoAlerts
    }
}
