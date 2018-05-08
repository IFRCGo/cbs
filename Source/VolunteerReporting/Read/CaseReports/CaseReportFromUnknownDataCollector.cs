using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReportFromUnknownDataCollector : IReadModel<Guid>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Origin { get; set; }
        public Guid HealthRiskId { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public CaseReportFromUnknownDataCollector(Guid id)
        {
            this.Id = id;
        }

    }
}