using System;

namespace Web.Controllers
{
    // Todo: Move to proper place
    public class AnalyticsService
    {
        public AnalyticsReport GetAggregation(DateTimeOffset @from, DateTimeOffset to)
        {
            var report = new AnalyticsReport()
            {
                From = @from,
                To = to,
                TimeWindow = TimeWindow.Day,
            };

            report.Categories = new[] { "2019-03-24", "2019-03-24", "2019-03-24", "2019-03-24", "2019-03-24" };
            report.Series = new[]
            {
                new Serie() {Label = "Males under 5", Data = new[] {1, 4, 5, 67, 8, 5, 3}},
                new Serie() {Label = "Males over 5", Data = new[] {1, 4, 5, 67, 8, 5, 3}},
                new Serie() {Label = "Females under 5", Data = new[] {1, 4, 5, 67, 8, 5, 3}},
                new Serie() {Label = "Females over 5", Data = new[] {1, 4, 5, 67, 8, 5, 3}}
            };

            return report;
        }
    }
}