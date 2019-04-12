using Read.Model;
using System;

namespace Read.Models
{
    public class AnalysisReport
    {
        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public TimeAggregation TimeAggregation { get; set; }

        public string[] Categories { get; set; }

        public Serie[] Series { get; set; }
    }
}