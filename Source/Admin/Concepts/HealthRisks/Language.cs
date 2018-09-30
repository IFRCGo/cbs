using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class Language : ConceptAs<string>
    {
        public static implicit operator Language(string language) => new Language { Value = language };
    }
}