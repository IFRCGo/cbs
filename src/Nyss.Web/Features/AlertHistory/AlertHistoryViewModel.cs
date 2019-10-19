using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.AlertHistory
{
    public class AlertHistoryViewModel
    {
        public AlertHistoryViewModel()
        {
            Villages = new List<Village>();
            Alerts = new List<Alert>();
        }
        public List<Village> Villages { get; set; }
        public List<Alert> Alerts { get; set; }
    }
    public class Village
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
    }
    public class Alert
    {
        public int VillageId { get; set; }
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
