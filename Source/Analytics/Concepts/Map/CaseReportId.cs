using Dolittle.Concepts;
using System;
namespace Concepts
{
    public class CaseReportId : ConceptAs<Guid>
    {
        public static implicit operator CaseReportId(Guid value)
        {
            return new CaseReportId {Value = value};
        }
    }
}
