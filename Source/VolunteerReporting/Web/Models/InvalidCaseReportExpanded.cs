using Concepts;
using Read.DataCollectors;
using Read.CaseReports;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Read.InvalidCaseReports;

namespace Web.Models
{
    public class InvalidCaseReportExpanded
    {
        public Guid Id { get; set; }
        public Guid TextMessageId { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DataCollector DataCollector { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        public InvalidCaseReportExpanded(InvalidCaseReport invalidCaseReport, DataCollector dataCollector)
        {
            Id = invalidCaseReport.Id;
            Timestamp = invalidCaseReport.Timestamp;
            Message = invalidCaseReport.Message;
            ParsingErrorMessage = invalidCaseReport.ParsingErrorMessage;
            DataCollector = dataCollector;
        }
    }
}
