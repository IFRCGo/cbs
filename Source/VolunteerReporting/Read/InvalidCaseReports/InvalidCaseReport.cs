using System;
using System.Collections.Generic;
using System.Text;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReport
    {
        public Guid Id { get; set; }
        public Guid TextMessageId { get; set; }
        public Guid DataCollectorId { get; internal set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidCaseReport(Guid id) => Id = id;
    }
}
