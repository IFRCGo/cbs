using System;
using System.Collections.Generic;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportFromUnknownDataCollector
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }

        public InvalidCaseReportFromUnknownDataCollector(Guid id) => Id = id;
    }
}
