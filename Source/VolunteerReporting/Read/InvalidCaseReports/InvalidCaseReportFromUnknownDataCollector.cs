using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReportFromUnknownDataCollector : IReadModel
    {
        public CaseReportId Id { get; set; }

        public string PhoneNumber { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }

        public InvalidCaseReportFromUnknownDataCollector(CaseReportId id) => Id = id;
    }
    
}
