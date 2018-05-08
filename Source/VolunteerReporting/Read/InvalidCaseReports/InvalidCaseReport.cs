using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.ReadModels;

namespace Read.InvalidCaseReports
{
    public class InvalidCaseReport : IReadModel, IHaveReadModelIdOf<Guid>
    {
        public Guid Id { get; set; }
        public Guid DataCollectorId { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidCaseReport(Guid id) => Id = id;
    }
}
