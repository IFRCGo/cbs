using Dolittle.Concepts;

namespace Concepts
{
    public class AlertRuleName : ConceptAs<string>
    {
        public static implicit operator AlertRuleName(string value)
        {
            return new AlertRuleName { Value = value };
        }
    }
}