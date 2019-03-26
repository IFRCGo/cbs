using System;

namespace Web.Controllers
{
    // Todo: Move to proper place
    public class AnalyticsReport
    {
        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public TimeWindow TimeWindow { get; set; }

        public string[] Categories { get; set; }

        public Serie[] Series { get; set; }
    }
}