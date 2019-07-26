using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class CaseReportId : ConceptAs<Guid>
    {
        public static readonly CaseReportId NotSet = Guid.Empty;

        public static implicit operator CaseReportId (Guid value)
        {
            return new CaseReportId { Value = value };
        }
        public static implicit operator CaseReportId(string id)
        {
            return new CaseReportId { Value = Guid.Parse(id) };
        }
    }
}
