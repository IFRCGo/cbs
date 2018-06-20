using System;
using System.Collections.Generic;
using Concepts;
using Concepts.CaseReport;
using Concepts.DataCollector;
using Dolittle.ReadModels;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReport : IReadModel
    {
        public CaseReportId Id { get; set; }

        public DataCollectorId DataCollectorId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidCaseReport(CaseReportId id) => Id = id;
    }
}
