using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.AlertHistory
{
    public class AlertHistoryViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
       public List<VillageHistory> Villages { get; set; }
    }
    public class VillageHistory
    {
        public VillageHistory()
        {
            Alerts = new HashSet<Alert>();
        }
        public string Village { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public ICollection<Alert> Alerts { get; set; }
    }
    public class Alert
    {
        public AlertData Metadata { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class AlertData
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }

    public enum AlertStatus
    {
        [Description("No alerts")]
        NoAlerts = 0,
        [Description("Open")]
        Open = 1,
        [Description("Dismissed")]
        Dismissed = 2,
        [Description("Escalated")]
        Escalated = 3,
        [Description("Closed")]
        Closed = 4
    }
}
