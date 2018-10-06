using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class CaseDefinition : ConceptAs<string>
    {
        public static implicit operator CaseDefinition(string caseDefinition) => new CaseDefinition { Value = caseDefinition };
    }
}