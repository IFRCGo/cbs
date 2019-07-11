using Dolittle.Concepts;
using System;

namespace Concepts.Map
{
    public class CaseReportRetrievedId : ConceptAs<Guid>
    {
        public static implicit operator CaseReportRetrievedId(Guid value)
        {
            return new CaseReportRetrievedId {Value = value};
        }
    }
}
