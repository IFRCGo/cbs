using Dolittle.Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Report
{
    public class ReportId : ConceptAs<Guid>
    {
        public static readonly ReportId Empty = Guid.Empty;

        public static implicit operator ReportId(Guid value)
        {
            return new ReportId { Value = value };
        }
        public static implicit operator ReportId(string value)
        {
            return new ReportId { Value = Guid.Parse(value) };
        }
    }
}
