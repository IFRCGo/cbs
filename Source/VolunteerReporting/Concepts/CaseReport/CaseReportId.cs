using System;
using Dolittle.Concepts;

namespace Concepts.CaseReport
{
    public class CaseReportId : ConceptAs<Guid>
    {
        public static readonly CaseReportId NotSet = Guid.Empty;

        public static implicit operator CaseReportId (Guid value)
        {
            return new CaseReportId { Value = value };
        }
    }
}